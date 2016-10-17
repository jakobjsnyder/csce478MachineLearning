using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hw2ann;

namespace hw2ann
{
    class Backprop
    {
        static double eta = 0.15;
        static int maxPasses = 2000;
        static double minErrorCondition = .0001;
        static int Passes = 0;
        public static List<Neuron> InputLayer = new List<Neuron>();
        public static List<Neuron> HiddenLayer = new List<Neuron>();
        public static Neuron OutputNeuron = new Neuron();
        public static Neuron BiasNeuron = new Neuron();
    
        public static void Main(string[] args)
        {
            #region Parse 
            int dataSelector = 3;
            List<Element> fullData = Parser.parseData(dataSelector);
            //split into training and testing data
            List<Element> trainingData = new List<Element>();
            List<Element> testingData = new List<Element>();
            List<int> testingInts = new List<int>();
            Random rnd = new Random();
            for (int i = 0; i <= 30; i++)
            {
                testingInts.Add(rnd.Next(fullData.Count));
            }
           
            for (int j = 0; j < fullData.Count; j++)
            {
                if (testingInts.Contains(j))
                {
                    testingData.Add(fullData[j]);
                }
                else
                {
                    trainingData.Add(fullData[j]);
                }
            }

            #endregion
            InputLayer = createInputLayer(dataSelector);
            HiddenLayer = createHiddenLayer(dataSelector);
            OutputNeuron = new Neuron();

            #region Create Network
            for (int i = 0; i < HiddenLayer.Count; i++)     //create network structure
            {
                for(int j = 0; j < InputLayer.Count; j++)
                {
                    HiddenLayer[i].addInConnection(InputLayer[j]);
                }
                OutputNeuron.addInConnection(HiddenLayer[i]);
                HiddenLayer[i].addBiasConnection(BiasNeuron);
            }
            OutputNeuron.addBiasConnection(BiasNeuron);
            #endregion

            double prevErrorSquared = 10.0;
            double errorSquared = 10.0;
            while( Passes < maxPasses && errorSquared > .0001)
            {
                prevErrorSquared = errorSquared;
                 errorSquared = 0.0;
                //set the values of the input neurons based on the attribute values
                foreach (Element trial in trainingData)
                {
                    setInputNeuronValues(trial, dataSelector);

                    //set the hidden layer values based on the weights of connections and the value of the input nodes that go into it.
                    for (int i = 0; i < HiddenLayer.Count; i++)
                    {
                        HiddenLayer[i].calculateOutputValue();
                    }

                    OutputNeuron.calculateOutputValue();

                    errorSquared += Math.Pow(((double)trial.Label - OutputNeuron.getOutputValue()), 2);
                    //Console.WriteLine("Training Error = " + ((double)trial.Label - OutputNeuron.getOutputValue()));

                    #region Finding Deltas
                    //find the deltas       //TODO getBias should always be 1
                    double deltaWD = OutputNeuron.getOutputValue() * (trial.Label - OutputNeuron.getOutputValue()) * (1 - OutputNeuron.getOutputValue());
                    OutputNeuron.setDeltaWeight(deltaWD);

                    // find deltas for each hidden neuron
                    for(int i = 0; i< HiddenLayer.Count; i++)
                    {
                        //double deltaWC = HiddenLayer[i].getOutputValue() * (trial.Label - HiddenLayer[i].getOutputValue()) * deltaWD * OutputNeuron.InConnections[i].getWeight();
                        double deltaWC = HiddenLayer[i].getOutputValue() * (1-HiddenLayer[i].getOutputValue())*deltaWD;

                        HiddenLayer[i].setDeltaWeight(deltaWC);
                    }

                    #endregion


                    #region Update Weights
                    double deltaW = 0.0;
                    double outputWeight = 0.0;
                    for(int j = 0; j < OutputNeuron.InConnections.Count; j++)
                    {
                        deltaW = OutputNeuron.getDeltaWeight();
                        outputWeight = OutputNeuron.InConnections[j].getWeight() + (eta * OutputNeuron.InConnections[j].LeftNeuron.getOutputValue() * deltaWD);
                        OutputNeuron.InConnections[j].setWeight(outputWeight);
                    }

                    OutputNeuron.BiasConnection.setWeight(OutputNeuron.BiasConnection.getWeight() + (eta * deltaW));

                    for(int k = 0; k < HiddenLayer.Count; k ++)
                    {
                        for(int l = 0; l < HiddenLayer[k].InConnections.Count; l++)
                        {
                            HiddenLayer[k].InConnections[l].setWeight(HiddenLayer[k].InConnections[l].getWeight() + (eta * HiddenLayer[k].InConnections[l].LeftNeuron.getOutputValue() * HiddenLayer[k].getDeltaWeight()));
                            //Console.Write("w(" + neuronCount + ", " + connectionCount + ") = " + connection.getWeight() + " ");
                        }


                        HiddenLayer[k].BiasConnection.setWeight(HiddenLayer[k].BiasConnection.getWeight() + (eta * HiddenLayer[k].getDeltaWeight()));
                        //Console.Write("\n ");
                    }
                    #endregion


                    #region error gucci
                    //errorGucci = true;
                    //foreach(Connection inConnection in OutputNeuron.InConnections)
                    //{
                    //    if(inConnection.DeltaDiff > minErrorCondition)
                    //    {
                    //        errorGucci = false;
                    //        break;
                    //    }
                    //}

                    //    if (errorGucci) { 
                    //        foreach(Neuron n in HiddenLayer)
                    //        {
                    //            if (errorGucci)
                    //            {
                    //                foreach (Connection c in n.InConnections)
                    //                {
                    //                    if (c.DeltaDiff > minErrorCondition)
                    //                    {
                    //                        errorGucci = false;
                    //                        break;
                    //                    }
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                    #endregion
                }
                //Console.WriteLine("Passes = " + Passes);
                Console.WriteLine("Error squared = "+ errorSquared);
                if(errorSquared > prevErrorSquared)
                    Console.WriteLine("error increasing"); 

                Passes++;

                if (Passes == maxPasses)
                    Console.WriteLine("max passes");
                else if (errorSquared < minErrorCondition)
                    Console.WriteLine("error square good");

            }

            printWeights();


            int errors = 0;
            foreach(Element test in testingData)
            {
                setInputNeuronValues(test, dataSelector);
                //set the hidden layer values based on the weights of connections and the value of the input nodes that go into it.
                for (int i = 0; i < HiddenLayer.Count; i++)
                {
                    HiddenLayer[i].calculateOutputValue();
                }

                OutputNeuron.calculateOutputValue();
                int expectedLabel = test.Label;
                int outputLabel = (OutputNeuron.getOutputValue() > .5) ? 1 : 0;
                Console.WriteLine("Actual output = " + OutputNeuron.getOutputValue());
                if(expectedLabel != outputLabel)
                {
                    errors++;
                }
            }
            Console.WriteLine("Errors = " + errors);
            Console.ReadKey();
        }

