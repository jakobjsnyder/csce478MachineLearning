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
        static double eta = 0.5;
        static int maxPasses = 1000;
        static double minErrorCondition = .0001;
        static int Passes = 0;
        static bool errorGucci = false;
        public static List<Neuron> InputLayer = new List<Neuron>();
        public static List<Neuron> HiddenLayer = new List<Neuron>();
        public static Neuron OutputNeuron = new Neuron();
        public static Neuron BiasNeuron = new Neuron();

        public static void Main(string[] args)
        {
            #region Parse Voting
            int dataSelector = 2;
            List<Element> fullVoting = Parser.parseData(dataSelector);
            //split into training and testing data
            List<Element> trainingData = new List<Element>();
            List<Element> testingData = new List<Element>();
            List<int> testingInts = new List<int>();
            Random rnd = new Random();
            for (int i = 0; i <= 30; i++)
            {
                testingInts.Add(rnd.Next(fullVoting.Count));
            }
            for (int j = 0; j < fullVoting.Count; j++)
            {
                if (testingInts.Contains(j))
                {
                    testingData.Add(fullVoting[j]);
                }
                else
                {
                    trainingData.Add(fullVoting[j]);
                }
            }
            #endregion
            InputLayer = createInputLayer(2);
            HiddenLayer = createHiddenLayer(2);
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


            double errorSquared = 10.0;
            while( Passes < maxPasses && errorSquared > .0001)
            {
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
                    //find the deltas
                    double deltaWD = OutputNeuron.getOutputValue() * (trial.Label - OutputNeuron.getOutputValue()) * (OutputNeuron.getBias() - OutputNeuron.getOutputValue());
                    OutputNeuron.setDeltaWeight(deltaWD);

                    // find deltas for each hidden neuron
                    for(int i = 0; i< HiddenLayer.Count; i++)
                    {
                        double deltaWC = HiddenLayer[i].getOutputValue() * (trial.Label - HiddenLayer[i].getOutputValue()) * deltaWD * OutputNeuron.InConnections[i].getWeight();
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
                Passes++;
            }

            printWeights();


            int errors = 0;
            foreach(Element test in testingData)
            {
                setInputNeuronValues(test, 2);
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
            if(dataSelector == 2)
            {
                setVoteInputNeuronValues(trial);
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
            if (dataSelector == 2)
            {
                return createVotingInputLayer();

            }
            else
                return null;
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
            if (dataSelector == 2)
            {
                return createVotingHiddenLayer();

            }
            else
                return null;
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
