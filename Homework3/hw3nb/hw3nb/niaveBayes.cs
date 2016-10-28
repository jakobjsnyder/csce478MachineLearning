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
            int dataSelector = 3;


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

            List<int> calculatedLabels = new List<int>();
            int numErrors = 0;
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
                        if (j == 0)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countHandicapped[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
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
                pWater[0] = countWater[0] * 1.0 / totalNegative;
                pWater[1] = countWater[1] * 1.0 / totalNegative;
                pWater[2] = countWater[2] * 1.0 / totalNegative;
                pWater[3] = countWater[3] * 1.0 / totalPositive;
                pWater[4] = countWater[4] * 1.0 / totalPositive;
                pWater[5] = countWater[5] * 1.0 / totalPositive;
                double[] pAdoption = new double[6];
                pAdoption[0] = countAdoption[0] * 1.0 / totalNegative;
                pAdoption[1] = countAdoption[1] * 1.0 / totalNegative;
                pAdoption[2] = countAdoption[2] * 1.0 / totalNegative;
                pAdoption[3] = countAdoption[3] * 1.0 / totalPositive;
                pAdoption[4] = countAdoption[4] * 1.0 / totalPositive;
                pAdoption[5] = countAdoption[5] * 1.0 / totalPositive;
                double[] pPhysiciian = new double[6];
                pPhysiciian[0] = countPhysiciian[0] * 1.0 / totalNegative;
                pPhysiciian[1] = countPhysiciian[1] * 1.0 / totalNegative;
                pPhysiciian[2] = countPhysiciian[2] * 1.0 / totalNegative;
                pPhysiciian[3] = countPhysiciian[3] * 1.0 / totalPositive;
                pPhysiciian[4] = countPhysiciian[4] * 1.0 / totalPositive;
                pPhysiciian[5] = countPhysiciian[5] * 1.0 / totalPositive;
                double[] pSalvador = new double[6];
                pSalvador[0] = countSalvador[0] * 1.0 / totalNegative;
                pSalvador[1] = countSalvador[1] * 1.0 / totalNegative;
                pSalvador[2] = countSalvador[2] * 1.0 / totalNegative;
                pSalvador[3] = countSalvador[3] * 1.0 / totalPositive;
                pSalvador[4] = countSalvador[4] * 1.0 / totalPositive;
                pSalvador[5] = countSalvador[5] * 1.0 / totalPositive;
                double[] pReligious = new double[6];
                pReligious[0] = countReligious[0] * 1.0 / totalNegative;
                pReligious[1] = countReligious[1] * 1.0 / totalNegative;
                pReligious[2] = countReligious[2] * 1.0 / totalNegative;
                pReligious[3] = countReligious[3] * 1.0 / totalPositive;
                pReligious[4] = countReligious[4] * 1.0 / totalPositive;
                pReligious[5] = countReligious[5] * 1.0 / totalPositive;
                double[] pSatellite = new double[6];
                pSatellite[0] = countSatellite[0] * 1.0 / totalNegative;
                pSatellite[1] = countSatellite[1] * 1.0 / totalNegative;
                pSatellite[2] = countSatellite[2] * 1.0 / totalNegative;
                pSatellite[3] = countSatellite[3] * 1.0 / totalPositive;
                pSatellite[4] = countSatellite[4] * 1.0 / totalPositive;
                pSatellite[5] = countSatellite[5] * 1.0 / totalPositive;
                double[] pNicaraguan = new double[6];
                pNicaraguan[0] = countNicaraguan[0] * 1.0 / totalNegative;
                pNicaraguan[1] = countNicaraguan[1] * 1.0 / totalNegative;
                pNicaraguan[2] = countNicaraguan[2] * 1.0 / totalNegative;
                pNicaraguan[3] = countNicaraguan[3] * 1.0 / totalPositive;
                pNicaraguan[4] = countNicaraguan[4] * 1.0 / totalPositive;
                pNicaraguan[5] = countNicaraguan[5] * 1.0 / totalPositive;
                double[] pMx = new double[6];
                pMx[0] = countMx[0] * 1.0 / totalNegative;
                pMx[1] = countMx[1] * 1.0 / totalNegative;
                pMx[2] = countMx[2] * 1.0 / totalNegative;
                pMx[3] = countMx[3] * 1.0 / totalPositive;
                pMx[4] = countMx[4] * 1.0 / totalPositive;
                pMx[5] = countMx[5] * 1.0 / totalPositive;
                double[] pImmigration = new double[6];
                pImmigration[0] = countImmigration[0] * 1.0 / totalNegative;
                pImmigration[1] = countImmigration[1] * 1.0 / totalNegative;
                pImmigration[2] = countImmigration[2] * 1.0 / totalNegative;
                pImmigration[3] = countImmigration[3] * 1.0 / totalPositive;
                pImmigration[4] = countImmigration[4] * 1.0 / totalPositive;
                pImmigration[5] = countImmigration[5] * 1.0 / totalPositive;
                double[] pSynfules = new double[6];
                pSynfules[0] = countSynfules[0] * 1.0 / totalNegative;
                pSynfules[1] = countSynfules[1] * 1.0 / totalNegative;
                pSynfules[2] = countSynfules[2] * 1.0 / totalNegative;
                pSynfules[3] = countSynfules[3] * 1.0 / totalPositive;
                pSynfules[4] = countSynfules[4] * 1.0 / totalPositive;
                pSynfules[5] = countSynfules[5] * 1.0 / totalPositive;
                double[] pEducation = new double[6];
                pEducation[0] = countEducation[0] * 1.0 / totalNegative;
                pEducation[1] = countEducation[1] * 1.0 / totalNegative;
                pEducation[2] = countEducation[2] * 1.0 / totalNegative;
                pEducation[3] = countEducation[3] * 1.0 / totalPositive;
                pEducation[4] = countEducation[4] * 1.0 / totalPositive;
                pEducation[5] = countEducation[5] * 1.0 / totalPositive;
                double[] pSuperfund = new double[6];
                pSuperfund[0] = countSuperfund[0] * 1.0 / totalNegative;
                pSuperfund[1] = countSuperfund[1] * 1.0 / totalNegative;
                pSuperfund[2] = countSuperfund[2] * 1.0 / totalNegative;
                pSuperfund[3] = countSuperfund[3] * 1.0 / totalPositive;
                pSuperfund[4] = countSuperfund[4] * 1.0 / totalPositive;
                pSuperfund[5] = countSuperfund[5] * 1.0 / totalPositive;
                double[] pCrime = new double[6];
                pCrime[0] = countCrime[0] * 1.0 / totalNegative;
                pCrime[1] = countCrime[1] * 1.0 / totalNegative;
                pCrime[2] = countCrime[2] * 1.0 / totalNegative;
                pCrime[3] = countCrime[3] * 1.0 / totalPositive;
                pCrime[4] = countCrime[4] * 1.0 / totalPositive;
                pCrime[5] = countCrime[5] * 1.0 / totalPositive;
                double[] pDuty = new double[6];
                pDuty[0] = countDuty[0] * 1.0 / totalNegative;
                pDuty[1] = countDuty[1] * 1.0 / totalNegative;
                pDuty[2] = countDuty[2] * 1.0 / totalNegative;
                pDuty[3] = countDuty[3] * 1.0 / totalPositive;
                pDuty[4] = countDuty[4] * 1.0 / totalPositive;
                pDuty[5] = countDuty[5] * 1.0 / totalPositive;
                double[] pExport = new double[6];
                pExport[0] = countExport[0] * 1.0 / totalNegative;
                pExport[1] = countExport[1] * 1.0 / totalNegative;
                pExport[2] = countExport[2] * 1.0 / totalNegative;
                pExport[3] = countExport[3] * 1.0 / totalPositive;
                pExport[4] = countExport[4] * 1.0 / totalPositive;
                pExport[5] = countExport[5] * 1.0 / totalPositive;


                for (int i = 0; i < testingData.Count(); i++)
                {
                    double PpTest = Pp;
                    double PnTest = Pn;

                    if (testingData[i].Attributes[0] == 0)
                    {
                        PnTest *= pHandicapped[0];
                        PpTest *= pHandicapped[3];
                    }
                    else if (testingData[i].Attributes[0] == 1)
                    {
                        PnTest *= pHandicapped[1];
                        PpTest *= pHandicapped[4];
                    }
                    else if (testingData[i].Attributes[0] == 2)
                    {
                        PnTest *= pHandicapped[2];
                        PpTest *= pHandicapped[5];
                    }

                    if (testingData[i].Attributes[1] == 0)
                    {
                        PnTest *= pWater[0];
                        PpTest *= pWater[3];
                    }
                    else if (testingData[i].Attributes[1] == 1)
                    {
                        PnTest *= pWater[1];
                        PpTest *= pWater[4];
                    }
                    else if (testingData[i].Attributes[1] == 2)
                    {
                        PnTest *= pWater[2];
                        PpTest *= pWater[5];
                    }

                    if (testingData[i].Attributes[2] == 0)
                    {
                        PnTest *= pAdoption[0];
                        PpTest *= pAdoption[3];
                    }
                    else if (testingData[i].Attributes[2] == 1)
                    {
                        PnTest *= pAdoption[1];
                        PpTest *= pAdoption[4];
                    }
                    else if (testingData[i].Attributes[2] == 2)
                    {
                        PnTest *= pAdoption[2];
                        PpTest *= pAdoption[5];
                    }

                    if (testingData[i].Attributes[3] == 0)
                    {
                        PnTest *= pPhysiciian[0];
                        PpTest *= pPhysiciian[3];
                    }
                    else if (testingData[i].Attributes[3] == 1)
                    {
                        PnTest *= pPhysiciian[1];
                        PpTest *= pPhysiciian[4];
                    }
                    else if (testingData[i].Attributes[3] == 2)
                    {
                        PnTest *= pPhysiciian[2];
                        PpTest *= pPhysiciian[5];
                    }

                    if (testingData[i].Attributes[4] == 0)
                    {
                        PnTest *= pSalvador[0];
                        PpTest *= pSalvador[3];
                    }
                    else if (testingData[i].Attributes[4] == 1)
                    {
                        PnTest *= pSalvador[1];
                        PpTest *= pSalvador[4];
                    }
                    else if (testingData[i].Attributes[4] == 2)
                    {
                        PnTest *= pSalvador[2];
                        PpTest *= pSalvador[5];
                    }

                    if (testingData[i].Attributes[5] == 0)
                    {
                        PnTest *= pReligious[0];
                        PpTest *= pReligious[3];
                    }
                    else if (testingData[i].Attributes[5] == 1)
                    {
                        PnTest *= pReligious[1];
                        PpTest *= pReligious[4];
                    }
                    else if (testingData[i].Attributes[5] == 2)
                    {
                        PnTest *= pReligious[2];
                        PpTest *= pReligious[5];
                    }

                    if (testingData[i].Attributes[6] == 0)
                    {
                        PnTest *= pSatellite[0];
                        PpTest *= pSatellite[3];
                    }
                    else if (testingData[i].Attributes[6] == 1)
                    {
                        PnTest *= pSatellite[1];
                        PpTest *= pSatellite[4];
                    }
                    else if (testingData[i].Attributes[6] == 2)
                    {
                        PnTest *= pSatellite[2];
                        PpTest *= pSatellite[5];
                    }

                    if (testingData[i].Attributes[7] == 0)
                    {
                        PnTest *= pNicaraguan[0];
                        PpTest *= pNicaraguan[3];
                    }
                    else if (testingData[i].Attributes[7] == 1)
                    {
                        PnTest *= pNicaraguan[1];
                        PpTest *= pNicaraguan[4];
                    }
                    else if (testingData[i].Attributes[7] == 2)
                    {
                        PnTest *= pNicaraguan[2];
                        PpTest *= pNicaraguan[5];
                    }

                    if (testingData[i].Attributes[8] == 0)
                    {
                        PnTest *= pMx[0];
                        PpTest *= pMx[3];
                    }
                    else if (testingData[i].Attributes[8] == 1)
                    {
                        PnTest *= pMx[1];
                        PpTest *= pMx[4];
                    }
                    else if (testingData[i].Attributes[8] == 2)
                    {
                        PnTest *= pMx[2];
                        PpTest *= pMx[5];
                    }

                    if (testingData[i].Attributes[9] == 0)
                    {
                        PnTest *= pImmigration[0];
                        PpTest *= pImmigration[3];
                    }
                    else if (testingData[i].Attributes[9] == 1)
                    {
                        PnTest *= pImmigration[1];
                        PpTest *= pImmigration[4];
                    }
                    else if (testingData[i].Attributes[9] == 2)
                    {
                        PnTest *= pImmigration[2];
                        PpTest *= pImmigration[5];
                    }

                    if (testingData[i].Attributes[10] == 0)
                    {
                        PnTest *= pSynfules[0];
                        PpTest *= pSynfules[3];
                    }
                    else if (testingData[i].Attributes[10] == 1)
                    {
                        PnTest *= pSynfules[1];
                        PpTest *= pSynfules[4];
                    }
                    else if (testingData[i].Attributes[10] == 2)
                    {
                        PnTest *= pSynfules[2];
                        PpTest *= pSynfules[5];
                    }

                    if (testingData[i].Attributes[11] == 0)
                    {
                        PnTest *= pEducation[0];
                        PpTest *= pEducation[3];
                    }
                    else if (testingData[i].Attributes[11] == 1)
                    {
                        PnTest *= pEducation[1];
                        PpTest *= pEducation[4];
                    }
                    else if (testingData[i].Attributes[11] == 2)
                    {
                        PnTest *= pEducation[2];
                        PpTest *= pEducation[5];
                    }

                    if (testingData[i].Attributes[12] == 0)
                    {
                        PnTest *= pSuperfund[0];
                        PpTest *= pSuperfund[3];
                    }
                    else if (testingData[i].Attributes[12] == 1)
                    {
                        PnTest *= pSuperfund[1];
                        PpTest *= pSuperfund[4];
                    }
                    else if (testingData[i].Attributes[12] == 2)
                    {
                        PnTest *= pSuperfund[2];
                        PpTest *= pSuperfund[5];
                    }

                    if (testingData[i].Attributes[13] == 0)
                    {
                        PnTest *= pCrime[0];
                        PpTest *= pCrime[3];
                    }
                    else if (testingData[i].Attributes[13] == 1)
                    {
                        PnTest *= pCrime[1];
                        PpTest *= pCrime[4];
                    }
                    else if (testingData[i].Attributes[13] == 2)
                    {
                        PnTest *= pCrime[2];
                        PpTest *= pCrime[5];
                    }

                    if (testingData[i].Attributes[14] == 0)
                    {
                        PnTest *= pDuty[0];
                        PpTest *= pDuty[3];
                    }
                    else if (testingData[i].Attributes[14] == 1)
                    {
                        PnTest *= pDuty[1];
                        PpTest *= pDuty[4];
                    }
                    else if (testingData[i].Attributes[14] == 2)
                    {
                        PnTest *= pDuty[2];
                        PpTest *= pDuty[5];
                    }

                    if (testingData[i].Attributes[15] == 0)
                    {
                        PnTest *= pExport[0];
                        PpTest *= pExport[3];
                    }
                    else if (testingData[i].Attributes[15] == 1)
                    {
                        PnTest *= pExport[1];
                        PpTest *= pExport[4];
                    }
                    else if (testingData[i].Attributes[15] == 2)
                    {
                        PnTest *= pExport[2];
                        PpTest *= pExport[5];
                    }


                    if (PpTest > PnTest)
                    {
                        calculatedLabels.Add(1);
                        if (testingData[i].Label != 1)
                            numErrors++;
                    }
                    else
                    {
                        calculatedLabels.Add(0);
                        if (testingData[i].Label != 0)
                            numErrors++;
                    }
                }

            }
            else if (dataSelector == 1)
            {
                int[] countA1 = new int[6];
                int[] countA2 = new int[6];
                int[] countA3 = new int[4];
                int[] countA4 = new int[6];
                int[] countA5 = new int[8];
                int[] countA6 = new int[4];


                for (int i = 0; i < numTrainingPoints; i++)
                {
                    for (int j = 0; j < numAttributes; j++)
                    {
                        if (j == 0)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 1)
                                {
                                    countA1[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countA1[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 3)
                                {
                                    countA1[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 1)
                                {
                                    countA1[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countA1[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 3)
                                {
                                    countA1[5]++;
                                }
                            }
                        }
                        if (j == 1)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 1)
                                {
                                    countA2[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countA2[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 3)
                                {
                                    countA2[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 1)
                                {
                                    countA2[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countA2[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 3)
                                {
                                    countA2[5]++;
                                }
                            }
                        }
                        if (j == 2)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 1)
                                {
                                    countA3[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countA3[1]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 1)
                                {
                                    countA3[2]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countA3[3]++;
                                }
                            }
                        }
                        if (j == 3)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 1)
                                {
                                    countA4[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countA4[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 3)
                                {
                                    countA4[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 1)
                                {
                                    countA4[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countA4[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 3)
                                {
                                    countA4[5]++;
                                }
                            }
                        }
                        if (j == 4)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 1)
                                {
                                    countA5[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countA5[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 3)
                                {
                                    countA5[2]++;
                                }
                                else if (trainingData[i].Attributes[j] == 4)
                                {
                                    countA5[3]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 1)
                                {
                                    countA5[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countA5[5]++;
                                }
                                else if (trainingData[i].Attributes[j] == 3)
                                {
                                    countA5[6]++;
                                }
                                else if (trainingData[i].Attributes[j] == 4)
                                {
                                    countA5[7]++;
                                }
                            }
                        }
                        if (j == 5)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 1)
                                {
                                    countA6[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countA6[1]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 1)
                                {
                                    countA6[2]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countA6[3]++;
                                }
                            }
                        }
                    }
                }


                double[] pA1 = new double[6];
                pA1[0] = countA1[0] * 1.0 / totalNegative;
                pA1[1] = countA1[1] * 1.0 / totalNegative;
                pA1[2] = countA1[2] * 1.0 / totalNegative;
                pA1[3] = countA1[3] * 1.0 / totalPositive;
                pA1[4] = countA1[4] * 1.0 / totalPositive;
                pA1[5] = countA1[5] * 1.0 / totalPositive;

                double[] pA2 = new double[6];
                pA2[0] = countA2[0] * 1.0 / totalNegative;
                pA2[1] = countA2[1] * 1.0 / totalNegative;
                pA2[2] = countA2[2] * 1.0 / totalNegative;
                pA2[3] = countA2[3] * 1.0 / totalPositive;
                pA2[4] = countA2[4] * 1.0 / totalPositive;
                pA2[5] = countA2[5] * 1.0 / totalPositive;

                double[] pA3 = new double[4];
                pA3[0] = countA3[0] * 1.0 / totalNegative;
                pA3[1] = countA3[1] * 1.0 / totalNegative;
                pA3[2] = countA3[2] * 1.0 / totalNegative;
                pA3[3] = countA3[3] * 1.0 / totalPositive;

                double[] pA4 = new double[6];
                pA4[0] = countA4[0] * 1.0 / totalNegative;
                pA4[1] = countA4[1] * 1.0 / totalNegative;
                pA4[2] = countA4[2] * 1.0 / totalNegative;
                pA4[3] = countA4[3] * 1.0 / totalPositive;
                pA4[4] = countA4[4] * 1.0 / totalPositive;
                pA4[5] = countA4[5] * 1.0 / totalPositive;

                double[] pA5 = new double[8];
                pA5[0] = countA5[0] * 1.0 / totalNegative;
                pA5[1] = countA5[1] * 1.0 / totalNegative;
                pA5[2] = countA5[2] * 1.0 / totalNegative;
                pA5[3] = countA5[3] * 1.0 / totalPositive;
                pA5[4] = countA5[4] * 1.0 / totalPositive;
                pA5[5] = countA5[5] * 1.0 / totalPositive;
                pA5[6] = countA5[6] * 1.0 / totalPositive;
                pA5[7] = countA5[7] * 1.0 / totalPositive;

                double[] pA6 = new double[4];
                pA6[0] = countA6[0] * 1.0 / totalNegative;
                pA6[1] = countA6[1] * 1.0 / totalNegative;
                pA6[2] = countA6[2] * 1.0 / totalNegative;
                pA6[3] = countA6[3] * 1.0 / totalPositive;


                for (int i = 0; i < testingData.Count(); i++)
                {
                    double PpTest = Pp;
                    double PnTest = Pn;

                    if (testingData[i].Attributes[0] == 1)
                    {
                        PnTest *= pA1[0];
                        PpTest *= pA1[3];
                    }
                    else if (testingData[i].Attributes[0] == 2)
                    {
                        PnTest *= pA1[1];
                        PpTest *= pA1[4];
                    }
                    else if (testingData[i].Attributes[0] == 3)
                    {
                        PnTest *= pA1[2];
                        PpTest *= pA1[5];
                    }

                    if (testingData[i].Attributes[1] == 1)
                    {
                        PnTest *= pA2[0];
                        PpTest *= pA2[3];
                    }
                    else if (testingData[i].Attributes[1] == 2)
                    {
                        PnTest *= pA2[1];
                        PpTest *= pA2[4];
                    }
                    else if (testingData[i].Attributes[1] == 3)
                    {
                        PnTest *= pA2[2];
                        PpTest *= pA2[5];
                    }

                    if (testingData[i].Attributes[2] == 1)
                    {
                        PnTest *= pA3[0];
                        PpTest *= pA3[2];
                    }
                    else if (testingData[i].Attributes[2] == 2)
                    {
                        PnTest *= pA3[1];
                        PpTest *= pA3[3];
                    }


                    if (testingData[i].Attributes[3] == 1)
                    {
                        PnTest *= pA4[0];
                        PpTest *= pA4[3];
                    }
                    else if (testingData[i].Attributes[3] == 2)
                    {
                        PnTest *= pA4[1];
                        PpTest *= pA4[4];
                    }
                    else if (testingData[i].Attributes[3] == 3)
                    {
                        PnTest *= pA4[2];
                        PpTest *= pA4[5];
                    }

                    if (testingData[i].Attributes[4] == 1)
                    {
                        PnTest *= pA5[0];
                        PpTest *= pA5[4];
                    }
                    else if (testingData[i].Attributes[4] == 2)
                    {
                        PnTest *= pA5[1];
                        PpTest *= pA5[5];
                    }
                    else if (testingData[i].Attributes[4] == 3)
                    {
                        PnTest *= pA5[2];
                        PpTest *= pA5[6];
                    }
                    else if (testingData[i].Attributes[4] == 4)
                    {
                        PnTest *= pA5[3];
                        PpTest *= pA5[7];
                    }

                    if (testingData[i].Attributes[5] == 1)
                    {
                        PnTest *= pA6[0];
                        PpTest *= pA6[2];
                    }
                    else if (testingData[i].Attributes[5] == 2)
                    {
                        PnTest *= pA6[1];
                        PpTest *= pA6[3];
                    }



                    if (PpTest > PnTest)
                    {
                        calculatedLabels.Add(1);
                        if (testingData[i].Label != 1)
                            numErrors++;
                    }
                    else
                    {
                        calculatedLabels.Add(0);
                        if (testingData[i].Label != 0)
                            numErrors++;
                    }
                }


            }
            else if (dataSelector == 3)
            {
                int[] countTL = new int[6];
                int[] countTM = new int[6];
                int[] countTR = new int[6];
                int[] countML = new int[6];
                int[] countMM = new int[6];
                int[] countMR = new int[6];
                int[] countBL = new int[6];
                int[] countBM = new int[6];
                int[] countBR = new int[6];



                for (int i = 0; i < numTrainingPoints; i++)
                {
                    for (int j = 0; j < numAttributes; j++)
                    {
                        if (j == 0)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countTL[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countTL[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countTL[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countTL[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countTL[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countTL[5]++;
                                }
                            }
                        }
                        if (j == 1)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countTM[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countTM[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countTM[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countTM[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countTM[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countTM[5]++;
                                }
                            }
                        }
                        if (j == 2)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countTR[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countTR[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countTR[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countTR[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countTR[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countTR[5]++;
                                }
                            }
                        }
                        if (j == 3)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countML[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countML[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countML[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countML[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countML[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countML[5]++;
                                }
                            }
                        }
                        if (j == 4)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countMM[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countMM[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countMM[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countMM[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countMM[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countMM[5]++;
                                }
                            }
                        }
                        if (j == 5)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countMR[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countMR[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countMR[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countMR[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countMR[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countMR[5]++;
                                }
                            }
                        }
                        if (j == 6)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countBL[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countBL[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countBL[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countBL[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countBL[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countBL[5]++;
                                }
                            }
                        }
                        if (j == 7)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countBM[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countBM[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countBM[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countBM[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countBM[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countBM[5]++;
                                }
                            }
                        }
                        if (j == 8)
                        {
                            if (trainingData[i].Label == 0)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countBR[0]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countBR[1]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countBR[2]++;
                                }
                            }
                            else if (trainingData[i].Label == 1)
                            {
                                if (trainingData[i].Attributes[j] == 0)
                                {
                                    countBR[3]++;
                                }
                                else if (trainingData[i].Attributes[j] == 1)
                                {
                                    countBR[4]++;
                                }
                                else if (trainingData[i].Attributes[j] == 2)
                                {
                                    countBR[5]++;
                                }
                            }
                        }
                    }
                }
                double[] pTL = new double[6];
                pTL[0] = countTL[0] * 1.0 / totalNegative;
                pTL[1] = countTL[1] * 1.0 / totalNegative;
                pTL[2] = countTL[2] * 1.0 / totalNegative;
                pTL[3] = countTL[3] * 1.0 / totalPositive;
                pTL[4] = countTL[4] * 1.0 / totalPositive;
                pTL[5] = countTL[5] * 1.0 / totalPositive;

                double[] pTM = new double[6];
                pTM[0] = countTM[0] * 1.0 / totalNegative;
                pTM[1] = countTM[1] * 1.0 / totalNegative;
                pTM[2] = countTM[2] * 1.0 / totalNegative;
                pTM[3] = countTM[3] * 1.0 / totalPositive;
                pTM[4] = countTM[4] * 1.0 / totalPositive;
                pTM[5] = countTM[5] * 1.0 / totalPositive;
                double[] pTR = new double[6];
                pTR[0] = countTR[0] * 1.0 / totalNegative;
                pTR[1] = countTR[1] * 1.0 / totalNegative;
                pTR[2] = countTR[2] * 1.0 / totalNegative;
                pTR[3] = countTR[3] * 1.0 / totalPositive;
                pTR[4] = countTR[4] * 1.0 / totalPositive;
                pTR[5] = countTR[5] * 1.0 / totalPositive;
                double[] pML = new double[6];
                pML[0] = countML[0] * 1.0 / totalNegative;
                pML[1] = countML[1] * 1.0 / totalNegative;
                pML[2] = countML[2] * 1.0 / totalNegative;
                pML[3] = countML[3] * 1.0 / totalPositive;
                pML[4] = countML[4] * 1.0 / totalPositive;
                pML[5] = countML[5] * 1.0 / totalPositive;
                double[] pMM = new double[6];
                pMM[0] = countMM[0] * 1.0 / totalNegative;
                pMM[1] = countMM[1] * 1.0 / totalNegative;
                pMM[2] = countMM[2] * 1.0 / totalNegative;
                pMM[3] = countMM[3] * 1.0 / totalPositive;
                pMM[4] = countMM[4] * 1.0 / totalPositive;
                pMM[5] = countMM[5] * 1.0 / totalPositive;
                double[] pMR = new double[6];
                pMR[0] = countMR[0] * 1.0 / totalNegative;
                pMR[1] = countMR[1] * 1.0 / totalNegative;
                pMR[2] = countMR[2] * 1.0 / totalNegative;
                pMR[3] = countMR[3] * 1.0 / totalPositive;
                pMR[4] = countMR[4] * 1.0 / totalPositive;
                pMR[5] = countMR[5] * 1.0 / totalPositive;
                double[] pBL = new double[6];
                pBL[0] = countBL[0] * 1.0 / totalNegative;
                pBL[1] = countBL[1] * 1.0 / totalNegative;
                pBL[2] = countBL[2] * 1.0 / totalNegative;
                pBL[3] = countBL[3] * 1.0 / totalPositive;
                pBL[4] = countBL[4] * 1.0 / totalPositive;
                pBL[5] = countBL[5] * 1.0 / totalPositive;
                double[] pBM = new double[6];
                pBM[0] = countBM[0] * 1.0 / totalNegative;
                pBM[1] = countBM[1] * 1.0 / totalNegative;
                pBM[2] = countBM[2] * 1.0 / totalNegative;
                pBM[3] = countBM[3] * 1.0 / totalPositive;
                pBM[4] = countBM[4] * 1.0 / totalPositive;
                pBM[5] = countBM[5] * 1.0 / totalPositive;
                double[] pBR = new double[6];
                pBR[0] = countBR[0] * 1.0 / totalNegative;
                pBR[1] = countBR[1] * 1.0 / totalNegative;
                pBR[2] = countBR[2] * 1.0 / totalNegative;
                pBR[3] = countBR[3] * 1.0 / totalPositive;
                pBR[4] = countBR[4] * 1.0 / totalPositive;
                pBR[5] = countBR[5] * 1.0 / totalPositive;

                for (int i = 0; i < testingData.Count(); i++)
                {
                    double PpTest = Pp;
                    double PnTest = Pn;

                    if (testingData[i].Attributes[0] == 0)
                    {
                        PnTest *= pTL[0];
                        PpTest *= pTL[3];
                    }
                    else if (testingData[i].Attributes[0] == 1)
                    {
                        PnTest *= pTL[1];
                        PpTest *= pTL[4];
                    }
                    else if (testingData[i].Attributes[0] == 2)
                    {
                        PnTest *= pTL[2];
                        PpTest *= pTL[5];
                    }

                    if (testingData[i].Attributes[1] == 0)
                    {
                        PnTest *= pTM[0];
                        PpTest *= pTM[3];
                    }
                    else if (testingData[i].Attributes[1] == 1)
                    {
                        PnTest *= pTM[1];
                        PpTest *= pTM[4];
                    }
                    else if (testingData[i].Attributes[1] == 2)
                    {
                        PnTest *= pTM[2];
                        PpTest *= pTM[5];
                    }

                    if (testingData[i].Attributes[2] == 0)
                    {
                        PnTest *= pTR[0];
                        PpTest *= pTR[3];
                    }
                    else if (testingData[i].Attributes[2] == 1)
                    {
                        PnTest *= pTR[1];
                        PpTest *= pTR[4];
                    }
                    else if (testingData[i].Attributes[2] == 2)
                    {
                        PnTest *= pTR[2];
                        PpTest *= pTR[5];
                    }

                    if (testingData[i].Attributes[3] == 0)
                    {
                        PnTest *= pML[0];
                        PpTest *= pML[3];
                    }
                    else if (testingData[i].Attributes[3] == 1)
                    {
                        PnTest *= pML[1];
                        PpTest *= pML[4];
                    }
                    else if (testingData[i].Attributes[3] == 2)
                    {
                        PnTest *= pML[2];
                        PpTest *= pML[5];
                    }

                    if (testingData[i].Attributes[4] == 0)
                    {
                        PnTest *= pMM[0];
                        PpTest *= pMM[3];
                    }
                    else if (testingData[i].Attributes[4] == 1)
                    {
                        PnTest *= pMM[1];
                        PpTest *= pMM[4];
                    }
                    else if (testingData[i].Attributes[4] == 2)
                    {
                        PnTest *= pMM[2];
                        PpTest *= pMM[5];
                    }

                    if (testingData[i].Attributes[5] == 0)
                    {
                        PnTest *= pMR[0];
                        PpTest *= pMR[3];
                    }
                    else if (testingData[i].Attributes[5] == 1)
                    {
                        PnTest *= pMR[1];
                        PpTest *= pMR[4];
                    }
                    else if (testingData[i].Attributes[5] == 2)
                    {
                        PnTest *= pMR[2];
                        PpTest *= pMR[5];
                    }

                    if (testingData[i].Attributes[6] == 0)
                    {
                        PnTest *= pBL[0];
                        PpTest *= pBL[3];
                    }
                    else if (testingData[i].Attributes[6] == 1)
                    {
                        PnTest *= pBL[1];
                        PpTest *= pBL[4];
                    }
                    else if (testingData[i].Attributes[6] == 2)
                    {
                        PnTest *= pBL[2];
                        PpTest *= pBL[5];
                    }

                    if (testingData[i].Attributes[7] == 0)
                    {
                        PnTest *= pBM[0];
                        PpTest *= pBM[3];
                    }
                    else if (testingData[i].Attributes[7] == 1)
                    {
                        PnTest *= pBM[1];
                        PpTest *= pBM[4];
                    }
                    else if (testingData[i].Attributes[7] == 2)
                    {
                        PnTest *= pBM[2];
                        PpTest *= pBM[5];
                    }

                    if (testingData[i].Attributes[8] == 0)
                    {
                        PnTest *= pBR[0];
                        PpTest *= pBR[3];
                    }
                    else if (testingData[i].Attributes[8] == 1)
                    {
                        PnTest *= pBR[1];
                        PpTest *= pBR[4];
                    }
                    else if (testingData[i].Attributes[8] == 2)
                    {
                        PnTest *= pBR[2];
                        PpTest *= pBR[5];
                    }


                    

                    if (PpTest > PnTest)
                    {
                        calculatedLabels.Add(1);
                        if (testingData[i].Label != 1)
                            numErrors++;
                    }
                    else
                    {
                        calculatedLabels.Add(0);
                        if (testingData[i].Label != 0)
                            numErrors++;
                    }
                }



            }

            #region worthless
            List<double> PpAttribute = new List<double>();
                List<double> PnAttribute = new List<double>();

                for (int i = 0; i < numAttributes; i++)
                {
                    ComplexCounter complexCounter = new ComplexCounter();
                    for (int j = 0; j < numTrainingPoints; j++)
                    {
                        int currentAttriValue = trainingData[j].Attributes[i];
                        int currentLabel = trainingData[j].Label;
                        bool contains = complexCounter.Value.Contains(currentAttriValue);
                        if (contains)
                        {
                            bool containsWithLabel = false;
                            for (int k = 0; k < complexCounter.Value.Count(); k++)
                            {
                                if (complexCounter.Value[k] == currentAttriValue && complexCounter.Label[k] == currentLabel)
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
                        if (complexCounter.Label[l] == 1)//positive
                        {
                            PpAttribute.Add(complexCounter.Count[l] * 1.0 / totalPositive);
                        }
                        else//negative
                        {
                            PnAttribute.Add(complexCounter.Count[l] * 1.0 / totalNegative);
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

