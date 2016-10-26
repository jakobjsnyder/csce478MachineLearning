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


           


            double Pp = totalPositive * 1.0 / numTrainingPoints;
            double Pn = totalNegative * 1.0 / numTrainingPoints;

            int numAttributes = trainingData[0].Attributes.Count();


            if (dataSelector == 2)
            {
                int[] countHandicapped = new int[6];
                int[] countWater = new int[6];
                int[] countAdoption = new int[6];
                int[] countPhysiciian = new int[6];
                int[] countSalvador = new int[6];
                int[] countReligious = new int[6];
                int[] countSatellite = new int[6];
                int[] countNicaraguan = new int[6];
                int[] countMx = new int[6];
                int[] countImmigration = new int[6];
                int[] countSynfules = new int[6];
                int[] countEducation = new int[6];
                int[] countSuperfund = new int[6];
                int[] countCrime = new int[6];
                int[] countDuty = new int[6];
                int[] countExport = new int[6];

                for (int i = 0; i < numTrainingPoints; i++)
                {
                    for (int j = 0; j < numAttributes; j++)
                    {
                       if(j == 0)
                       {
                            if(trainingData[i].Label == 0)
                            {
                                if(trainingData[i].Attributes[j] == 0)
                                {
                                    countHandicapped[0]++;
                                }
                                else if(trainingData[i].Attributes[j] == 1)
                                {
                                    countHandicapped[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countHandicapped[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countHandicapped[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countHandicapped[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countHandicapped[5]++;
                                }
                            }
                        }
                        if (j == 1)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countWater[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countWater[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countWater[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countWater[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countWater[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countWater[5]++;
                                }
                            }
                        }
                        if (j == 2)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countAdoption[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countAdoption[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countAdoption[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countAdoption[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countAdoption[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countAdoption[5]++;
                                }
                            }
                        }
                        if (j == 3)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countPhysiciian[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countPhysiciian[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countPhysiciian[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countPhysiciian[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countPhysiciian[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countPhysiciian[5]++;
                                }
                            }
                        }
                        if (j == 4)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countSalvador[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countSalvador[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countSalvador[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countSalvador[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countSalvador[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countSalvador[5]++;
                                }
                            }
                        }
                        if (j == 5)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countReligious[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countReligious[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countReligious[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countReligious[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countReligious[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countReligious[5]++;
                                }
                            }
                        }
                        if (j == 6)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countSatellite[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countSatellite[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countSatellite[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countSatellite[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countSatellite[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countSatellite[5]++;
                                }
                            }
                        }
                        if (j == 7)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countNicaraguan[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countNicaraguan[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countNicaraguan[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countNicaraguan[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countNicaraguan[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countNicaraguan[5]++;
                                }
                            }
                        }
                        if (j == 8)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countMx[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countMx[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countMx[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countMx[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countMx[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countMx[5]++;
                                }
                            }
                        }
                        if (j == 9)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countImmigration[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countImmigration[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countImmigration[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countImmigration[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countImmigration[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countImmigration[5]++;
                                }
                            }
                        }
                        if (j == 10)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countSynfules[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countSynfules[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countSynfules[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countSynfules[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countSynfules[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countSynfules[5]++;
                                }
                            }
                        }
                        if (j == 11)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countEducation[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countEducation[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countEducation[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countEducation[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countEducation[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countEducation[5]++;
                                }
                            }
                        }
                        if (j == 12)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countSuperfund[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countSuperfund[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countSuperfund[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countSuperfund[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countSuperfund[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countSuperfund[5]++;
                                }
                            }
                        }
                        if (j == 13)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countCrime[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countCrime[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countCrime[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countCrime[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countCrime[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countCrime[5]++;
                                }
                            }
                        }
                        if (j == 14)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countDuty[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countDuty[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countDuty[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countDuty[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countDuty[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countDuty[5]++;
                                }
                            }
                        }
                        if (j == 15)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countExport[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countExport[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countExport[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countExport[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countExport[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countExport[5]++;
                                }
                            }
                        }
                        

                    }
                }

                double[] pHandicapped = new double[6];
                pHandicapped[0] = countHandicapped[0] * 1.0 / totalNegative;
                pHandicapped[1] = countHandicapped[1] * 1.0 / totalNegative;
                pHandicapped[2] = countHandicapped[2] * 1.0 / totalNegative;
                pHandicapped[3] = countHandicapped[3] * 1.0 / totalPositive;
                pHandicapped[4] = countHandicapped[4] * 1.0 / totalPositive;
                pHandicapped[5] = countHandicapped[5] * 1.0 / totalPositive;
                double[] pWater = new double[6];
                pWater[0] = countHandicapped[0] * 1.0 / totalNegative;
                pWater[1] = countHandicapped[1] * 1.0 / totalNegative;
                pWater[2] = countHandicapped[2] * 1.0 / totalNegative;
                pWater[3] = countHandicapped[3] * 1.0 / totalPositive;
                pWater[4] = countHandicapped[4] * 1.0 / totalPositive;
                pWater[5] = countHandicapped[5] * 1.0 / totalPositive;
                double[] pAdoption = new double[6];
                pAdoption[0] = countHandicapped[0] * 1.0 / totalNegative;
                pAdoption[1] = countHandicapped[1] * 1.0 / totalNegative;
                pAdoption[2] = countHandicapped[2] * 1.0 / totalNegative;
                pAdoption[3] = countHandicapped[3] * 1.0 / totalPositive;
                pAdoption[4] = countHandicapped[4] * 1.0 / totalPositive;
                pAdoption[5] = countHandicapped[5] * 1.0 / totalPositive;
                double[] pPhysiciian = new double[6];
                pPhysiciian[0] = countHandicapped[0] * 1.0 / totalNegative;
                pPhysiciian[1] = countHandicapped[1] * 1.0 / totalNegative;
                pPhysiciian[2] = countHandicapped[2] * 1.0 / totalNegative;
                pPhysiciian[3] = countHandicapped[3] * 1.0 / totalPositive;
                pPhysiciian[4] = countHandicapped[4] * 1.0 / totalPositive;
                pPhysiciian[5] = countHandicapped[5] * 1.0 / totalPositive;
                double[] pSalvador = new double[6];
                pSalvador[0] = countHandicapped[0] * 1.0 / totalNegative;
                pSalvador[1] = countHandicapped[1] * 1.0 / totalNegative;
                pSalvador[2] = countHandicapped[2] * 1.0 / totalNegative;
                pSalvador[3] = countHandicapped[3] * 1.0 / totalPositive;
                pSalvador[4] = countHandicapped[4] * 1.0 / totalPositive;
                pSalvador[5] = countHandicapped[5] * 1.0 / totalPositive;
                double[] pReligious = new double[6];
                pReligious[0] = countHandicapped[0] * 1.0 / totalNegative;
                pReligious[1] = countHandicapped[1] * 1.0 / totalNegative;
                pReligious[2] = countHandicapped[2] * 1.0 / totalNegative;
                pReligious[3] = countHandicapped[3] * 1.0 / totalPositive;
                pReligious[4] = countHandicapped[4] * 1.0 / totalPositive;
                pReligious[5] = countHandicapped[5] * 1.0 / totalPositive;
                double[] pSatellite = new double[6];
                pSatellite[0] = countHandicapped[0] * 1.0 / totalNegative;
                pSatellite[1] = countHandicapped[1] * 1.0 / totalNegative;
                pSatellite[2] = countHandicapped[2] * 1.0 / totalNegative;
                pSatellite[3] = countHandicapped[3] * 1.0 / totalPositive;
                pSatellite[4] = countHandicapped[4] * 1.0 / totalPositive;
                pSatellite[5] = countHandicapped[5] * 1.0 / totalPositive;
                double[] pNicaraguan = new double[6];
                pNicaraguan[0] = countHandicapped[0] * 1.0 / totalNegative;
                pNicaraguan[1] = countHandicapped[1] * 1.0 / totalNegative;
                pNicaraguan[2] = countHandicapped[2] * 1.0 / totalNegative;
                pNicaraguan[3] = countHandicapped[3] * 1.0 / totalPositive;
                pNicaraguan[4] = countHandicapped[4] * 1.0 / totalPositive;
                pNicaraguan[5] = countHandicapped[5] * 1.0 / totalPositive;
                double[] pMx = new double[6];
                pMx[0] = countHandicapped[0] * 1.0 / totalNegative;
                pMx[1] = countHandicapped[1] * 1.0 / totalNegative;
                pMx[2] = countHandicapped[2] * 1.0 / totalNegative;
                pMx[3] = countHandicapped[3] * 1.0 / totalPositive;
                pMx[4] = countHandicapped[4] * 1.0 / totalPositive;
                pMx[5] = countHandicapped[5] * 1.0 / totalPositive;
                double[] pImmigration = new double[6];
                pImmigration[0] = countHandicapped[0] * 1.0 / totalNegative;
                pImmigration[1] = countHandicapped[1] * 1.0 / totalNegative;
                pImmigration[2] = countHandicapped[2] * 1.0 / totalNegative;
                pImmigration[3] = countHandicapped[3] * 1.0 / totalPositive;
                pImmigration[4] = countHandicapped[4] * 1.0 / totalPositive;
                pImmigration[5] = countHandicapped[5] * 1.0 / totalPositive;
                double[] pSynfules = new double[6];
                pSynfules[0] = countHandicapped[0] * 1.0 / totalNegative;
                pSynfules[1] = countHandicapped[1] * 1.0 / totalNegative;
                pSynfules[2] = countHandicapped[2] * 1.0 / totalNegative;
                pSynfules[3] = countHandicapped[3] * 1.0 / totalPositive;
                pSynfules[4] = countHandicapped[4] * 1.0 / totalPositive;
                pSynfules[5] = countHandicapped[5] * 1.0 / totalPositive;
                double[] pEducation = new double[6];
                pEducation[0] = countHandicapped[0] * 1.0 / totalNegative;
                pEducation[1] = countHandicapped[1] * 1.0 / totalNegative;
                pEducation[2] = countHandicapped[2] * 1.0 / totalNegative;
                pEducation[3] = countHandicapped[3] * 1.0 / totalPositive;
                pEducation[4] = countHandicapped[4] * 1.0 / totalPositive;
                pEducation[5] = countHandicapped[5] * 1.0 / totalPositive;
                double[] pSuperfund = new double[6];
                pSuperfund[0] = countHandicapped[0] * 1.0 / totalNegative;
                pSuperfund[1] = countHandicapped[1] * 1.0 / totalNegative;
                pSuperfund[2] = countHandicapped[2] * 1.0 / totalNegative;
                pSuperfund[3] = countHandicapped[3] * 1.0 / totalPositive;
                pSuperfund[4] = countHandicapped[4] * 1.0 / totalPositive;
                pSuperfund[5] = countHandicapped[5] * 1.0 / totalPositive;
                double[] pCrime = new double[6];
                pCrime[0] = countHandicapped[0] * 1.0 / totalNegative;
                pCrime[1] = countHandicapped[1] * 1.0 / totalNegative;
                pCrime[2] = countHandicapped[2] * 1.0 / totalNegative;
                pCrime[3] = countHandicapped[3] * 1.0 / totalPositive;
                pCrime[4] = countHandicapped[4] * 1.0 / totalPositive;
                pCrime[5] = countHandicapped[5] * 1.0 / totalPositive;
                double[] pDuty = new double[6];
                pDuty[0] = countHandicapped[0] * 1.0 / totalNegative;
                pDuty[1] = countHandicapped[1] * 1.0 / totalNegative;
                pDuty[2] = countHandicapped[2] * 1.0 / totalNegative;
                pDuty[3] = countHandicapped[3] * 1.0 / totalPositive;
                pDuty[4] = countHandicapped[4] * 1.0 / totalPositive;
                pDuty[5] = countHandicapped[5] * 1.0 / totalPositive;
                double[] pExport = new double[6];
                pExport[0] = countHandicapped[0] * 1.0 / totalNegative;
                pExport[1] = countHandicapped[1] * 1.0 / totalNegative;
                pExport[2] = countHandicapped[2] * 1.0 / totalNegative;
                pExport[3] = countHandicapped[3] * 1.0 / totalPositive;
                pExport[4] = countHandicapped[4] * 1.0 / totalPositive;
                pExport[5] = countHandicapped[5] * 1.0 / totalPositive;


            }



            #region worthless
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
                        PpAttribute.Add(complexCounter.Count[l] * 1.0 / totalPositive);
                    }
                    else//negative
                    {
                        PnAttribute.Add(complexCounter.Count[l] * 1.0/ totalNegative);
                    }
                }
                
            }
            Console.WriteLine("Positives");
            foreach (var item in PpAttribute)
                Console.WriteLine(item);
            Console.WriteLine("Negatives");
            foreach (var item in PnAttribute)
                Console.WriteLine(item);
            Console.ReadKey();
            #endregion
        }
    }
}
