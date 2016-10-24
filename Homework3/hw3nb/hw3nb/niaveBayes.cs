using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3nb
{
    class NiaveBayes
    {
        static void Main(string[] args)
        {
            int dataSelector = 2;


            List<Element> fullData = Parser.parseData(dataSelector);
            //split into training and testing data
            List<Element> trainingData = new List<Element>();
            List<Element> testingData = new List<Element>();

            #region fill lists
            List<int> testingInts = new List<int>();
            Random rnd = new Random();
            while (testingInts.Count != 30)
            {
                int test = rnd.Next(fullData.Count);
                if (!testingInts.Contains(test))
                    testingInts.Add(test);
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


            int totalPositive = trainingData.Where(e => e.Label == 1).Count();
            int totalNegative = trainingData.Where(e => e.Label == 0).Count();
            int numTrainingPoints = trainingData.Count();

            if (totalPositive + totalNegative != numTrainingPoints)
                throw new Exception("label count mismatch");

            double Pp = totalPositive / numTrainingPoints;
            double Pn = totalNegative / numTrainingPoints;

            int numAttributes = trainingData[0].Attributes.Count();

            List<double> PpAttribute = new List<double>();
            List<double> PnAttribute = new List<double>();

            for(int i = 0; i < numAttributes; i++)
            {
                ComplexCounter complexCounter = new ComplexCounter();
                for(int j = 0; j < numTrainingPoints; j++)
                {
                    int currentAttriValue = trainingData[j].Attributes[i];
                    int currentLabel = trainingData[j].Label;
                    bool contains = complexCounter.Value.Contains(currentAttriValue);
                    if (contains)
                    {
                        bool containsWithLabel = false;
                        for (int k = 0; k < complexCounter.Value.Count(); k++)
                        {
                            if(complexCounter.Value[k] == currentAttriValue && complexCounter.Label[k] == currentLabel)
                            {
                                containsWithLabel = true;
                                complexCounter.Count[k]++;
                                break;
                            }
                        }
                        if (!containsWithLabel)
                        {
                            complexCounter.Count.Add(1);
                            complexCounter.Label.Add(currentLabel);
                            complexCounter.Value.Add(currentAttriValue);
                        }
                    }
                    else
                    {
                        complexCounter.Count.Add(1);
                        complexCounter.Label.Add(currentLabel);
                        complexCounter.Value.Add(currentAttriValue);
                    }



                }

                for (int l = 0; l < complexCounter.Value.Count(); l++)
                {
                    if(complexCounter.Label[l] == 1)//positive
                    {
                        PpAttribute.Add(complexCounter.Count[l] / totalPositive);
                    }
                    else//negative
                    {
                        PnAttribute.Add(complexCounter.Count[l] / totalNegative);
                    }
                }
            }
        }
    }
}
