using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using hw2ann;

// created by Jakob Snyder(jsnyde) and Clayton Henderson(chenders)

namespace hw2ann
{
    class Parser
    {
        private static List<Element> parseTicTac()
        {
            List<Element> fullData = new List<Element>();
            string line;

            // Read the file and display it line by line.
            StreamReader file = new StreamReader("tic-tac-toe.data");
            while ((line = file.ReadLine()) != null)
            {
                int clas;
                List<int> attri = new List<int>();
                line = line.Trim();
                var split = line.Split(',');
                clas = (split.Last().Equals("positive"))?1:0;
                int i = 0;
                foreach (string item in split)
                {
                    switch (item)
                    {
                        case "b":
                            attri.Add(0);
                            break;
                        case "x":
                            attri.Add(1);
                            break;
                        case "o":
                            attri.Add(2);
                            break;
                    }
                }
                fullData.Add(new Element(clas, attri));
            }

            file.Close();
            return fullData;
        }


        private static List<Element> parseMonk()
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
                        i++;
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

        private static List<Element> parsePoker()
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
                clas = (Convert.ToInt32(split.Last()) <= 4) ? 0 : 1;// we changed this to decent vs amazing hands because we could not implement non binary labels.
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

        private static List<Element> parseVote()
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
                                attri.Add(2);
                                break;
                        }
                    }
                }
                fullData.Add(new Element(clas, attri));
            }

            file.Close();
            return fullData;
        }

        public static List<Element> parseData(int selectData)
        {
            switch (selectData)
            {
                case 1:
                    return parseMonk();
                case 2:
                    return parseVote();
                case 3:
                    return parseTicTac();
                case 4:
                    return parsePoker();

            }
            return null;

        }

        
    }
}