        private static void printWeights()
        {
            StringBuilder sb = new StringBuilder();
            int neuronCount = 0;
            Console.WriteLine("HiddenLayer Weights");
            foreach(Neuron hiddenN in HiddenLayer)
            {
                int connectionCount1 = 0;
                foreach(Connection c in hiddenN.InConnections)
                {
                    Console.Write("w(" + neuronCount + ", " + connectionCount1 + ") = " + c.getWeight() + " ");
                    connectionCount1++;
                }
                Console.Write("\n");

                neuronCount++;
            }
            Console.WriteLine("OutputLayer Weights");

            int connectionCount = 0;
            foreach (Connection c in OutputNeuron.InConnections)
            {
                Console.Write("w(" + neuronCount + ", " + connectionCount + ") = " + c.getWeight() + " ");
                connectionCount++;
            }
        }

        private static void setInputNeuronValues(Element trial, int dataSelector)
        {
            if(dataSelector == 1)
            {
                setMonksInputNeuronValues(trial);
            }
            else if(dataSelector == 2)
            {
                setVoteInputNeuronValues(trial);
            }
            else if(dataSelector == 3)
            {
                setTicTacInputNeuronValues(trial);
            }
            
        }

        private static void setTicTacInputNeuronValues(Element trial)
        {
            int counter = 0;
            foreach (int attribute in trial.Attributes)
            {
                if (attribute == 0)
                {
                    InputLayer[counter].setOutputValue(0);
                    InputLayer[counter + 1].setOutputValue(0);
                    counter += 2;
                }
                else if (attribute == 1)
                {
                    InputLayer[counter].setOutputValue(1);
                    InputLayer[counter + 1].setOutputValue(0);
                    counter += 2;
                }
                else if (attribute == 2)
                {
                    InputLayer[counter].setOutputValue(0);
                    InputLayer[counter + 1].setOutputValue(1);
                    counter += 2;
                }
            }
        }

