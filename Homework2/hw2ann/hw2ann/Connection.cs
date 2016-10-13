using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2ann
{
    class Connection
    {
        public double Weight = .2;
        public Neuron LeftNeuron;
        public Neuron RightNeuron;
        //private static int counter = 0;
        //public int Id;

        public Connection(Neuron fromN, Neuron toN)
        {
            LeftNeuron = fromN;
            RightNeuron = toN;
            //Id = counter;
            //counter++;
        }

        public double getWeight()
        {
            return Weight;
        }

        public void setWeight(double weight)
        {
            Weight = weight;
        }

        public Neuron getLeftNeuron()
        {
            return LeftNeuron;
        }

        public Neuron getRightNeuron()
        {
            return RightNeuron;
        }
    }
}
