﻿using System;
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
        private InputNeuron inNextCheckpointAngle;
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
            inNextCheckpointAngle = inputLayer.CreateNeuron("c_angle");
            inNextCheckpointDistance = inputLayer.CreateNeuron("c_dist");

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


                inNextCheckpointAngle = (InputNeuron)nn.InputLayer.Neurons[0];
                inNextCheckpointDistance = (InputNeuron)nn.InputLayer.Neurons[1];

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
            inNextCheckpointAngle.SetInput(currentCheckPoint.Position.GetAngle(PodRacer.Position) / 120);
            inNextCheckpointDistance.SetInput(Math.Min((PodRacer.Position - currentCheckPoint.Position).Length, 100000) / 30000);

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
            if (outHeading3.Output >= 0.5) heading += 7;
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