        private static void setPokerInputNeuronValues(Element trial)
        {
            int attributeCount = 0;
            int neuronCount = 0;
            foreach(int attribueValue in trial.Attributes)
            {
                if(attributeCount % 2 == 0)
                {
                    if(attribueValue == 1)
                    {
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                    }
                    else if (attribueValue == 2)
                    {
                        InputLayer[neuronCount].setOutputValue(1);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                    }
                    else if (attribueValue == 3)
                    {
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(1);
                        neuronCount++;
                    }
                    else if (attribueValue == 4)
                    {
                        InputLayer[neuronCount].setOutputValue(1);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(1);
                        neuronCount++;
                    }
                }
                else
                {
                    if (attribueValue == 1)
                    {
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                    }
                    else if (attribueValue == 2)
                    {
                        InputLayer[neuronCount].setOutputValue(1);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                    }
                    else if (attribueValue == 3)
                    {
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(1);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                    }
                    else if (attribueValue == 4)
                    {
                        InputLayer[neuronCount].setOutputValue(1);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(1);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                    }
                    else if (attribueValue == 5)
                    {
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(1);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                    }
                    else if (attribueValue == 6)
                    {
                        InputLayer[neuronCount].setOutputValue(1);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(1);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                    }
                    else if (attribueValue == 7)
                    {
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(1);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(1);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                    }
                    else if (attribueValue == 8)
                    {
                        InputLayer[neuronCount].setOutputValue(1);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(1);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(1);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                    }
                    else if (attribueValue == 9)
                    {
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(1);
                        neuronCount++;
                    }
                    else if (attribueValue == 10)
                    {
                        InputLayer[neuronCount].setOutputValue(1);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(1);
                        neuronCount++;
                    }
                    else if (attribueValue == 11)
                    {
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(1);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(1);
                        neuronCount++;
                    }
                    else if (attribueValue == 12)
                    {
                        InputLayer[neuronCount].setOutputValue(1);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(1);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(1);
                        neuronCount++;
                    }
                    else if (attribueValue == 13)
                    {
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(0);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(1);
                        neuronCount++;
                        InputLayer[neuronCount].setOutputValue(1);
                        neuronCount++;
                    }
                }
                attributeCount++;
            }
        }

        private static void setMonksInputNeuronValues(Element trial)
        {
            if(trial.Attributes[0] == 1)
            {
                InputLayer[0].setOutputValue(0);
                InputLayer[1].setOutputValue(0);
            }
            else if (trial.Attributes[0] == 2)
            {
                InputLayer[0].setOutputValue(1);
                InputLayer[1].setOutputValue(0);
            }
            else if (trial.Attributes[0] == 3)
            {
                InputLayer[0].setOutputValue(0);
                InputLayer[1].setOutputValue(1);
            }

            if (trial.Attributes[1] == 1)
            {
                InputLayer[2].setOutputValue(0);
                InputLayer[3].setOutputValue(0);
            }
            else if (trial.Attributes[1] == 2)
            {
                InputLayer[2].setOutputValue(1);
                InputLayer[3].setOutputValue(0);
            }
            else if (trial.Attributes[1] == 3)
            {
                InputLayer[2].setOutputValue(0);
                InputLayer[3].setOutputValue(1);
            }

            if (trial.Attributes[2] == 1)
            {
                InputLayer[4].setOutputValue(0);
            }
            else if (trial.Attributes[2] == 2)
            {
                InputLayer[4].setOutputValue(1);
            }

            if (trial.Attributes[3] == 1)
            {
                InputLayer[5].setOutputValue(0);
                InputLayer[6].setOutputValue(0);
            }
            else if (trial.Attributes[3] == 2)
            {
                InputLayer[5].setOutputValue(1);
                InputLayer[6].setOutputValue(0);
            }
            else if (trial.Attributes[3] == 3)
            {
                InputLayer[5].setOutputValue(0);
                InputLayer[6].setOutputValue(1);
            }


            if (trial.Attributes[4] == 1)
            {
                InputLayer[7].setOutputValue(0);
                InputLayer[8].setOutputValue(0);
            }
            else if (trial.Attributes[4] == 2)
            {
                InputLayer[7].setOutputValue(1);
                InputLayer[8].setOutputValue(0);
            }
            else if (trial.Attributes[4] == 3)
            {
                InputLayer[7].setOutputValue(0);
                InputLayer[8].setOutputValue(1);
            }
            else if (trial.Attributes[4] == 3)
            {
                InputLayer[7].setOutputValue(1);
                InputLayer[8].setOutputValue(1);
            }

            if (trial.Attributes[5] == 1)
            {
                InputLayer[9].setOutputValue(0);
            }
            else if (trial.Attributes[5] == 2)
            {
                InputLayer[9].setOutputValue(1);
            }


        }

