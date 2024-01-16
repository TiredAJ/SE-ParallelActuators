namespace MathsTester;

public class Program
{
    static void Main(string[] args)
    {
        Triangle T = new Triangle() { Sides = new double?[] { 8, 6, 7 } };

        var R = T.Get_Angle_SSS(Angle.C);
    }
}

public class Triangle
{
    public double?[] Sides { get; set; } = new double?[3]
        {null, null, null };
    public float?[] Angles { get; set; } = new float?[3]
        {null, null, null };

    private int[] AvailAngles = new[] { Angle.A, Angle.B, Angle.C };
    private int[] AvailSides = new[] { Side.a, Side.b, Side.c };

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
            (S - (double)Sides[Side.a]) *
            (S - (double)Sides[Side.b]) *
            (S - (double)Sides[Side.c])
        );
    }

    /// <summary>
    /// Uses the 3 sides to get the desired angle
    /// </summary>
    /// <param name="_Desired">Angle to calculate</param>
    /// <returns>The angle, or null if failed</returns>
    public float? Get_Angle_SSS(int _Desired)
    {
        if (Sides.CountNotNull() != 3)
        { return null; }
        if (!_Desired.InRange())
        { return null; }

        List<int> TAngles = new List<int>(AvailAngles);

        TAngles.RemoveAt(_Desired - 1);

        double[] Squared =
        {
            Math.Pow((float)Sides[Angle.A -1], 2),
            Math.Pow((float)Sides[Angle.B -1], 2),
            Math.Pow((float)Sides[Angle.C -1], 2)
        };

        double Mixed =
        (
            Squared[TAngles.First() - 1] +
            Squared[TAngles.Last() - 1] -
            Squared[_Desired - 1]
        );


        var Divd = Mixed / (2d * (double)Sides[TAngles.First() - 1] * (double)Sides[TAngles.Last() - 1]);

        return (float)Math.Acos(Divd).RadToDeg();
    }

    /// <summary>
    /// Returns the missing Angle
    /// </summary>
    /// <param name="_Missing">Angle to calculate</param>
    /// <returns>The angle</returns>
    public float Get_Angle(int _Missing)
    {
        throw new Exception();

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
        int? TargetAngle = Get_MissingAngle_ID();

        if (TargetAngle == null)
        { throw new Exception("TargetAngle was null!"); }

        Angles[(int)TargetAngle] = Get_Angle((int)TargetAngle);

        return (float)Angles[(int)TargetAngle];
    }

    /// <summary>
    /// Calculates the Angle enum of the missing angle
    /// </summary>
    /// <returns>The ID of the missing angle</returns>
    public int? Get_MissingAngle_ID()
    {
        List<int> CurrentAngles = new List<int>();

        if (Angles[Angle.A] != null)
        { CurrentAngles.Add(Angle.A); }
        if (Angles[Angle.B] != null)
        { CurrentAngles.Add(Angle.B); }
        if (Angles[Angle.C] != null)
        { CurrentAngles.Add(Angle.C); }

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

public static class Side
{
    public static int a = 1;
    public static int b = 2;
    public static int c = 3;
}

public static class Angle
{
    public static int A = 1;
    public static int B = 2;
    public static int C = 3;
}
