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

        private Random random = new Random();

        public NeuralNetwork.NeuralNetwork nn;

        private InputNeuron inHeading;
        private InputNeuron inVelocityAngle;
        private InputNeuron inVelocityLength;
        private InputNeuron inNextCheckpointAngle0;
        private InputNeuron inNextCheckpointAngle1;
        private InputNeuron inNextCheckpointAngle2;
        private InputNeuron inNextCheckpointAngle3;
        private InputNeuron inNextCheckpointAngle4;
        private InputNeuron inNextCheckpointAngle5;
        private InputNeuron inNextCheckpointDistance;

        private OutputNeuron outHeading0;
        private OutputNeuron outHeading1;
        private OutputNeuron outHeading2;
        private OutputNeuron outHeading3;
        private OutputNeuron outHeading4;
        private OutputNeuron outHeading5;
        private OutputNeuron outThrust;

        public PilotC()
        {
            nn = CreateNn();
        }

        private NeuralNetwork.NeuralNetwork CreateNn()
        {
            NeuralNetwork.NeuralNetwork nn;

            nn = new NeuralNetwork.NeuralNetwork();

            InputLayer inputLayer = nn.CreateInputLayer();

            //inHeading = inputLayer.CreateNeuron("heading");
            //inVelocityAngle = inputLayer.CreateNeuron("v_angle");
            //inVelocityLength = inputLayer.CreateNeuron("v_length");
            inNextCheckpointAngle0 = inputLayer.CreateNeuron("c_angle0");
            inNextCheckpointAngle1 = inputLayer.CreateNeuron("c_angle1");
            inNextCheckpointAngle2 = inputLayer.CreateNeuron("c_angle2");
            inNextCheckpointAngle3 = inputLayer.CreateNeuron("c_angle3");
            inNextCheckpointAngle4 = inputLayer.CreateNeuron("c_angle4");
            inNextCheckpointAngle5 = inputLayer.CreateNeuron("c_angle5");
            //inNextCheckpointDistance = inputLayer.CreateNeuron("c_dist");

            OutputLayer outputLayer = nn.CreateOutputLayer();

            outHeading0 = outputLayer.CreateNeuron("o_heading0");
            outHeading1 = outputLayer.CreateNeuron("o_heading1");
            outHeading2 = outputLayer.CreateNeuron("o_heading2");
            outHeading3 = outputLayer.CreateNeuron("o_heading3");
            outHeading4 = outputLayer.CreateNeuron("o_heading4");
            outHeading5 = outputLayer.CreateNeuron("o_heading5");
            //outThrust = outputLayer.CreateNeuron("o_thrust");

            for (int i = 0; i < 1; i++)
            {
                HiddenLayer hiddenLayer = nn.CreateHiddenLayer();

                for (int j = 0; j < 16; j++)
                {
                    HiddenNeuron hiddenNeuron = hiddenLayer.CreateNeuron(string.Format("hidden[{0}][{1}]", i, j));
                }
            }

            nn.CreateFullConnections();
            nn.InitWithRandomValues();

            return nn;
        }

        public PilotC(NeuralNetwork.NeuralNetwork nn)
        {
            if (nn == null)
            {
                this.nn = CreateNn();
            }
            else
            {
                this.nn = nn;


                inNextCheckpointAngle0 = (InputNeuron)nn.InputLayer.Neurons[0];
                inNextCheckpointAngle1 = (InputNeuron)nn.InputLayer.Neurons[1];
                inNextCheckpointAngle2 = (InputNeuron)nn.InputLayer.Neurons[2];
                inNextCheckpointAngle3 = (InputNeuron)nn.InputLayer.Neurons[3];
                inNextCheckpointAngle4 = (InputNeuron)nn.InputLayer.Neurons[4];
                inNextCheckpointAngle5 = (InputNeuron)nn.InputLayer.Neurons[5];
                //inNextCheckpointDistance = (InputNeuron)nn.InputLayer.Neurons[1];

                outHeading0 = (OutputNeuron)nn.OutputLayer.Neurons[0];
                outHeading1 = (OutputNeuron)nn.OutputLayer.Neurons[1];
                outHeading2 = (OutputNeuron)nn.OutputLayer.Neurons[2];
                outHeading3 = (OutputNeuron)nn.OutputLayer.Neurons[3];
                outHeading4 = (OutputNeuron)nn.OutputLayer.Neurons[4];
                outHeading5 = (OutputNeuron)nn.OutputLayer.Neurons[5];
            }
        }

        private class Heading
        {
            public double HeadingValue { get; set; }
            public double Angle { get; set; }

            public override string ToString()
            {
                return string.Format("{0}/{1}", HeadingValue, Angle);
            }
        }

        public PodRacerCommand EvaluateCommand(Race race)
        {
            PodRacerCommand command;

            //command = new PodRacerCommand()
            //{
            //    Thrust = 100,
            //    Destination = new Vector(0,0)
            //};

            CheckPoint currentCheckPoint = race.
                RaceState.
                PodRacerRaceStates[PodRacer].
                CurrentCheckPoint;

            //inHeading.SetInput(PodRacer.Heading / 360);
            //inVelocityAngle.SetInput(PodRacer.Velocity.GetAngle() / 360);
            //inVelocityLength.SetInput(Math.Min(PodRacer.Velocity.Length, 1000) / 1000);

            Vector toCurrentCheckpoint = PodRacer.Position - currentCheckPoint.Position;
            int angle = (int)Math.Round(PodRacer.Orientation.GetAngle(toCurrentCheckpoint));

            if (angle < -18)
            {
                angle = -18;
            }

            if (angle > 18)
            {
                angle = 18;
            }

            angle = angle + 18;

            if ((angle & 1) == 1)
            {
                inNextCheckpointAngle0.SetInput(1);
            }
            else
            {
                inNextCheckpointAngle0.SetInput(0);
            }
            if ((angle & 2) == 2)
            {
                inNextCheckpointAngle1.SetInput(1);
            }
            else
            {
                inNextCheckpointAngle1.SetInput(0);
            }
            if ((angle & 4) == 4)
            {
                inNextCheckpointAngle2.SetInput(1);
            }
            else
            {
                inNextCheckpointAngle2.SetInput(0);
            }
            if ((angle & 8) == 8)
            {
                inNextCheckpointAngle3.SetInput(1);
            }
            else
            {
                inNextCheckpointAngle3.SetInput(0);
            }
            if ((angle & 16) == 16)
            {
                inNextCheckpointAngle4.SetInput(1);
            }
            else
            {
                inNextCheckpointAngle4.SetInput(0);
            }
            if ((angle & 32) == 32)
            {
                inNextCheckpointAngle5.SetInput(1);
            }
            else
            {
                inNextCheckpointAngle5.SetInput(0);
            }


            //inNextCheckpointDistance.SetInput(Math.Min(toCurrentCheckpoint.Length, 100000) / 100000);

            nn.UpdateOutput();

            //List<Heading> headings = new List<Heading>();

            //headings.Add(new Heading() { HeadingValue = outHeading0.Output, Angle = 0 });
            //headings.Add(new Heading() { HeadingValue = outHeading1.Output, Angle = -9 });
            //headings.Add(new Heading() { HeadingValue = outHeading2.Output, Angle = -18 });
            //headings.Add(new Heading() { HeadingValue = outHeading3.Output, Angle = 9 });
            //headings.Add(new Heading() { HeadingValue = outHeading4.Output, Angle = 18 });

            //List<Heading> sorted = headings.OrderBy(h => h.HeadingValue).ToList();

            double heading = 0;

            if (outHeading0.Output >= 0.5) heading += 1;
            if (outHeading1.Output >= 0.5) heading += 2;
            if (outHeading2.Output >= 0.5) heading += 4;
            if (outHeading3.Output >= 0.5) heading += 8;
            if (outHeading4.Output >= 0.5) heading += 16;
            if (outHeading5.Output >= 0.5) heading += 32;

            heading = heading / 63.0 * 36.0 - 18.0;

            //heading = sorted.First().Angle;

            //double thrust = outThrust.Output;
            double thrust = 0.3;

            Vector destination = 1600 * PodRacer.Orientation;
            destination = PodRacer.Position + destination.Rotate(heading);

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
