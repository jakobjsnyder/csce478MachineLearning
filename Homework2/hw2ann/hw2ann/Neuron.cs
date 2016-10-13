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
        public Connection BiasConnection;
        public double DeltaWeight;
        public double PreviousDeltaWeight;
        public double DeltaDiff;
        double BiasConst = 1.0;

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
            sum += BiasConnection.getWeight() * BiasConst;


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

        public void addBiasConnection(Neuron neuron)
        {
            Connection connection = new Connection(neuron, this);
            BiasConnection = connection;
            InConnections.Add(connection);
        }

        public double getBias()
        {
            return BiasConst;
        }

        public double getDeltaWeight()
        {
            return DeltaWeight;
        }

        public void setDeltaWeight(double deltaWeight)
        {
            PreviousDeltaWeight = DeltaWeight;
            DeltaWeight = deltaWeight;
            DeltaDiff = DeltaWeight - PreviousDeltaWeight;
        }

        public void setPreviousDeltaWeight(double previousDeltaWeight)
        {
            PreviousDeltaWeight = previousDeltaWeight;
        }

        public double getPreviousDeltaWeight()
        {
            return PreviousDeltaWeight;
        }
    }
}
