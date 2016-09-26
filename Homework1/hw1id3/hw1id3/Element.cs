using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// created by Jakob Snyder(jsnyde) and Clayton Henderson(chenders)

namespace hw1id3
{
    class Element
    {
        public int Label;
        public List<int> Attributes;

        public Element(int label, List<int> attributes)
        {
            Label = label;
            Attributes = attributes;
        }
    }
}
