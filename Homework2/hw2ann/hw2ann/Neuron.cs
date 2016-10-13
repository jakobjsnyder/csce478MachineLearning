using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2ann
{
    class Neuron
    {
        public double OutputValue;
        public List<Connection> InConnections = new List<Connection>();

        public Neuron(double initialOutputValue)
        {
            OutputValue = initialOutputValue;
        }
        public Neuron()
        {

        }

        public double getOutputValue()
        {
            return OutputValue;
        }

        public void setOutputValue(double outputValue)
        {
            OutputValue = outputValue;
        }

        public void calculateOutputValue()
        {
            double sum = 0.0;
            foreach(Connection connection in InConnections)
            {
                Neuron left = connection.LeftNeuron;
                double weight = connection.getWeight();
                double leftNeuronOutputValue = left.OutputValue;

                sum += weight * leftNeuronOutputValue;
            }


            OutputValue = sigmoid(sum);
        }

        private static double sigmoid(double sum)
        {
            return 1.0 / (1.0 + Math.Exp(-sum));
        }

        public void addInConnection(Neuron inNeuron)
        {
            InConnections.Add(new Connection(inNeuron, this));
        }

        



        public void setDeltaWs(double deltaW)
        {

            for (int i = 0; i < InConnections.Count; i++)
            {
                InConnections[i].PreviousDeltaWeight = InConnections[i].DeltaWeight;
                InConnections[i].DeltaWeight = deltaW;
                InConnections[i].DeltaDiff = InConnections[i].DeltaWeight - InConnections[i].PreviousDeltaWeight;
            }
        }
    }
}
