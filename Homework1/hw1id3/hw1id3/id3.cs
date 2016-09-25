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
                    else if (i== 7)
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

            for(int j = 0; j < fullData.Count; j++)
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

            //test the tree using test array

            //output error

        }

        private static TreeNode generateTree(List<Element> trainingData)
        {
            List<int> availableAttributes = new List<int>();

            // this is created in order 
            for (int i = 0; i < trainingData.First().Attributes.Count; i++)
                availableAttributes.Add(i);


            

            throw new NotImplementedException();

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
    }
}
