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
            List<double> mList = new List<double>();
            mList.Add(2.0);
            mList.Add(3.0);
            mList.Add(4.0);
            mList.Add(5.0);
            mList.Add(6.0);
            mList.Add(7.0);

            foreach (double m in mList)
            {

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

                numErrors = 0;
                if (dataSelector == 2)
                {
                    int[] countHandicapped = new int[6];
                    int[] countWater = new int[6];
                    int[] countAdoption = new int[6];
                    int[] countPhysician = new int[6];
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
                                        countPhysician[0]++;
                                    }
                                    else if (trainingData[i].Attributes[j] == 1)
                                    {
                                        countPhysician[1]++;
                                    }
                                    else if (trainingData[i].Attributes[j] == 2)
                                    {
                                        countPhysician[2]++;
                                    }
                                }
                                else if (trainingData[i].Label == 1)
                                {
                                    if (trainingData[i].Attributes[j] == 0)
                                    {
                                        countPhysician[3]++;
                                    }
                                    else if (trainingData[i].Attributes[j] == 1)
                                    {
                                        countPhysician[4]++;
                                    }
                                    else if (trainingData[i].Attributes[j] == 2)
                                    {
                                        countPhysician[5]++;
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
                    double[] pHatHandicapped = new double[6];
                    pHandicapped[0] = countHandicapped[0] * 1.0 / totalNegative;
                    pHandicapped[1] = countHandicapped[1] * 1.0 / totalNegative;
                    pHandicapped[2] = countHandicapped[2] * 1.0 / totalNegative;
                    pHandicapped[3] = countHandicapped[3] * 1.0 / totalPositive;
                    pHandicapped[4] = countHandicapped[4] * 1.0 / totalPositive;
                    pHandicapped[5] = countHandicapped[5] * 1.0 / totalPositive;
                    pHatHandicapped[0] = (countHandicapped[0] * 1.0 + m * pHandicapped[0]) / (totalNegative + m);
                    pHatHandicapped[1] = (countHandicapped[1] * 1.0 + m * pHandicapped[1]) / (totalNegative + m);
                    pHatHandicapped[2] = (countHandicapped[2] * 1.0 + m * pHandicapped[2]) / (totalNegative + m);
                    pHatHandicapped[3] = (countHandicapped[3] * 1.0 + m * pHandicapped[3]) / (totalPositive + m);
                    pHatHandicapped[4] = (countHandicapped[4] * 1.0 + m * pHandicapped[4]) / (totalPositive + m);
                    pHatHandicapped[5] = (countHandicapped[5] * 1.0 + m * pHandicapped[5]) / (totalPositive + m);
                    double[] pWater = new double[6];
                    double[] pHatWater = new double[6];
                    pWater[0] = countWater[0] * 1.0 / totalNegative;
                    pWater[1] = countWater[1] * 1.0 / totalNegative;
                    pWater[2] = countWater[2] * 1.0 / totalNegative;
                    pWater[3] = countWater[3] * 1.0 / totalPositive;
                    pWater[4] = countWater[4] * 1.0 / totalPositive;
                    pWater[5] = countWater[5] * 1.0 / totalPositive;
                    pHatWater[0] = (countWater[0] * 1.0 + m * pWater[0]) / (totalNegative + m);
                    pHatWater[1] = (countWater[1] * 1.0 + m * pWater[1]) / (totalNegative + m);
                    pHatWater[2] = (countWater[2] * 1.0 + m * pWater[2]) / (totalNegative + m);
                    pHatWater[3] = (countWater[3] * 1.0 + m * pWater[3]) / (totalPositive + m);
                    pHatWater[4] = (countWater[4] * 1.0 + m * pWater[4]) / (totalPositive + m);
                    pHatWater[5] = (countWater[5] * 1.0 + m * pWater[5]) / (totalPositive + m);
                    double[] pAdoption = new double[6];
                    double[] pHatAdoption = new double[6];
                    pAdoption[0] = countAdoption[0] * 1.0 / totalNegative;
                    pAdoption[1] = countAdoption[1] * 1.0 / totalNegative;
                    pAdoption[2] = countAdoption[2] * 1.0 / totalNegative;
                    pAdoption[3] = countAdoption[3] * 1.0 / totalPositive;
                    pAdoption[4] = countAdoption[4] * 1.0 / totalPositive;
                    pAdoption[5] = countAdoption[5] * 1.0 / totalPositive;
                    pHatAdoption[0] = (countAdoption[0] * 1.0 + m * pAdoption[0]) / (totalNegative + m);
                    pHatAdoption[1] = (countAdoption[1] * 1.0 + m * pAdoption[1]) / (totalNegative + m);
                    pHatAdoption[2] = (countAdoption[2] * 1.0 + m * pAdoption[2]) / (totalNegative + m);
                    pHatAdoption[3] = (countAdoption[3] * 1.0 + m * pAdoption[3]) / (totalPositive + m);
                    pHatAdoption[4] = (countAdoption[4] * 1.0 + m * pAdoption[4]) / (totalPositive + m);
                    pHatAdoption[5] = (countAdoption[5] * 1.0 + m * pAdoption[5]) / (totalPositive + m);
                    double[] pPhysician = new double[6];
                    double[] pHatPhysician = new double[6];
                    pPhysician[0] = countPhysician[0] * 1.0 / totalNegative;
                    pPhysician[1] = countPhysician[1] * 1.0 / totalNegative;
                    pPhysician[2] = countPhysician[2] * 1.0 / totalNegative;
                    pPhysician[3] = countPhysician[3] * 1.0 / totalPositive;
                    pPhysician[4] = countPhysician[4] * 1.0 / totalPositive;
                    pPhysician[5] = countPhysician[5] * 1.0 / totalPositive;
                    pHatPhysician[0] = (countPhysician[0] * 1.0 + m * pPhysician[0]) / (totalNegative + m);
                    pHatPhysician[1] = (countPhysician[1] * 1.0 + m * pPhysician[1]) / (totalNegative + m);
                    pHatPhysician[2] = (countPhysician[2] * 1.0 + m * pPhysician[2]) / (totalNegative + m);
                    pHatPhysician[3] = (countPhysician[3] * 1.0 + m * pPhysician[3]) / (totalPositive + m);
                    pHatPhysician[4] = (countPhysician[4] * 1.0 + m * pPhysician[4]) / (totalPositive + m);
                    pHatPhysician[5] = (countPhysician[5] * 1.0 + m * pPhysician[5]) / (totalPositive + m);
                    double[] pSalvador = new double[6];
                    double[] pHatSalvador = new double[6];
                    pSalvador[0] = countSalvador[0] * 1.0 / totalNegative;
                    pSalvador[1] = countSalvador[1] * 1.0 / totalNegative;
                    pSalvador[2] = countSalvador[2] * 1.0 / totalNegative;
                    pSalvador[3] = countSalvador[3] * 1.0 / totalPositive;
                    pSalvador[4] = countSalvador[4] * 1.0 / totalPositive;
                    pSalvador[5] = countSalvador[5] * 1.0 / totalPositive;
                    pHatSalvador[0] = (countSalvador[0] * 1.0 + m * pSalvador[0]) / (totalNegative + m);
                    pHatSalvador[1] = (countSalvador[1] * 1.0 + m * pSalvador[1]) / (totalNegative + m);
                    pHatSalvador[2] = (countSalvador[2] * 1.0 + m * pSalvador[2]) / (totalNegative + m);
                    pHatSalvador[3] = (countSalvador[3] * 1.0 + m * pSalvador[3]) / (totalPositive + m);
                    pHatSalvador[4] = (countSalvador[4] * 1.0 + m * pSalvador[4]) / (totalPositive + m);
                    pHatSalvador[5] = (countSalvador[5] * 1.0 + m * pSalvador[5]) / (totalPositive + m);
                    double[] pReligious = new double[6];
                    double[] pHatReligious = new double[6];
                    pReligious[0] = countReligious[0] * 1.0 / totalNegative;
                    pReligious[1] = countReligious[1] * 1.0 / totalNegative;
                    pReligious[2] = countReligious[2] * 1.0 / totalNegative;
                    pReligious[3] = countReligious[3] * 1.0 / totalPositive;
                    pReligious[4] = countReligious[4] * 1.0 / totalPositive;
                    pReligious[5] = countReligious[5] * 1.0 / totalPositive;
                    pHatReligious[0] = (countReligious[0] * 1.0 + m * pReligious[0]) / (totalNegative + m);
                    pHatReligious[1] = (countReligious[1] * 1.0 + m * pReligious[1]) / (totalNegative + m);
                    pHatReligious[2] = (countReligious[2] * 1.0 + m * pReligious[2]) / (totalNegative + m);
                    pHatReligious[3] = (countReligious[3] * 1.0 + m * pReligious[3]) / (totalPositive + m);
                    pHatReligious[4] = (countReligious[4] * 1.0 + m * pReligious[4]) / (totalPositive + m);
                    pHatReligious[5] = (countReligious[5] * 1.0 + m * pReligious[5]) / (totalPositive + m);
                    double[] pSatellite = new double[6];
                    double[] pHatSatellite = new double[6];
                    pSatellite[0] = countSatellite[0] * 1.0 / totalNegative;
                    pSatellite[1] = countSatellite[1] * 1.0 / totalNegative;
                    pSatellite[2] = countSatellite[2] * 1.0 / totalNegative;
                    pSatellite[3] = countSatellite[3] * 1.0 / totalPositive;
                    pSatellite[4] = countSatellite[4] * 1.0 / totalPositive;
                    pSatellite[5] = countSatellite[5] * 1.0 / totalPositive;
                    pHatSatellite[0] = (countSatellite[0] * 1.0 + m * pSatellite[0]) / (totalNegative + m);
                    pHatSatellite[1] = (countSatellite[1] * 1.0 + m * pSatellite[1]) / (totalNegative + m);
                    pHatSatellite[2] = (countSatellite[2] * 1.0 + m * pSatellite[2]) / (totalNegative + m);
                    pHatSatellite[3] = (countSatellite[3] * 1.0 + m * pSatellite[3]) / (totalPositive + m);
                    pHatSatellite[4] = (countSatellite[4] * 1.0 + m * pSatellite[4]) / (totalPositive + m);
                    pHatSatellite[5] = (countSatellite[5] * 1.0 + m * pSatellite[5]) / (totalPositive + m);
                    double[] pNicaraguan = new double[6];
                    double[] pHatNicaraguan = new double[6];
                    pNicaraguan[0] = countNicaraguan[0] * 1.0 / totalNegative;
                    pNicaraguan[1] = countNicaraguan[1] * 1.0 / totalNegative;
                    pNicaraguan[2] = countNicaraguan[2] * 1.0 / totalNegative;
                    pNicaraguan[3] = countNicaraguan[3] * 1.0 / totalPositive;
                    pNicaraguan[4] = countNicaraguan[4] * 1.0 / totalPositive;
                    pNicaraguan[5] = countNicaraguan[5] * 1.0 / totalPositive;
                    pHatNicaraguan[0] = (countNicaraguan[0] * 1.0 + m * pNicaraguan[0]) / (totalNegative + m);
                    pHatNicaraguan[1] = (countNicaraguan[1] * 1.0 + m * pNicaraguan[1]) / (totalNegative + m);
                    pHatNicaraguan[2] = (countNicaraguan[2] * 1.0 + m * pNicaraguan[2]) / (totalNegative + m);
                    pHatNicaraguan[3] = (countNicaraguan[3] * 1.0 + m * pNicaraguan[3]) / (totalPositive + m);
                    pHatNicaraguan[4] = (countNicaraguan[4] * 1.0 + m * pNicaraguan[4]) / (totalPositive + m);
                    pHatNicaraguan[5] = (countNicaraguan[5] * 1.0 + m * pNicaraguan[5]) / (totalPositive + m);
                    double[] pMx = new double[6];
                    double[] pHatMx = new double[6];
                    pMx[0] = countMx[0] * 1.0 / totalNegative;
                    pMx[1] = countMx[1] * 1.0 / totalNegative;
                    pMx[2] = countMx[2] * 1.0 / totalNegative;
                    pMx[3] = countMx[3] * 1.0 / totalPositive;
                    pMx[4] = countMx[4] * 1.0 / totalPositive;
                    pMx[5] = countMx[5] * 1.0 / totalPositive;
                    pHatMx[0] = (countMx[0] * 1.0 + m * pMx[0]) / (totalNegative + m);
                    pHatMx[1] = (countMx[1] * 1.0 + m * pMx[1]) / (totalNegative + m);
                    pHatMx[2] = (countMx[2] * 1.0 + m * pMx[2]) / (totalNegative + m);
                    pHatMx[3] = (countMx[3] * 1.0 + m * pMx[3]) / (totalPositive + m);
                    pHatMx[4] = (countMx[4] * 1.0 + m * pMx[4]) / (totalPositive + m);
                    pHatMx[5] = (countMx[5] * 1.0 + m * pMx[5]) / (totalPositive + m);
                    double[] pImmigration = new double[6];
                    double[] pHatImmigration = new double[6];
                    pImmigration[0] = countImmigration[0] * 1.0 / totalNegative;
                    pImmigration[1] = countImmigration[1] * 1.0 / totalNegative;
                    pImmigration[2] = countImmigration[2] * 1.0 / totalNegative;
                    pImmigration[3] = countImmigration[3] * 1.0 / totalPositive;
                    pImmigration[4] = countImmigration[4] * 1.0 / totalPositive;
                    pImmigration[5] = countImmigration[5] * 1.0 / totalPositive;
                    pHatImmigration[0] = (countImmigration[0] * 1.0 + m * pImmigration[0]) / (totalNegative + m);
                    pHatImmigration[1] = (countImmigration[1] * 1.0 + m * pImmigration[1]) / (totalNegative + m);
                    pHatImmigration[2] = (countImmigration[2] * 1.0 + m * pImmigration[2]) / (totalNegative + m);
                    pHatImmigration[3] = (countImmigration[3] * 1.0 + m * pImmigration[3]) / (totalPositive + m);
                    pHatImmigration[4] = (countImmigration[4] * 1.0 + m * pImmigration[4]) / (totalPositive + m);
                    pHatImmigration[5] = (countImmigration[5] * 1.0 + m * pImmigration[5]) / (totalPositive + m);
                    double[] pSynfules = new double[6];
                    double[] pHatSynfules = new double[6];
                    pSynfules[0] = countSynfules[0] * 1.0 / totalNegative;
                    pSynfules[1] = countSynfules[1] * 1.0 / totalNegative;
                    pSynfules[2] = countSynfules[2] * 1.0 / totalNegative;
                    pSynfules[3] = countSynfules[3] * 1.0 / totalPositive;
                    pSynfules[4] = countSynfules[4] * 1.0 / totalPositive;
                    pSynfules[5] = countSynfules[5] * 1.0 / totalPositive;
                    pHatSynfules[0] = (countSynfules[0] * 1.0 + m * pSynfules[0]) / (totalNegative + m);
                    pHatSynfules[1] = (countSynfules[1] * 1.0 + m * pSynfules[1]) / (totalNegative + m);
                    pHatSynfules[2] = (countSynfules[2] * 1.0 + m * pSynfules[2]) / (totalNegative + m);
                    pHatSynfules[3] = (countSynfules[3] * 1.0 + m * pSynfules[3]) / (totalPositive + m);
                    pHatSynfules[4] = (countSynfules[4] * 1.0 + m * pSynfules[4]) / (totalPositive + m);
                    pHatSynfules[5] = (countSynfules[5] * 1.0 + m * pSynfules[5]) / (totalPositive + m);
                    double[] pEducation = new double[6];
                    double[] pHatEducation = new double[6];
                    pEducation[0] = countEducation[0] * 1.0 / totalNegative;
                    pEducation[1] = countEducation[1] * 1.0 / totalNegative;
                    pEducation[2] = countEducation[2] * 1.0 / totalNegative;
                    pEducation[3] = countEducation[3] * 1.0 / totalPositive;
                    pEducation[4] = countEducation[4] * 1.0 / totalPositive;
                    pEducation[5] = countEducation[5] * 1.0 / totalPositive;
                    pHatEducation[0] = (countEducation[0] * 1.0 + m * pEducation[0]) / (totalNegative + m);
                    pHatEducation[1] = (countEducation[1] * 1.0 + m * pEducation[1]) / (totalNegative + m);
                    pHatEducation[2] = (countEducation[2] * 1.0 + m * pEducation[2]) / (totalNegative + m);
                    pHatEducation[3] = (countEducation[3] * 1.0 + m * pEducation[3]) / (totalPositive + m);
                    pHatEducation[4] = (countEducation[4] * 1.0 + m * pEducation[4]) / (totalPositive + m);
                    pHatEducation[5] = (countEducation[5] * 1.0 + m * pEducation[5]) / (totalPositive + m);
                    double[] pSuperfund = new double[6];
                    double[] pHatSuperfund = new double[6];
                    pSuperfund[0] = countSuperfund[0] * 1.0 / totalNegative;
                    pSuperfund[1] = countSuperfund[1] * 1.0 / totalNegative;
                    pSuperfund[2] = countSuperfund[2] * 1.0 / totalNegative;
                    pSuperfund[3] = countSuperfund[3] * 1.0 / totalPositive;
                    pSuperfund[4] = countSuperfund[4] * 1.0 / totalPositive;
                    pSuperfund[5] = countSuperfund[5] * 1.0 / totalPositive;
                    pHatSuperfund[0] = (countSuperfund[0] * 1.0 + m * pSuperfund[0]) / (totalNegative + m);
                    pHatSuperfund[1] = (countSuperfund[1] * 1.0 + m * pSuperfund[1]) / (totalNegative + m);
                    pHatSuperfund[2] = (countSuperfund[2] * 1.0 + m * pSuperfund[2]) / (totalNegative + m);
                    pHatSuperfund[3] = (countSuperfund[3] * 1.0 + m * pSuperfund[3]) / (totalPositive + m);
                    pHatSuperfund[4] = (countSuperfund[4] * 1.0 + m * pSuperfund[4]) / (totalPositive + m);
                    pHatSuperfund[5] = (countSuperfund[5] * 1.0 + m * pSuperfund[5]) / (totalPositive + m);
                    double[] pCrime = new double[6];
                    double[] pHatCrime = new double[6];
                    pCrime[0] = countCrime[0] * 1.0 / totalNegative;
                    pCrime[1] = countCrime[1] * 1.0 / totalNegative;
                    pCrime[2] = countCrime[2] * 1.0 / totalNegative;
                    pCrime[3] = countCrime[3] * 1.0 / totalPositive;
                    pCrime[4] = countCrime[4] * 1.0 / totalPositive;
                    pCrime[5] = countCrime[5] * 1.0 / totalPositive;
                    pHatCrime[0] = (countCrime[0] * 1.0 + m * pCrime[0]) / (totalNegative + m);
                    pHatCrime[1] = (countCrime[1] * 1.0 + m * pCrime[1]) / (totalNegative + m);
                    pHatCrime[2] = (countCrime[2] * 1.0 + m * pCrime[2]) / (totalNegative + m);
                    pHatCrime[3] = (countCrime[3] * 1.0 + m * pCrime[3]) / (totalPositive + m);
                    pHatCrime[4] = (countCrime[4] * 1.0 + m * pCrime[4]) / (totalPositive + m);
                    pHatCrime[5] = (countCrime[5] * 1.0 + m * pCrime[5]) / (totalPositive + m);
                    double[] pDuty = new double[6];
                    double[] pHatDuty = new double[6];
                    pDuty[0] = countDuty[0] * 1.0 / totalNegative;
                    pDuty[1] = countDuty[1] * 1.0 / totalNegative;
                    pDuty[2] = countDuty[2] * 1.0 / totalNegative;
                    pDuty[3] = countDuty[3] * 1.0 / totalPositive;
                    pDuty[4] = countDuty[4] * 1.0 / totalPositive;
                    pDuty[5] = countDuty[5] * 1.0 / totalPositive;
                    pHatDuty[0] = (countDuty[0] * 1.0 + m * pDuty[0]) / (totalNegative + m);
                    pHatDuty[1] = (countDuty[1] * 1.0 + m * pDuty[1]) / (totalNegative + m);
                    pHatDuty[2] = (countDuty[2] * 1.0 + m * pDuty[2]) / (totalNegative + m);
                    pHatDuty[3] = (countDuty[3] * 1.0 + m * pDuty[3]) / (totalPositive + m);
                    pHatDuty[4] = (countDuty[4] * 1.0 + m * pDuty[4]) / (totalPositive + m);
                    pHatDuty[5] = (countDuty[5] * 1.0 + m * pDuty[5]) / (totalPositive + m);
                    double[] pExport = new double[6];
                    double[] pHatExport = new double[6];
                    pExport[0] = countExport[0] * 1.0 / totalNegative;
                    pExport[1] = countExport[1] * 1.0 / totalNegative;
                    pExport[2] = countExport[2] * 1.0 / totalNegative;
                    pExport[3] = countExport[3] * 1.0 / totalPositive;
                    pExport[4] = countExport[4] * 1.0 / totalPositive;
                    pExport[5] = countExport[5] * 1.0 / totalPositive;
                    pHatExport[0] = (countExport[0] * 1.0 + m * pExport[0]) / (totalNegative + m);
                    pHatExport[1] = (countExport[1] * 1.0 + m * pExport[1]) / (totalNegative + m);
                    pHatExport[2] = (countExport[2] * 1.0 + m * pExport[2]) / (totalNegative + m);
                    pHatExport[3] = (countExport[3] * 1.0 + m * pExport[3]) / (totalPositive + m);
                    pHatExport[4] = (countExport[4] * 1.0 + m * pExport[4]) / (totalPositive + m);
                    pHatExport[5] = (countExport[5] * 1.0 + m * pExport[5]) / (totalPositive + m);


                    for (int i = 0; i < testingData.Count(); i++)
                    {
                        double PpTest = Pp;
                        double PnTest = Pn;

                        if (testingData[i].Attributes[0] == 0)
                        {
                            PnTest *= pHatHandicapped[0];
                            PpTest *= pHatHandicapped[3];
                        }
                        else if (testingData[i].Attributes[0] == 1)
                        {
                            PnTest *= pHatHandicapped[1];
                            PpTest *= pHatHandicapped[4];
                        }
                        else if (testingData[i].Attributes[0] == 2)
                        {
                            PnTest *= pHatHandicapped[2];
                            PpTest *= pHatHandicapped[5];
                        }

                        if (testingData[i].Attributes[1] == 0)
                        {
                            PnTest *= pHatWater[0];
                            PpTest *= pHatWater[3];
                        }
                        else if (testingData[i].Attributes[1] == 1)
                        {
                            PnTest *= pHatWater[1];
                            PpTest *= pHatWater[4];
                        }
                        else if (testingData[i].Attributes[1] == 2)
                        {
                            PnTest *= pHatWater[2];
                            PpTest *= pHatWater[5];
                        }

                        if (testingData[i].Attributes[2] == 0)
                        {
                            PnTest *= pHatAdoption[0];
                            PpTest *= pHatAdoption[3];
                        }
                        else if (testingData[i].Attributes[2] == 1)
                        {
                            PnTest *= pHatAdoption[1];
                            PpTest *= pHatAdoption[4];
                        }
                        else if (testingData[i].Attributes[2] == 2)
                        {
                            PnTest *= pHatAdoption[2];
                            PpTest *= pHatAdoption[5];
                        }

                        if (testingData[i].Attributes[3] == 0)
                        {
                            PnTest *= pHatPhysician[0];
                            PpTest *= pHatPhysician[3];
                        }
                        else if (testingData[i].Attributes[3] == 1)
                        {
                            PnTest *= pHatPhysician[1];
                            PpTest *= pHatPhysician[4];
                        }
                        else if (testingData[i].Attributes[3] == 2)
                        {
                            PnTest *= pHatPhysician[2];
                            PpTest *= pHatPhysician[5];
                        }

                        if (testingData[i].Attributes[4] == 0)
                        {
                            PnTest *= pHatSalvador[0];
                            PpTest *= pHatSalvador[3];
                        }
                        else if (testingData[i].Attributes[4] == 1)
                        {
                            PnTest *= pHatSalvador[1];
                            PpTest *= pHatSalvador[4];
                        }
                        else if (testingData[i].Attributes[4] == 2)
                        {
                            PnTest *= pHatSalvador[2];
                            PpTest *= pHatSalvador[5];
                        }

                        if (testingData[i].Attributes[5] == 0)
                        {
                            PnTest *= pHatReligious[0];
                            PpTest *= pHatReligious[3];
                        }
                        else if (testingData[i].Attributes[5] == 1)
                        {
                            PnTest *= pHatReligious[1];
                            PpTest *= pHatReligious[4];
                        }
                        else if (testingData[i].Attributes[5] == 2)
                        {
                            PnTest *= pHatReligious[2];
                            PpTest *= pHatReligious[5];
                        }

                        if (testingData[i].Attributes[6] == 0)
                        {
                            PnTest *= pHatSatellite[0];
                            PpTest *= pHatSatellite[3];
                        }
                        else if (testingData[i].Attributes[6] == 1)
                        {
                            PnTest *= pHatSatellite[1];
                            PpTest *= pHatSatellite[4];
                        }
                        else if (testingData[i].Attributes[6] == 2)
                        {
                            PnTest *= pHatSatellite[2];
                            PpTest *= pHatSatellite[5];
                        }

                        if (testingData[i].Attributes[7] == 0)
                        {
                            PnTest *= pHatNicaraguan[0];
                            PpTest *= pHatNicaraguan[3];
                        }
                        else if (testingData[i].Attributes[7] == 1)
                        {
                            PnTest *= pHatNicaraguan[1];
                            PpTest *= pHatNicaraguan[4];
                        }
                        else if (testingData[i].Attributes[7] == 2)
                        {
                            PnTest *= pHatNicaraguan[2];
                            PpTest *= pHatNicaraguan[5];
                        }

                        if (testingData[i].Attributes[8] == 0)
                        {
                            PnTest *= pHatMx[0];
                            PpTest *= pHatMx[3];
                        }
                        else if (testingData[i].Attributes[8] == 1)
                        {
                            PnTest *= pHatMx[1];
                            PpTest *= pHatMx[4];
                        }
                        else if (testingData[i].Attributes[8] == 2)
                        {
                            PnTest *= pHatMx[2];
                            PpTest *= pHatMx[5];
                        }

                        if (testingData[i].Attributes[9] == 0)
                        {
                            PnTest *= pHatImmigration[0];
                            PpTest *= pHatImmigration[3];
                        }
                        else if (testingData[i].Attributes[9] == 1)
                        {
                            PnTest *= pHatImmigration[1];
                            PpTest *= pHatImmigration[4];
                        }
                        else if (testingData[i].Attributes[9] == 2)
                        {
                            PnTest *= pHatImmigration[2];
                            PpTest *= pHatImmigration[5];
                        }

                        if (testingData[i].Attributes[10] == 0)
                        {
                            PnTest *= pHatSynfules[0];
                            PpTest *= pHatSynfules[3];
                        }
                        else if (testingData[i].Attributes[10] == 1)
                        {
                            PnTest *= pHatSynfules[1];
                            PpTest *= pHatSynfules[4];
                        }
                        else if (testingData[i].Attributes[10] == 2)
                        {
                            PnTest *= pHatSynfules[2];
                            PpTest *= pHatSynfules[5];
                        }

                        if (testingData[i].Attributes[11] == 0)
                        {
                            PnTest *= pHatEducation[0];
                            PpTest *= pHatEducation[3];
                        }
                        else if (testingData[i].Attributes[11] == 1)
                        {
                            PnTest *= pHatEducation[1];
                            PpTest *= pHatEducation[4];
                        }
                        else if (testingData[i].Attributes[11] == 2)
                        {
                            PnTest *= pHatEducation[2];
                            PpTest *= pHatEducation[5];
                        }

                        if (testingData[i].Attributes[12] == 0)
                        {
                            PnTest *= pHatSuperfund[0];
                            PpTest *= pHatSuperfund[3];
                        }
                        else if (testingData[i].Attributes[12] == 1)
                        {
                            PnTest *= pHatSuperfund[1];
                            PpTest *= pHatSuperfund[4];
                        }
                        else if (testingData[i].Attributes[12] == 2)
                        {
                            PnTest *= pHatSuperfund[2];
                            PpTest *= pHatSuperfund[5];
                        }

                        if (testingData[i].Attributes[13] == 0)
                        {
                            PnTest *= pHatCrime[0];
                            PpTest *= pHatCrime[3];
                        }
                        else if (testingData[i].Attributes[13] == 1)
                        {
                            PnTest *= pHatCrime[1];
                            PpTest *= pHatCrime[4];
                        }
                        else if (testingData[i].Attributes[13] == 2)
                        {
                            PnTest *= pHatCrime[2];
                            PpTest *= pHatCrime[5];
                        }

                        if (testingData[i].Attributes[14] == 0)
                        {
                            PnTest *= pHatDuty[0];
                            PpTest *= pHatDuty[3];
                        }
                        else if (testingData[i].Attributes[14] == 1)
                        {
                            PnTest *= pHatDuty[1];
                            PpTest *= pHatDuty[4];
                        }
                        else if (testingData[i].Attributes[14] == 2)
                        {
                            PnTest *= pHatDuty[2];
                            PpTest *= pHatDuty[5];
                        }

                        if (testingData[i].Attributes[15] == 0)
                        {
                            PnTest *= pHatExport[0];
                            PpTest *= pHatExport[3];
                        }
                        else if (testingData[i].Attributes[15] == 1)
                        {
                            PnTest *= pHatExport[1];
                            PpTest *= pHatExport[4];
                        }
                        else if (testingData[i].Attributes[15] == 2)
                        {
                            PnTest *= pHatExport[2];
                            PpTest *= pHatExport[5];
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
                    double[] pHatA1 = new double[6];
                    pA1[0] = countA1[0] * 1.0 / totalNegative;
                    pA1[1] = countA1[1] * 1.0 / totalNegative;
                    pA1[2] = countA1[2] * 1.0 / totalNegative;
                    pA1[3] = countA1[3] * 1.0 / totalPositive;
                    pA1[4] = countA1[4] * 1.0 / totalPositive;
                    pA1[5] = countA1[5] * 1.0 / totalPositive;
                    pHatA1[0] = (countA1[0] * 1.0 + m * pA1[0]) / (totalNegative + m);
                    pHatA1[1] = (countA1[1] * 1.0 + m * pA1[1]) / (totalNegative + m);
                    pHatA1[2] = (countA1[2] * 1.0 + m * pA1[2]) / (totalNegative + m);
                    pHatA1[3] = (countA1[3] * 1.0 + m * pA1[3]) / (totalPositive + m);
                    pHatA1[4] = (countA1[4] * 1.0 + m * pA1[4]) / (totalPositive + m);
                    pHatA1[5] = (countA1[5] * 1.0 + m * pA1[5]) / (totalPositive + m);

                    double[] pA2 = new double[6];
                    double[] pHatA2 = new double[6];
                    pA2[0] = countA2[0] * 1.0 / totalNegative;
                    pA2[1] = countA2[1] * 1.0 / totalNegative;
                    pA2[2] = countA2[2] * 1.0 / totalNegative;
                    pA2[3] = countA2[3] * 1.0 / totalPositive;
                    pA2[4] = countA2[4] * 1.0 / totalPositive;
                    pA2[5] = countA2[5] * 1.0 / totalPositive;
                    pHatA2[0] = (countA2[0] * 1.0 + m * pA2[0]) / (totalNegative + m);
                    pHatA2[1] = (countA2[1] * 1.0 + m * pA2[1]) / (totalNegative + m);
                    pHatA2[2] = (countA2[2] * 1.0 + m * pA2[2]) / (totalNegative + m);
                    pHatA2[3] = (countA2[3] * 1.0 + m * pA2[3]) / (totalPositive + m);
                    pHatA2[4] = (countA2[4] * 1.0 + m * pA2[4]) / (totalPositive + m);
                    pHatA2[5] = (countA2[5] * 1.0 + m * pA2[5]) / (totalPositive + m);

                    double[] pA3 = new double[4];
                    double[] pHatA3 = new double[4];
                    pA3[0] = countA3[0] * 1.0 / totalNegative;
                    pA3[1] = countA3[1] * 1.0 / totalNegative;
                    pA3[2] = countA3[2] * 1.0 / totalNegative;
                    pA3[3] = countA3[3] * 1.0 / totalPositive;
                    pHatA3[0] = (countA3[0] * 1.0 + m * pA3[0]) / (totalNegative + m);
                    pHatA3[1] = (countA3[1] * 1.0 + m * pA3[1]) / (totalNegative + m);
                    pHatA3[2] = (countA3[2] * 1.0 + m * pA3[2]) / (totalPositive + m);
                    pHatA3[3] = (countA3[3] * 1.0 + m * pA3[3]) / (totalPositive + m);

                    double[] pA4 = new double[6];
                    double[] pHatA4 = new double[6];
                    pA4[0] = countA4[0] * 1.0 / totalNegative;
                    pA4[1] = countA4[1] * 1.0 / totalNegative;
                    pA4[2] = countA4[2] * 1.0 / totalNegative;
                    pA4[3] = countA4[3] * 1.0 / totalPositive;
                    pA4[4] = countA4[4] * 1.0 / totalPositive;
                    pA4[5] = countA4[5] * 1.0 / totalPositive;
                    pHatA4[0] = (countA4[0] * 1.0 + m * pA4[0]) / (totalNegative + m);
                    pHatA4[1] = (countA4[1] * 1.0 + m * pA4[1]) / (totalNegative + m);
                    pHatA4[2] = (countA4[2] * 1.0 + m * pA4[2]) / (totalNegative + m);
                    pHatA4[3] = (countA4[3] * 1.0 + m * pA4[3]) / (totalPositive + m);
                    pHatA4[4] = (countA4[4] * 1.0 + m * pA4[4]) / (totalPositive + m);
                    pHatA4[5] = (countA4[5] * 1.0 + m * pA4[5]) / (totalPositive + m);

                    double[] pA5 = new double[8];
                    double[] pHatA5 = new double[8];
                    pA5[0] = countA5[0] * 1.0 / totalNegative;
                    pA5[1] = countA5[1] * 1.0 / totalNegative;
                    pA5[2] = countA5[2] * 1.0 / totalNegative;
                    pA5[3] = countA5[3] * 1.0 / totalPositive;
                    pA5[4] = countA5[4] * 1.0 / totalPositive;
                    pA5[5] = countA5[5] * 1.0 / totalPositive;
                    pA5[6] = countA5[6] * 1.0 / totalPositive;
                    pA5[7] = countA5[7] * 1.0 / totalPositive;
                    pHatA5[0] = (countA5[0] * 1.0 + m * pA5[0]) / (totalNegative + m);
                    pHatA5[1] = (countA5[1] * 1.0 + m * pA5[1]) / (totalNegative + m);
                    pHatA5[2] = (countA5[2] * 1.0 + m * pA5[2]) / (totalNegative + m);
                    pHatA5[3] = (countA5[3] * 1.0 + m * pA5[3]) / (totalNegative + m);
                    pHatA5[4] = (countA5[4] * 1.0 + m * pA5[4]) / (totalPositive + m);
                    pHatA5[5] = (countA5[5] * 1.0 + m * pA5[5]) / (totalPositive + m);
                    pHatA5[6] = (countA5[6] * 1.0 + m * pA5[6]) / (totalPositive + m);
                    pHatA5[7] = (countA5[7] * 1.0 + m * pA5[7]) / (totalPositive + m);

                    double[] pA6 = new double[4];
                    double[] pHatA6 = new double[4];
                    pA6[0] = countA6[0] * 1.0 / totalNegative;
                    pA6[1] = countA6[1] * 1.0 / totalNegative;
                    pA6[2] = countA6[2] * 1.0 / totalNegative;
                    pA6[3] = countA6[3] * 1.0 / totalPositive;
                    pHatA6[0] = (countA6[0] * 1.0 + m * pA6[0]) / (totalNegative + m);
                    pHatA6[1] = (countA6[1] * 1.0 + m * pA6[1]) / (totalNegative + m);
                    pHatA6[2] = (countA6[2] * 1.0 + m * pA6[2]) / (totalPositive + m);
                    pHatA6[3] = (countA6[3] * 1.0 + m * pA6[3]) / (totalPositive + m);


                    for (int i = 0; i < testingData.Count(); i++)
                    {
                        double PpTest = Pp;
                        double PnTest = Pn;

                        if (testingData[i].Attributes[0] == 1)
                        {
                            PnTest *= pHatA1[0];
                            PpTest *= pHatA1[3];
                        }
                        else if (testingData[i].Attributes[0] == 2)
                        {
                            PnTest *= pHatA1[1];
                            PpTest *= pHatA1[4];
                        }
                        else if (testingData[i].Attributes[0] == 3)
                        {
                            PnTest *= pHatA1[2];
                            PpTest *= pHatA1[5];
                        }

                        if (testingData[i].Attributes[1] == 1)
                        {
                            PnTest *= pHatA2[0];
                            PpTest *= pHatA2[3];
                        }
                        else if (testingData[i].Attributes[1] == 2)
                        {
                            PnTest *= pHatA2[1];
                            PpTest *= pHatA2[4];
                        }
                        else if (testingData[i].Attributes[1] == 3)
                        {
                            PnTest *= pHatA2[2];
                            PpTest *= pHatA2[5];
                        }

                        if (testingData[i].Attributes[2] == 1)
                        {
                            PnTest *= pHatA3[0];
                            PpTest *= pHatA3[2];
                        }
                        else if (testingData[i].Attributes[2] == 2)
                        {
                            PnTest *= pHatA3[1];
                            PpTest *= pHatA3[3];
                        }


                        if (testingData[i].Attributes[3] == 1)
                        {
                            PnTest *= pHatA4[0];
                            PpTest *= pHatA4[3];
                        }
                        else if (testingData[i].Attributes[3] == 2)
                        {
                            PnTest *= pHatA4[1];
                            PpTest *= pHatA4[4];
                        }
                        else if (testingData[i].Attributes[3] == 3)
                        {
                            PnTest *= pHatA4[2];
                            PpTest *= pHatA4[5];
                        }

                        if (testingData[i].Attributes[4] == 1)
                        {
                            PnTest *= pHatA5[0];
                            PpTest *= pHatA5[4];
                        }
                        else if (testingData[i].Attributes[4] == 2)
                        {
                            PnTest *= pHatA5[1];
                            PpTest *= pHatA5[5];
                        }
                        else if (testingData[i].Attributes[4] == 3)
                        {
                            PnTest *= pHatA5[2];
                            PpTest *= pHatA5[6];
                        }
                        else if (testingData[i].Attributes[4] == 4)
                        {
                            PnTest *= pHatA5[3];
                            PpTest *= pHatA5[7];
                        }

                        if (testingData[i].Attributes[5] == 1)
                        {
                            PnTest *= pHatA6[0];
                            PpTest *= pHatA6[2];
                        }
                        else if (testingData[i].Attributes[5] == 2)
                        {
                            PnTest *= pHatA6[1];
                            PpTest *= pHatA6[3];
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
                    double[] pHatTL = new double[6];
                    pTL[0] = countTL[0] * 1.0 / totalNegative;
                    pTL[1] = countTL[1] * 1.0 / totalNegative;
                    pTL[2] = countTL[2] * 1.0 / totalNegative;
                    pTL[3] = countTL[3] * 1.0 / totalPositive;
                    pTL[4] = countTL[4] * 1.0 / totalPositive;
                    pTL[5] = countTL[5] * 1.0 / totalPositive;
                    pHatTL[0] = (countTL[0] * 1.0 + m * pTL[0]) / (totalNegative + m);
                    pHatTL[1] = (countTL[1] * 1.0 + m * pTL[1]) / (totalNegative + m);
                    pHatTL[2] = (countTL[2] * 1.0 + m * pTL[2]) / (totalNegative + m);
                    pHatTL[3] = (countTL[3] * 1.0 + m * pTL[3]) / (totalPositive + m);
                    pHatTL[4] = (countTL[4] * 1.0 + m * pTL[4]) / (totalPositive + m);
                    pHatTL[5] = (countTL[5] * 1.0 + m * pTL[5]) / (totalPositive + m);

                    double[] pTM = new double[6];
                    double[] pHatTM = new double[6];
                    pTM[0] = countTM[0] * 1.0 / totalNegative;
                    pTM[1] = countTM[1] * 1.0 / totalNegative;
                    pTM[2] = countTM[2] * 1.0 / totalNegative;
                    pTM[3] = countTM[3] * 1.0 / totalPositive;
                    pTM[4] = countTM[4] * 1.0 / totalPositive;
                    pTM[5] = countTM[5] * 1.0 / totalPositive;
                    pHatTM[0] = (countTM[0] * 1.0 + m * pTM[0]) / (totalNegative + m);
                    pHatTM[1] = (countTM[1] * 1.0 + m * pTM[1]) / (totalNegative + m);
                    pHatTM[2] = (countTM[2] * 1.0 + m * pTM[2]) / (totalNegative + m);
                    pHatTM[3] = (countTM[3] * 1.0 + m * pTM[3]) / (totalPositive + m);
                    pHatTM[4] = (countTM[4] * 1.0 + m * pTM[4]) / (totalPositive + m);
                    pHatTM[5] = (countTM[5] * 1.0 + m * pTM[5]) / (totalPositive + m);

                    double[] pTR = new double[6];
                    double[] pHatTR = new double[6];
                    pTR[0] = countTR[0] * 1.0 / totalNegative;
                    pTR[1] = countTR[1] * 1.0 / totalNegative;
                    pTR[2] = countTR[2] * 1.0 / totalNegative;
                    pTR[3] = countTR[3] * 1.0 / totalPositive;
                    pTR[4] = countTR[4] * 1.0 / totalPositive;
                    pTR[5] = countTR[5] * 1.0 / totalPositive;
                    pHatTR[0] = (countTR[0] * 1.0 + m * pTR[0]) / (totalNegative + m);
                    pHatTR[1] = (countTR[1] * 1.0 + m * pTR[1]) / (totalNegative + m);
                    pHatTR[2] = (countTR[2] * 1.0 + m * pTR[2]) / (totalNegative + m);
                    pHatTR[3] = (countTR[3] * 1.0 + m * pTR[3]) / (totalPositive + m);
                    pHatTR[4] = (countTR[4] * 1.0 + m * pTR[4]) / (totalPositive + m);
                    pHatTR[5] = (countTR[5] * 1.0 + m * pTR[5]) / (totalPositive + m);

                    double[] pML = new double[6];
                    double[] pHatML = new double[6];
                    pML[0] = countML[0] * 1.0 / totalNegative;
                    pML[1] = countML[1] * 1.0 / totalNegative;
                    pML[2] = countML[2] * 1.0 / totalNegative;
                    pML[3] = countML[3] * 1.0 / totalPositive;
                    pML[4] = countML[4] * 1.0 / totalPositive;
                    pML[5] = countML[5] * 1.0 / totalPositive;
                    pHatML[0] = (countML[0] * 1.0 + m * pML[0]) / (totalNegative + m);
                    pHatML[1] = (countML[1] * 1.0 + m * pML[1]) / (totalNegative + m);
                    pHatML[2] = (countML[2] * 1.0 + m * pML[2]) / (totalNegative + m);
                    pHatML[3] = (countML[3] * 1.0 + m * pML[3]) / (totalPositive + m);
                    pHatML[4] = (countML[4] * 1.0 + m * pML[4]) / (totalPositive + m);
                    pHatML[5] = (countML[5] * 1.0 + m * pML[5]) / (totalPositive + m);

                    double[] pMM = new double[6];
                    double[] pHatMM = new double[6];
                    pMM[0] = countMM[0] * 1.0 / totalNegative;
                    pMM[1] = countMM[1] * 1.0 / totalNegative;
                    pMM[2] = countMM[2] * 1.0 / totalNegative;
                    pMM[3] = countMM[3] * 1.0 / totalPositive;
                    pMM[4] = countMM[4] * 1.0 / totalPositive;
                    pMM[5] = countMM[5] * 1.0 / totalPositive;
                    pHatMM[0] = (countMM[0] * 1.0 + m * pMM[0]) / (totalNegative + m);
                    pHatMM[1] = (countMM[1] * 1.0 + m * pMM[1]) / (totalNegative + m);
                    pHatMM[2] = (countMM[2] * 1.0 + m * pMM[2]) / (totalNegative + m);
                    pHatMM[3] = (countMM[3] * 1.0 + m * pMM[3]) / (totalPositive + m);
                    pHatMM[4] = (countMM[4] * 1.0 + m * pMM[4]) / (totalPositive + m);
                    pHatMM[5] = (countMM[5] * 1.0 + m * pMM[5]) / (totalPositive + m);

                    double[] pMR = new double[6];
                    double[] pHatMR = new double[6];
                    pMR[0] = countMR[0] * 1.0 / totalNegative;
                    pMR[1] = countMR[1] * 1.0 / totalNegative;
                    pMR[2] = countMR[2] * 1.0 / totalNegative;
                    pMR[3] = countMR[3] * 1.0 / totalPositive;
                    pMR[4] = countMR[4] * 1.0 / totalPositive;
                    pMR[5] = countMR[5] * 1.0 / totalPositive;
                    pHatMR[0] = (countMR[0] * 1.0 + m * pMR[0]) / (totalNegative + m);
                    pHatMR[1] = (countMR[1] * 1.0 + m * pMR[1]) / (totalNegative + m);
                    pHatMR[2] = (countMR[2] * 1.0 + m * pMR[2]) / (totalNegative + m);
                    pHatMR[3] = (countMR[3] * 1.0 + m * pMR[3]) / (totalPositive + m);
                    pHatMR[4] = (countMR[4] * 1.0 + m * pMR[4]) / (totalPositive + m);
                    pHatMR[5] = (countMR[5] * 1.0 + m * pMR[5]) / (totalPositive + m);

                    double[] pBL = new double[6];
                    double[] pHatBL = new double[6];
                    pBL[0] = countBL[0] * 1.0 / totalNegative;
                    pBL[1] = countBL[1] * 1.0 / totalNegative;
                    pBL[2] = countBL[2] * 1.0 / totalNegative;
                    pBL[3] = countBL[3] * 1.0 / totalPositive;
                    pBL[4] = countBL[4] * 1.0 / totalPositive;
                    pBL[5] = countBL[5] * 1.0 / totalPositive;
                    pHatBL[0] = (countBL[0] * 1.0 + m * pBL[0]) / (totalNegative + m);
                    pHatBL[1] = (countBL[1] * 1.0 + m * pBL[1]) / (totalNegative + m);
                    pHatBL[2] = (countBL[2] * 1.0 + m * pBL[2]) / (totalNegative + m);
                    pHatBL[3] = (countBL[3] * 1.0 + m * pBL[3]) / (totalPositive + m);
                    pHatBL[4] = (countBL[4] * 1.0 + m * pBL[4]) / (totalPositive + m);
                    pHatBL[5] = (countBL[5] * 1.0 + m * pBL[5]) / (totalPositive + m);

                    double[] pBM = new double[6];
                    double[] pHatBM = new double[6];
                    pBM[0] = countBM[0] * 1.0 / totalNegative;
                    pBM[1] = countBM[1] * 1.0 / totalNegative;
                    pBM[2] = countBM[2] * 1.0 / totalNegative;
                    pBM[3] = countBM[3] * 1.0 / totalPositive;
                    pBM[4] = countBM[4] * 1.0 / totalPositive;
                    pBM[5] = countBM[5] * 1.0 / totalPositive;
                    pHatBM[0] = (countBM[0] * 1.0 + m * pBM[0]) / (totalNegative + m);
                    pHatBM[1] = (countBM[1] * 1.0 + m * pBM[1]) / (totalNegative + m);
                    pHatBM[2] = (countBM[2] * 1.0 + m * pBM[2]) / (totalNegative + m);
                    pHatBM[3] = (countBM[3] * 1.0 + m * pBM[3]) / (totalPositive + m);
                    pHatBM[4] = (countBM[4] * 1.0 + m * pBM[4]) / (totalPositive + m);
                    pHatBM[5] = (countBM[5] * 1.0 + m * pBM[5]) / (totalPositive + m);

                    double[] pBR = new double[6];
                    double[] pHatBR = new double[6];
                    pBR[0] = countBR[0] * 1.0 / totalNegative;
                    pBR[1] = countBR[1] * 1.0 / totalNegative;
                    pBR[2] = countBR[2] * 1.0 / totalNegative;
                    pBR[3] = countBR[3] * 1.0 / totalPositive;
                    pBR[4] = countBR[4] * 1.0 / totalPositive;
                    pBR[5] = countBR[5] * 1.0 / totalPositive;
                    pHatBR[0] = (countBR[0] * 1.0 + m * pBR[0]) / (totalNegative + m);
                    pHatBR[1] = (countBR[1] * 1.0 + m * pBR[1]) / (totalNegative + m);
                    pHatBR[2] = (countBR[2] * 1.0 + m * pBR[2]) / (totalNegative + m);
                    pHatBR[3] = (countBR[3] * 1.0 + m * pBR[3]) / (totalPositive + m);
                    pHatBR[4] = (countBR[4] * 1.0 + m * pBR[4]) / (totalPositive + m);
                    pHatBR[5] = (countBR[5] * 1.0 + m * pBR[5]) / (totalPositive + m);

                    for (int i = 0; i < testingData.Count(); i++)
                    {
                        double PpTest = Pp;
                        double PnTest = Pn;

                        if (testingData[i].Attributes[0] == 0)
                        {
                            PnTest *= pHatTL[0];
                            PpTest *= pHatTL[3];
                        }
                        else if (testingData[i].Attributes[0] == 1)
                        {
                            PnTest *= pHatTL[1];
                            PpTest *= pHatTL[4];
                        }
                        else if (testingData[i].Attributes[0] == 2)
                        {
                            PnTest *= pHatTL[2];
                            PpTest *= pHatTL[5];
                        }

                        if (testingData[i].Attributes[1] == 0)
                        {
                            PnTest *= pHatTM[0];
                            PpTest *= pHatTM[3];
                        }
                        else if (testingData[i].Attributes[1] == 1)
                        {
                            PnTest *= pHatTM[1];
                            PpTest *= pHatTM[4];
                        }
                        else if (testingData[i].Attributes[1] == 2)
                        {
                            PnTest *= pHatTM[2];
                            PpTest *= pHatTM[5];
                        }

                        if (testingData[i].Attributes[2] == 0)
                        {
                            PnTest *= pHatTR[0];
                            PpTest *= pHatTR[3];
                        }
                        else if (testingData[i].Attributes[2] == 1)
                        {
                            PnTest *= pHatTR[1];
                            PpTest *= pHatTR[4];
                        }
                        else if (testingData[i].Attributes[2] == 2)
                        {
                            PnTest *= pHatTR[2];
                            PpTest *= pHatTR[5];
                        }

                        if (testingData[i].Attributes[3] == 0)
                        {
                            PnTest *= pHatML[0];
                            PpTest *= pHatML[3];
                        }
                        else if (testingData[i].Attributes[3] == 1)
                        {
                            PnTest *= pHatML[1];
                            PpTest *= pHatML[4];
                        }
                        else if (testingData[i].Attributes[3] == 2)
                        {
                            PnTest *= pHatML[2];
                            PpTest *= pHatML[5];
                        }

                        if (testingData[i].Attributes[4] == 0)
                        {
                            PnTest *= pHatMM[0];
                            PpTest *= pHatMM[3];
                        }
                        else if (testingData[i].Attributes[4] == 1)
                        {
                            PnTest *= pHatMM[1];
                            PpTest *= pHatMM[4];
                        }
                        else if (testingData[i].Attributes[4] == 2)
                        {
                            PnTest *= pHatMM[2];
                            PpTest *= pHatMM[5];
                        }

                        if (testingData[i].Attributes[5] == 0)
                        {
                            PnTest *= pHatMR[0];
                            PpTest *= pHatMR[3];
                        }
                        else if (testingData[i].Attributes[5] == 1)
                        {
                            PnTest *= pHatMR[1];
                            PpTest *= pHatMR[4];
                        }
                        else if (testingData[i].Attributes[5] == 2)
                        {
                            PnTest *= pHatMR[2];
                            PpTest *= pHatMR[5];
                        }

                        if (testingData[i].Attributes[6] == 0)
                        {
                            PnTest *= pHatBL[0];
                            PpTest *= pHatBL[3];
                        }
                        else if (testingData[i].Attributes[6] == 1)
                        {
                            PnTest *= pHatBL[1];
                            PpTest *= pHatBL[4];
                        }
                        else if (testingData[i].Attributes[6] == 2)
                        {
                            PnTest *= pHatBL[2];
                            PpTest *= pHatBL[5];
                        }

                        if (testingData[i].Attributes[7] == 0)
                        {
                            PnTest *= pHatBM[0];
                            PpTest *= pHatBM[3];
                        }
                        else if (testingData[i].Attributes[7] == 1)
                        {
                            PnTest *= pHatBM[1];
                            PpTest *= pHatBM[4];
                        }
                        else if (testingData[i].Attributes[7] == 2)
                        {
                            PnTest *= pHatBM[2];
                            PpTest *= pHatBM[5];
                        }

                        if (testingData[i].Attributes[8] == 0)
                        {
                            PnTest *= pHatBR[0];
                            PpTest *= pHatBR[3];
                        }
                        else if (testingData[i].Attributes[8] == 1)
                        {
                            PnTest *= pHatBR[1];
                            PpTest *= pHatBR[4];
                        }
                        else if (testingData[i].Attributes[8] == 2)
                        {
                            PnTest *= pHatBR[2];
                            PpTest *= pHatBR[5];
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

                int testCases = testingData.Count();
                double errorV = numErrors * 1.0 / testCases;
                double confidence80 = 1.28;
                double errorDLower80 = errorV - confidence80 * Math.Sqrt((errorV * (1.0 - errorV)) / testCases);
                double errorDUpper80 = errorV + confidence80 * Math.Sqrt((errorV * (1.0 - errorV)) / testCases);
                double confidence60 = 1.0;
                double errorDLower60 = errorV - confidence60 * Math.Sqrt((errorV * (1.0 - errorV)) / testCases);
                double errorDUpper60 = errorV + confidence60 * Math.Sqrt((errorV * (1.0 - errorV)) / testCases);
                double confidence90 = 1.64;
                double errorDLower90 = errorV - confidence90 * Math.Sqrt((errorV * (1.0 - errorV)) / testCases);
                double errorDUpper90 = errorV + confidence90 * Math.Sqrt((errorV * (1.0 - errorV)) / testCases);
                Console.WriteLine("m = " + m);
                Console.WriteLine("Num errors = " + numErrors);
                Console.WriteLine("With 60% confidence errorD(h) = [" + errorDLower60 + ", " + errorDUpper60 + "]");
                Console.WriteLine("With 80% confidence errorD(h) = [" + errorDLower80 + ", " + errorDUpper80 + "]");
                Console.WriteLine("With 90% confidence errorD(h) = [" + errorDLower90 + ", " + errorDUpper90 + "]");
            }
            Console.Read();
        }
    }
}

