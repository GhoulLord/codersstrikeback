using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class PodRacerMechanics
    {
        private IRaceRules raceRules;

        public PodRacerMechanics(IRaceRules raceRules)
        {
            this.raceRules = raceRules;
        }

        private double LimitRotationToMaxRotationSpeed(PodRacer podRacer, double rotation)
        {
            rotation = Helper.LimitDoubleToAbsValue(rotation, podRacer.PodRacerPhysics.MAX_ROTATION_SPEED);

            return rotation;
        }

        public void RotatePodRacerToPosition(PodRacer podRacer, Vector position)
        {
            Vector to = position - podRacer.Position;

            double angle = podRacer.Orientation.GetAngle(to);

            angle = LimitRotationToMaxRotationSpeed(podRacer, angle);

            podRacer.Rotate(angle);
        }

        public void AcceleratePodRacer(PodRacer podRacer, double thrust)
        {
            if ((thrust < podRacer.PodRacerPhysics.MIN_THRUST) || (thrust > podRacer.PodRacerPhysics.MAX_THRUST))
            {
                throw new ArgumentOutOfRangeException("PodRacer thrust out of range!");
            }

            podRacer.Thrust = thrust;
            podRacer.Accelerate(1.0);
        }

        public void BoostPodRacer(PodRacer podRacer)
        {
            AcceleratePodRacer(podRacer, podRacer.PodRacerPhysics.BOOST_THRUST);
        }

        public void ApplyFractionToPodRacer(PodRacer podRacer)
        {
            podRacer.ApplyFraction(podRacer.PodRacerPhysics.FRACTION_FACTOR);
        }

        public void Bounce(PodRacer unitA, PodRacer unitB)
        {
            Vector relativePosition = unitA.Position - unitB.Position;
            Vector relativeVelocity = unitA.Velocity - unitB.Velocity;
            double massFactor = (unitA.Mass + unitB.Mass) / (unitA.Mass * unitB.Mass);
            Vector impulse =
                (
                  (relativeVelocity * relativePosition) /
                  relativePosition.LengthSquared
                ) *
                relativePosition /
                massFactor;
            double impulseFactor;

            if (impulse.Length < raceRules.MIN_HALF_IMPULSE)
            {
                impulseFactor = 1.0 + raceRules.MIN_HALF_IMPULSE / impulse.Length;
            }
            else
            {
                impulseFactor = 2.0;
            }

            unitA.Velocity = unitA.Velocity - (impulseFactor / unitA.Mass) * impulse;
            unitB.Velocity = unitB.Velocity + (impulseFactor / unitB.Mass) * impulse;
        }


    }
}
