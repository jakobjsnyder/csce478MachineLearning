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
        public double DeltaWeight;
        public double PreviousDeltaWeight;
        public double DeltaDiff;
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

        public double getDeltaWeight()
        {
            return DeltaWeight;
        }

        public void setDeltaWeight(double deltaWeight)
        {
            DeltaWeight = deltaWeight;
        }

        public void setPreviousDeltaWeight(double previousDeltaWeight)
        {
            PreviousDeltaWeight = previousDeltaWeight;
        }

        public double getPreviousDeltaWeight()
        {
            return PreviousDeltaWeight;
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
