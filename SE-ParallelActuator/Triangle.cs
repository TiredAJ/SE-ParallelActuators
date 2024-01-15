using System;
using System.Collections.Generic;
using System.Linq;

namespace IngameScript
{
    partial class Program
    {
        public class Triangle
        {
            private double?[] Sides { get; set; } = new double?[3]
                {null, null, null };
            private float?[] Angles { get; set; } = new float?[3]
                {null, null, null };

            private Angle[] AvailAngles = new[] { Angle.AB, Angle.BC, Angle.CA };
            private Side[] AvailSides = new[] { Side.A, Side.B, Side.C };

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
            /// Uses the 3 sides to get the desired angle
            /// </summary>
            /// <param name="_Desired">Angle to calculate</param>
            /// <returns>The angle, or null if failed</returns>
            public float? Get_Angle_SSS(Angle _Desired)
            {
                if (Sides.CountNotNull() != 3)
                { return null; }

                var TAngles = AvailAngles
                                    .Where(X => X != _Desired)
                                    .OfType<int>();

                var Squared =
                (
                    Math.Pow((float)Sides[TAngles.First()], 2) +
                    Math.Pow((float)Sides[TAngles.Last()], 2)
                ) - Math.Pow((float)Sides[(int)_Desired], 2);


                var Divd = Squared / (2 * (double)Sides[TAngles.First()] * (double)Sides[TAngles.Last()]);

                return (float)Math.Acos(Divd);
            }

            /// <summary>
            /// Returns the missing Angle
            /// </summary>
            /// <param name="_Missing">Angle to calculate</param>
            /// <returns>The angle</returns>
            public float Get_Angle(Angle _Missing)
            {
                if (Sides.CountNotNull() == 3)
                {

                }
            }

            /// <summary>
            /// Calculates the missing angle
            /// </summary>
            /// <returns></returns>
            /// <exception cref="Exception"></exception>
            public float Get_Angle()
            {
                Angle? TargetAngle = Get_MissingAngle_ID();

                if (TargetAngle == null)
                { throw new Exception("TargetAngle was null!"); }

                Angles[(int)TargetAngle] = Get_Angle((Angle)TargetAngle);

                return (float)Angles[(int)TargetAngle];
            }

            /// <summary>
            /// Calculates the Angle enum of the missing angle
            /// </summary>
            /// <returns>The ID of the missing angle</returns>
            public Angle? Get_MissingAngle_ID()
            {
                List<Angle> CurrentAngles = new List<Angle>();

                if (Angles[(int)Angle.AB] != null)
                { CurrentAngles.Add(Angle.AB); }
                if (Angles[(int)Angle.BC] != null)
                { CurrentAngles.Add(Angle.BC); }
                if (Angles[(int)Angle.CA] != null)
                { CurrentAngles.Add(Angle.CA); }

                if (CurrentAngles.Count > 2)
                { return null; }
                else if (CurrentAngles.Count < 2)
                { return null; }
                else
                { return CurrentAngles.First() ^ CurrentAngles.Last(); }
            }

            /// <summary>
            /// Calculates the degrees of the missing angle
            /// </summary>
            /// <returns>The degrees of the missing angle</returns>
            public float? Get_MissingAngle_Deg()
            {
                List<float> CurrentAngles = new List<float>();

                CurrentAngles = Angles
                                .Where(X => X != null)
                                .OfType<float>()
                                .ToList();

                if (CurrentAngles.Count > 2)
                { return null; }
                else if (CurrentAngles.Count < 2)
                { return null; }
                else
                { return 180 - (CurrentAngles.First() + CurrentAngles.Last()); }
            }
        }

        public enum Side : int
        {
            A = 1,
            B = 2,
            C = 3
        }

        public enum Angle : int
        {
            AB = 1,
            BC = 2,
            CA = 3
        }
    }
}

