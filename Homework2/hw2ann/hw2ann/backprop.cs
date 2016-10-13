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
        static double eta = 0.1;

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
            List<Neuron> InputLayer = createInputLayer(2);
            List<Neuron> HiddenLayer = createHiddenLayer(2);
            Neuron OutputNeuron = new Neuron();

            foreach(Neuron HiddenNeuron in HiddenLayer)     //create network structure
            {
                foreach(Neuron InputNeuron in InputLayer)
                {
                    HiddenNeuron.addInConnection(InputNeuron);
                }
                OutputNeuron.addInConnection(HiddenNeuron);
            }
            int maxPasses = 20000;
            double minErrorCondition = .00001;
            int Passes = 0;
            int Error = 1000;

            while(Error>minErrorCondition && Passes < maxPasses)
            {
            }



            Console.ReadKey();
        }

        private static int roundOutput(double squasherOut)
        {
            return (squasherOut > .5) ? 1 : 0;
        }

        private static double squasher(double sum)
        {
            return 1 / (1 + Math.Pow(Math.E, -sum));
        }

        private static double wTplus1(double wT, double r, double y, double x)
        {
            double delta = (r - y) * y * (1 - y) * x;
            return wT + eta * delta * x;
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
            for (int i = 0; i < 16; i++)
            {
                HiddenLayer.Add(new Neuron());
            }
            return HiddenLayer;
        }

    }
}