        private static void setVoteInputNeuronValues(Element trial)
        {
            int counter = 0;
            foreach(int attribute in trial.Attributes)
            {
                if (attribute == 0)
                {
                    InputLayer[counter].setOutputValue(0);
                    InputLayer[counter + 1].setOutputValue(0);
                    counter += 2;
                }
                else if(attribute == 1)
                {
                    InputLayer[counter].setOutputValue(1);
                    InputLayer[counter + 1].setOutputValue(0);
                    counter += 2;
                }
                else if (attribute == 2)
                {
                    InputLayer[counter].setOutputValue(0);
                    InputLayer[counter + 1].setOutputValue(1);
                    counter += 2;
                }
            }
        }
       
        private static List<Neuron> createInputLayer(int dataSelector)
        {
            if (dataSelector == 1)
            {
                return createMonksInputLayer();
            }
            else if (dataSelector == 2)
            {
                return createVotingInputLayer();
            }
            else if (dataSelector == 3)
            {
                return createTicTacInputLayer();
            }
            else
                return null;
        }

        private static List<Neuron> createTicTacInputLayer()
        {
            List<Neuron> InLayer = new List<Neuron>();
            for (int i = 0; i < 9; i++)
            {
                InLayer.Add(new Neuron());
                InLayer.Add(new Neuron());      //two neurons for every input attribute
            }
            return InLayer;
        }

        private static List<Neuron> createPokerInputLayer()
        {
            List<Neuron> InLayer = new List<Neuron>();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    InLayer.Add(new Neuron());
                }
                for (int k = 0; k < 4; k++)
                {
                    InLayer.Add(new Neuron());
                }
            }
            return InLayer;
        }

        private static List<Neuron> createMonksInputLayer()
        {
            List<Neuron> inlayer = new List<Neuron>();
            inlayer.Add(new Neuron());
            inlayer.Add(new Neuron());
            inlayer.Add(new Neuron());
            inlayer.Add(new Neuron());
            inlayer.Add(new Neuron());
            inlayer.Add(new Neuron());
            inlayer.Add(new Neuron());
            inlayer.Add(new Neuron());
            inlayer.Add(new Neuron());
            inlayer.Add(new Neuron());
            return inlayer;
        }

        private static List<Neuron> createVotingInputLayer()
        {
            List<Neuron> InLayer = new List<Neuron>();
            for(int i = 0; i<16; i++)
            {
                InLayer.Add(new Neuron());
                InLayer.Add(new Neuron());      //two neurons for every input attribute
            }
            return InLayer;
        }
        private static List<Neuron> createHiddenLayer(int dataSelector)
        {
            if(dataSelector == 1)
            {
                return createMonkHiddenLayer();
            }
            else if (dataSelector == 2)
            {
                return createVotingHiddenLayer();
            }
            else if(dataSelector == 3)
            {
                return creatTicTacHiddenLayer();
            }
            else
                return null;
        }

        private static List<Neuron> creatTicTacHiddenLayer()
        {
            List<Neuron> InLayer = new List<Neuron>();
            for (int i = 0; i < 4; i++)
            {
                InLayer.Add(new Neuron());
            }
            return InLayer;
        }

        private static List<Neuron> createPokerHiddenLayer()
        {
            List<Neuron> InLayer = new List<Neuron>();
            for(int i = 0; i < 10; i++)
            {
                InLayer.Add(new Neuron());
            }
            return InLayer;
        }

        private static List<Neuron> createMonkHiddenLayer()
        {
            List<Neuron> inlayer = new List<Neuron>();
            inlayer.Add(new Neuron());
            inlayer.Add(new Neuron());
            return inlayer;
        }

        private static List<Neuron> createVotingHiddenLayer()
        {
            List<Neuron> HiddenLayer = new List<Neuron>();
            for (int i = 0; i < 8; i++)
            {
                HiddenLayer.Add(new Neuron());
            }
            return HiddenLayer;
        }

    }
}
