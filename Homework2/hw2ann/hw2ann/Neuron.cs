using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2ann
{
    class Neuron
    {
        double OutputValue;
        List<Connection> InConnections = new List<Connection>();

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
            return 1 / (1 + Math.Pow(Math.E, -sum));
        }

        public void addInConnection(Neuron inNeuron)
        {
            InConnections.Add(new Connection(inNeuron, this));
        }

        public void addInConnections(List<Neuron> inNeurons)
        {
            foreach(Neuron neuron in inNeurons)
            {
                InConnections.Add(new Connection(neuron, this));
            }
        }
    }
}
