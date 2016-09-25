using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hw1id3
{
    class id3
    {
        static List<Element> parseMonk()
        {
            List<Element> fullData = new List<Element>();
            string line;

            // Read the file and display it line by line.
            StreamReader file = new StreamReader("monks.data");
            while ((line = file.ReadLine()) != null)
            {
                int clas;
                List<int> attri = new List<int>();
                line = line.Trim();
                var split = line.Split(' ');
                clas = Convert.ToInt32(split.First());
                int i = 0;
                foreach (var item in split)
                {
                    if (i == 0)
                    {
                        i++;
                    }
                    else if (i == 7)
                    {
                        attri.Add(Convert.ToInt32(item.Split('_')[1]));
                    }
                    else
                    {
                        attri.Add(Convert.ToInt32(item));
                        i++;
                    }
                }
                fullData.Add(new Element(clas, attri));
            }

            file.Close();
            return fullData;
        }

        static List<Element> parsePoker()
        {
            List<Element> fullData = new List<Element>();
            string line;

            // Read the file and display it line by line.
            StreamReader file = new StreamReader("poker.data");
            while ((line = file.ReadLine()) != null)
            {
                int clas;
                List<int> attri = new List<int>();
                line = line.Trim();
                var split = line.Split(',');
                clas = Convert.ToInt32(split.Last());
                int i = 0;
                foreach (var item in split)
                {
                    if (i != 10)
                    {
                        attri.Add(Convert.ToInt32(item));
                        i++;
                    }
                }
                fullData.Add(new Element(clas, attri));
            }

            file.Close();
            return fullData;
        }

        static List<Element> parseVote()
        {
            List<Element> fullData = new List<Element>();
            string line;

            // Read the file and display it line by line.
            StreamReader file = new StreamReader("vote.data");
            while ((line = file.ReadLine()) != null)
            {
                int clas;
                List<int> attri = new List<int>();
                line = line.Trim();
                var split = line.Split(',');

                // 0 if a democrat and 1 if republican
                clas = split.First().Equals("democrat") ? 0 : 1;
                int i = 0;
                foreach (var item in split)
                {
                    if (i == 0)
                    {
                        i++;
                    }
                    else
                    {
                        switch (item.ToString())
                        {
                            case "y":
                                attri.Add(0);
                                break;
                            case "n":
                                attri.Add(1);
                                break;
                            default:
                                attri.Add(-1);
                                break;
                        }
                    }
                }
                fullData.Add(new Element(clas, attri));
            }

            file.Close();
            return fullData;
        }
        static void Main(string[] args)
        {
            //parse the data
            //command line arg 1 = monks, 2 = voting, 3 = poker
            //int selectData = Convert.ToInt32(args[0]);
            int selectData = 2;

            List<Element> fullData = new List<Element>();

            fullData = parseData(selectData);

            //split into training and testing data

            List<Element> trainingData = new List<Element>();
            List<Element> testingData = new List<Element>();
            List<int> trainingInts = new List<int>();



            Random rnd = new Random();
            for (int i = 0; i <= 30; i++)
            {
                trainingInts.Add(rnd.Next(fullData.Count));
            }

            for (int j = 0; j < fullData.Count; j++)
            {
                if (trainingInts.Contains(j))
                {
                    testingData.Add(fullData[j]);
                }
                else
                {
                    trainingData.Add(fullData[j]);
                }
            }

            Console.WriteLine("suhhh");

            //create disicsion tree using id3

            TreeNode root = generateTree(trainingData);

            //print out tree????
            Console.WriteLine("dudeeee");

            //test the tree using test array

            //output error

        }

        private static TreeNode generateTree(List<Element> trainingData)
        {
            TreeNode node = new TreeNode();
            int count0 = 0;
            int count1 = 0;
            foreach (Element e in trainingData)
            {
                if(e.Label == 1)
                {
                    count1++;
                }
                else if(e.Label == 0)
                {
                    count0++;
                }
            }
            if(count0 == trainingData.Count)
            {
                node.label = 0;
                return node;
            }
            else if(count1 == trainingData.Count)
            {
                node.label = 1;
                return node;
            }

            int splitIndex = splitAttribute(trainingData);

            List<int> APV = new List<int>();

            foreach(Element e in trainingData)
            {
                if (!APV.Contains(e.Attributes[splitIndex]))
                {
                    APV.Add(e.Attributes[splitIndex]);
                }
            }
            List<List<Element>> childData = new List<List<Element>>();
            int count =0;
            foreach(int i in APV)
            {
                childData.Add(new List<Element>());
                foreach(Element e in trainingData)
                {
                    if (e.Attributes[splitIndex] == i)
                    {
                        childData[count].Add(e);
                    }

                }
                count++;
                
            }
            foreach(Element e in trainingData)
            {
                e.Attributes[splitIndex] = -2;
            }

            foreach(var dataset in childData)
            {
                node.children.Add(generateTree(dataset));
            }
            return node;
        }

        private static int splitAttribute(List<Element> trainingData)
        {
            List<int> attributes = new List<int>();
            //foreach (int att in trainingData[0].Attributes)
            //{
            //    attributes.Add(att);
            //}
            for (int x = 0; x < trainingData[0].Attributes.Count; x++)
            {
                attributes.Add(x);
            }

            double MinEnt = 2;
            int splitIndex = -1;

            foreach (int attribute in attributes)
            {
                double thisEntropy = calculateEntropy(trainingData, attribute);
                if (thisEntropy < MinEnt)
                {
                    splitIndex = attribute;
                    MinEnt = thisEntropy;
                }
            }
            return splitIndex;
        }

        private double log2(double x)
        {
            return Math.Log(x) / Math.Log(2);
        }

        private static List<Element> parseData(int selectData)
        {
            switch (selectData)
            {
                case 1:
                    return parseMonk();
                case 2:
                    return parseVote();
                case 3:
                    return parsePoker();

            }
            return null;

        }
        //private static void ID3Algorithm(List<Element> trainingData)
        //{
        //    List<int> attributes = new List<int>();
        //    //foreach (int att in trainingData[0].Attributes)
        //    //{
        //    //    attributes.Add();
        //    //}
        //    for(int x =0; x <= trainingData[0].Attributes.Count; x++)
        //    {
        //        attributes.Add(x);
        //    }
        //    int bestAttributeSplitIndex = getBestAttribute(trainingData, attributes);
        //    //split on attribute
        //    TreeNode root = new TreeNode();
        //    root.attribute = bestAttributeSplitIndex;
        //    //generate tree for each subset 
        //}
        //private static int getBestAttribute(List<Element> trainingData, List<int> attributes)
        //{
        //    double MinEnt = 2;
        //    int splitIndex = -1;

        //    foreach (int attribute in attributes)
        //    {
        //        double thisEntropy = calculateEntropy(trainingData, attribute);
        //        if (thisEntropy < MinEnt)
        //        {
        //            splitIndex = attribute;
        //            MinEnt = thisEntropy;
        //        }
        //    }
        //    return splitIndex;
        //}
        public static double calculateEntropy(List<Element> trainingData, int attributeIndex)
        {
            double N_m = trainingData.Count;
            double N_mj = 0;        //num of attribute with specific value
            double Weight = 0;

            List<int> PossibleAttributeVals = new List<int>();

            foreach (Element e in trainingData)
            {
                if (!PossibleAttributeVals.Contains(e.Attributes[attributeIndex]) && e.Attributes[attributeIndex] != -2)
                {
                    PossibleAttributeVals.Add(e.Attributes[attributeIndex]);
                }
            }       //create a list of all possible attribute vals

            double weightedEntropySum = 0;
            foreach (int i in PossibleAttributeVals)
            {
                N_mj = 0;
                int N0_mj = 0;
                int N1_mj = 0;

                foreach (Element e in trainingData)
                {
                    if (e.Attributes[attributeIndex] == i)
                    {
                        N_mj++;
                        if (e.Label == 0)
                        {
                            N0_mj++;
                        }
                        if (e.Label == 1)
                        {
                            N1_mj++;
                        }
                    }
                }
                Weight = N_mj / N_m;

                double p0_mj = N0_mj / N_mj;
                double p1_mj = N1_mj / N_mj;

                double entropySum = p0_mj * Math.Log(p0_mj, 2) + p1_mj * Math.Log(p1_mj, 2);
                weightedEntropySum += -1 * (Weight * entropySum);
            }
            return weightedEntropySum;
        }
    }
}
