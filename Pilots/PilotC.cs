using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGame;
using NeuralNetwork;

namespace Pilots
{
    public class PilotC : IPilot
    {
        public PodRacer PodRacer { get; set; }

        private Random random;

        private NeuralNetwork.NeuralNetwork nn;

        private InputNeuron inHeading;
        private InputNeuron inVelocityAngle;
        private InputNeuron inVelocityLength;
        private InputNeuron inNextCheckpointAngle;
        private InputNeuron inNextCheckpointDistance;

        private OutputNeuron outHeading;
        private OutputNeuron outThrust;

        public PilotC()
        {
            random = new Random();

            nn = new NeuralNetwork.NeuralNetwork();

            InputLayer inputLayer = nn.CreateInputLayer();

            inHeading = inputLayer.CreateNeuron();
            inVelocityAngle = inputLayer.CreateNeuron();
            inVelocityLength = inputLayer.CreateNeuron();
            inNextCheckpointAngle = inputLayer.CreateNeuron();
            inNextCheckpointDistance = inputLayer.CreateNeuron();

            OutputLayer outputLayer = nn.CreateOutputLayer();

            outHeading = outputLayer.CreateNeuron();
            outThrust = outputLayer.CreateNeuron();

            for (int i = 0; i < 2; i++)
            {
                HiddenLayer hiddenLayer = nn.CreateHiddenLayer();

                for (int j = 0; j < 8; j++)
                {
                    HiddenNeuron hiddenNeuron = hiddenLayer.CreateNeuron();
                }
            }

            nn.CreateFullConnections();

            Storage.WriteNeuralNetworkToFile(nn, @"c:\temp\network.bin");
        }

        public PodRacerCommand EvaluateCommand(Race race)
        {
            PodRacerCommand command;

            //command = new PodRacerCommand()
            //{
            //    Thrust = 100,
            //    Destination = new Vector(0,0)
            //};

            inHeading.SetInput(PodRacer.Heading);
            inVelocityAngle.SetInput(PodRacer.Velocity.GetAngle());
            inVelocityLength.SetInput(PodRacer.Velocity.LengthSquared);
            inNextCheckpointAngle.SetInput(0);
            inNextCheckpointDistance.SetInput(0);

            nn.UpdateOutput();

            double heading = outHeading.Output;
            double thrust = outThrust.Output;

            Vector destination = new Vector(1600);
            destination = PodRacer.Position +  destination.Rotate(heading * 360);

            command = new PodRacerCommand()
            {
                Thrust = (int)(thrust * 100),
                Destination = destination
            };

            //command = new PodRacerCommand()
            //{
            //    Thrust = random.Next(0, 10),
            //    Destination = race.
            //    RaceState.
            //    PodRacerRaceStates[PodRacer].
            //    CurrentCheckPoint.
            //    Position
            //};

            return command;
        }
    }
}
