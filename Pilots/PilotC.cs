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
        private InputNeuron inNextCheckpointDistance0;
        private InputNeuron inNextCheckpointDistance1;
        private InputNeuron inNextCheckpointDistance2;
        private InputNeuron inNextCheckpointDistance3;
        private InputNeuron inNextCheckpointAngle0;
        private InputNeuron inNextCheckpointAngle1;
        private InputNeuron inNextCheckpointAngle2;
        private InputNeuron inNextCheckpointAngle3;
        private InputNeuron inNextCheckpointAngle4;
        private InputNeuron inNextCheckpointAngle5;
        private InputNeuron inNextNextCheckpointAngle0;
        private InputNeuron inNextNextCheckpointAngle1;
        private InputNeuron inNextNextCheckpointAngle2;
        private InputNeuron inNextNextCheckpointAngle3;
        private InputNeuron inNextNextCheckpointAngle4;
        private InputNeuron inNextNextCheckpointAngle5;
        private InputNeuron inNextCheckpointDistance;

        private OutputNeuron outHeading0;
        private OutputNeuron outHeading1;
        private OutputNeuron outHeading2;
        private OutputNeuron outHeading3;
        private OutputNeuron outHeading4;
        private OutputNeuron outHeading5;
        private OutputNeuron outThrust0;
        private OutputNeuron outThrust1;
        private OutputNeuron outThrust2;
        private OutputNeuron outThrust3;
        private OutputNeuron outThrust4;
        private OutputNeuron outThrust5;
        private OutputNeuron outThrust6;

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
            inNextCheckpointDistance0 = inputLayer.CreateNeuron("c_dist0");
            inNextCheckpointDistance1 = inputLayer.CreateNeuron("c_dist1");
            inNextCheckpointDistance2 = inputLayer.CreateNeuron("c_dist2");
            inNextCheckpointDistance3 = inputLayer.CreateNeuron("c_dist3");
            inNextCheckpointAngle0 = inputLayer.CreateNeuron("c_angle0");
            inNextCheckpointAngle1 = inputLayer.CreateNeuron("c_angle1");
            inNextCheckpointAngle2 = inputLayer.CreateNeuron("c_angle2");
            inNextCheckpointAngle3 = inputLayer.CreateNeuron("c_angle3");
            inNextCheckpointAngle4 = inputLayer.CreateNeuron("c_angle4");
            inNextCheckpointAngle5 = inputLayer.CreateNeuron("c_angle5");
            inNextNextCheckpointAngle0 = inputLayer.CreateNeuron("nnc_angle0");
            inNextNextCheckpointAngle1 = inputLayer.CreateNeuron("nnc_angle1");
            inNextNextCheckpointAngle2 = inputLayer.CreateNeuron("nnc_angle2");
            inNextNextCheckpointAngle3 = inputLayer.CreateNeuron("nnc_angle3");
            inNextNextCheckpointAngle4 = inputLayer.CreateNeuron("nnc_angle4");
            inNextNextCheckpointAngle5 = inputLayer.CreateNeuron("nnc_angle5");
            //inNextCheckpointDistance = inputLayer.CreateNeuron("c_dist");

            OutputLayer outputLayer = nn.CreateOutputLayer();

            outHeading0 = outputLayer.CreateNeuron("o_heading0");
            outHeading1 = outputLayer.CreateNeuron("o_heading1");
            outHeading2 = outputLayer.CreateNeuron("o_heading2");
            outHeading3 = outputLayer.CreateNeuron("o_heading3");
            outHeading4 = outputLayer.CreateNeuron("o_heading4");
            outHeading5 = outputLayer.CreateNeuron("o_heading5");
            outThrust0 = outputLayer.CreateNeuron("o_thrust0");
            outThrust1 = outputLayer.CreateNeuron("o_thrust1");
            outThrust2 = outputLayer.CreateNeuron("o_thrust2");
            outThrust3 = outputLayer.CreateNeuron("o_thrust3");
            outThrust4 = outputLayer.CreateNeuron("o_thrust4");
            outThrust5 = outputLayer.CreateNeuron("o_thrust5");
            outThrust6 = outputLayer.CreateNeuron("o_thrust6");

            for (int i = 0; i < 3; i++)
            {
                HiddenLayer hiddenLayer = nn.CreateHiddenLayer();

                for (int j = 0; j < 32; j++)
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


                inNextCheckpointDistance0 = (InputNeuron)nn.InputLayer.Neurons[0];
                inNextCheckpointDistance1 = (InputNeuron)nn.InputLayer.Neurons[1];
                inNextCheckpointDistance2 = (InputNeuron)nn.InputLayer.Neurons[2];
                inNextCheckpointDistance3 = (InputNeuron)nn.InputLayer.Neurons[3];

                inNextCheckpointAngle0 = (InputNeuron)nn.InputLayer.Neurons[4];
                inNextCheckpointAngle1 = (InputNeuron)nn.InputLayer.Neurons[5];
                inNextCheckpointAngle2 = (InputNeuron)nn.InputLayer.Neurons[6];
                inNextCheckpointAngle3 = (InputNeuron)nn.InputLayer.Neurons[7];
                inNextCheckpointAngle4 = (InputNeuron)nn.InputLayer.Neurons[8];
                inNextCheckpointAngle5 = (InputNeuron)nn.InputLayer.Neurons[9];

                inNextNextCheckpointAngle0 = (InputNeuron)nn.InputLayer.Neurons[10];
                inNextNextCheckpointAngle1 = (InputNeuron)nn.InputLayer.Neurons[11];
                inNextNextCheckpointAngle2 = (InputNeuron)nn.InputLayer.Neurons[12];
                inNextNextCheckpointAngle3 = (InputNeuron)nn.InputLayer.Neurons[13];
                inNextNextCheckpointAngle4 = (InputNeuron)nn.InputLayer.Neurons[14];
                inNextNextCheckpointAngle5 = (InputNeuron)nn.InputLayer.Neurons[15];
                //inNextCheckpointDistance = (InputNeuron)nn.InputLayer.Neurons[1];

                outHeading0 = (OutputNeuron)nn.OutputLayer.Neurons[0];
                outHeading1 = (OutputNeuron)nn.OutputLayer.Neurons[1];
                outHeading2 = (OutputNeuron)nn.OutputLayer.Neurons[2];
                outHeading3 = (OutputNeuron)nn.OutputLayer.Neurons[3];
                outHeading4 = (OutputNeuron)nn.OutputLayer.Neurons[4];
                outHeading5 = (OutputNeuron)nn.OutputLayer.Neurons[5];

                outThrust0 = (OutputNeuron)nn.OutputLayer.Neurons[6];
                outThrust1 = (OutputNeuron)nn.OutputLayer.Neurons[7];
                outThrust2 = (OutputNeuron)nn.OutputLayer.Neurons[8];
                outThrust3 = (OutputNeuron)nn.OutputLayer.Neurons[9];
                outThrust4 = (OutputNeuron)nn.OutputLayer.Neurons[10];
                outThrust5 = (OutputNeuron)nn.OutputLayer.Neurons[11];
                outThrust6 = (OutputNeuron)nn.OutputLayer.Neurons[12];
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

            double distanceToCurrentCheckPoint = toCurrentCheckpoint.Length;

            if (distanceToCurrentCheckPoint < 500)
            {
                inNextCheckpointDistance0.SetInput(1);
            }
            else
            {
                inNextCheckpointDistance0.SetInput(-1);
            }

            if (distanceToCurrentCheckPoint < 1500)
            {
                inNextCheckpointDistance1.SetInput(1);
            }
            else
            {
                inNextCheckpointDistance1.SetInput(-1);
            }

            if (distanceToCurrentCheckPoint < 3000)
            {
                inNextCheckpointDistance2.SetInput(1);
            }
            else
            {
                inNextCheckpointDistance2.SetInput(-1);
            }

            if (distanceToCurrentCheckPoint < 10000)
            {
                inNextCheckpointDistance3.SetInput(1);
            }
            else
            {
                inNextCheckpointDistance3.SetInput(-1);
            }

            int angle;

            angle = (int)Math.Round(PodRacer.Orientation.GetAngle(toCurrentCheckpoint));

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
                inNextCheckpointAngle0.SetInput(-1);
            }
            if ((angle & 2) == 2)
            {
                inNextCheckpointAngle1.SetInput(1);
            }
            else
            {
                inNextCheckpointAngle1.SetInput(-1);
            }
            if ((angle & 4) == 4)
            {
                inNextCheckpointAngle2.SetInput(1);
            }
            else
            {
                inNextCheckpointAngle2.SetInput(-1);
            }
            if ((angle & 8) == 8)
            {
                inNextCheckpointAngle3.SetInput(1);
            }
            else
            {
                inNextCheckpointAngle3.SetInput(-1);
            }
            if ((angle & 16) == 16)
            {
                inNextCheckpointAngle4.SetInput(1);
            }
            else
            {
                inNextCheckpointAngle4.SetInput(-1);
            }
            if ((angle & 32) == 32)
            {
                inNextCheckpointAngle5.SetInput(1);
            }
            else
            {
                inNextCheckpointAngle5.SetInput(-1);
            }

            Vector toCurrentNextCheckpoint = PodRacer.Position - race.Arena.GetNextCheckPoint(currentCheckPoint).Position;

            angle = (int)Math.Round(PodRacer.Orientation.GetAngle(toCurrentNextCheckpoint));

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
                inNextNextCheckpointAngle0.SetInput(1);
            }
            else
            {
                inNextNextCheckpointAngle0.SetInput(-1);
            }
            if ((angle & 2) == 2)
            {
                inNextNextCheckpointAngle1.SetInput(1);
            }
            else
            {
                inNextNextCheckpointAngle1.SetInput(-1);
            }
            if ((angle & 4) == 4)
            {
                inNextNextCheckpointAngle2.SetInput(1);
            }
            else
            {
                inNextNextCheckpointAngle2.SetInput(-1);
            }
            if ((angle & 8) == 8)
            {
                inNextNextCheckpointAngle3.SetInput(1);
            }
            else
            {
                inNextNextCheckpointAngle3.SetInput(-1);
            }
            if ((angle & 16) == 16)
            {
                inNextNextCheckpointAngle4.SetInput(1);
            }
            else
            {
                inNextNextCheckpointAngle4.SetInput(-1);
            }
            if ((angle & 32) == 32)
            {
                inNextNextCheckpointAngle5.SetInput(1);
            }
            else
            {
                inNextNextCheckpointAngle5.SetInput(-1);
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

            double thrust = 0;

            if (outThrust0.Output >= 0.5) thrust += 1;
            if (outThrust1.Output >= 0.5) thrust += 2;
            if (outThrust2.Output >= 0.5) thrust += 4;
            if (outThrust3.Output >= 0.5) thrust += 8;
            if (outThrust4.Output >= 0.5) thrust += 16;
            if (outThrust5.Output >= 0.5) thrust += 32;
            if (outThrust6.Output >= 0.5) thrust += 64;

            thrust = thrust / 127.0 * 100.0;

            Vector destination = 1600 * PodRacer.Orientation;
            destination = PodRacer.Position + destination.Rotate(heading);

            command = new PodRacerCommand()
            {
                Thrust = (int)(thrust),
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
