using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw1id3
{
    class TreeNode
    {
        public int Attribute = -50;
        public int Label = -50;

        public List<TreeNode> Children = new List<TreeNode>();

        public void PrintNode(string prefix)
        {
            Console.Write("{0} + ", prefix);
            if (Label != -50)
            {
                Console.Write("Leaf: {0}", Label);
            }
            else if (Attribute != -50)
            {
                Console.Write("Node: {0}", Attribute);
            }
            Console.WriteLine("");
            foreach (TreeNode n in Children)
                if (Children.IndexOf(n) == Children.Count - 1)
                    n.PrintNode(prefix + "    ");
                else
                    n.PrintNode(prefix + "   |");
        }
    }
}
