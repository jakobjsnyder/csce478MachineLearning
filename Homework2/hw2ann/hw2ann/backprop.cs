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
            List<Element> fullVoting = Parser.parseData(2);
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

    }
}
