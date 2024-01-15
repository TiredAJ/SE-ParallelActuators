using System;
using System.Collections.Generic;
using System.Linq;

namespace IngameScript
{
    partial class Program
    {
        public class Triangle
        {
            public double?[] Sides { get; set; } = new double?[3]
                {null, null, null };
            public float?[] Angles { get; set; } = new float?[3]
                {null, null, null };

            public Triangle()
            { }

            /// <summary>
            /// Gets the area of this triangle using Heron's formula.
            /// Requires all 3 sides
            /// </summary>
            /// <returns>The area</returns>
            /// <exception cref="NullReferenceException">Thrown when any side is null</exception>
            public double Area_Heron()
            {
                if (Sides.AnyNull())
                { throw new NullReferenceException("A side was null!"); }

                double S = ((double)Sides.Sum() / 2d);

                return Math.Sqrt
                (d:
                    S *
                    (S - (double)Sides[(int)Side.A]) *
                    (S - (double)Sides[(int)Side.B]) *
                    (S - (double)Sides[(int)Side.C])
                );
            }

            /// <summary>
            /// Returns the missing Angle
            /// </summary>
            /// <param name="_Missing">Angle to calculate</param>
            /// <returns>The angle</returns>
            public float Get_Angle(Angle _Missing)
            {
                float CurrentSides =
            }

            public float Get_Angle()
            {
                //float[] TAngles = Angles
                //                    .Where(X => X != null)
                //                    .OfType<float>()
                //                    .ToArray();

                //if (TAngles.Count(X => X != null) < 2)
                //{

                //}

                Angle TargetAngle;



                if (Angles[(int)Angle.AB] != null && Angles[(int)Angle.BC] != null)
                { TargetAngle = Angle.CA; }
                else if (Angles[(int)Angle.BC] != null && Angles[(int)Angle.CA] != null)
                { TargetAngle = Angle.AB; }
                else if (Angles[(int)Angle.CA] != null && Angles[(int)Angle.AB] != null)
                { TargetAngle = Angle.BC; }
                else
                { throw new NullReferenceException("An angle is null!"); }

                return Get_Angle(TargetAngle);
            }

            public Angle Get_MissingSide()
            {
                List<Angle> CurrentAngles = new List<Angle>();

                if (Angles[(int)Angle.AB] != null)
                { CurrentAngles.Add(Angle.AB); }
                if (Angles[(int)Angle.BC] != null)
                { CurrentAngles.Add(Angle.BC); }
                if (Angles[(int)Angle.CA] != null)
                { CurrentAngles.Add(Angle.CA); }

                if (CurrentAngles.Count > 2)
                {
                    //return Angle.Null??
                }
                else if (CurrentAngles.Count < 2)
                {
                    //throw?
                }
                else
                {

                }
            }
        }

        public enum Side : int
        {
            A,
            B,
            C
        }

        public enum Angle : int
        {
            AB = 1,
            BC = 2,
            CA = 3
        }
    }
}

