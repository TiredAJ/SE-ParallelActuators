namespace MathsTester;

public static class Extensions
{
    /// <summary>
    /// Determines if any elements are null
    /// </summary>
    /// <returns>True if any are null, false otherwise</returns>
    public static bool AnyNull(this double?[] _Arr)
    {
        foreach (var V in _Arr)
        {
            if (V == null)
            { return true; }
        }

        return false;
    }

    public static int CountNotNull(this double?[] _Arr)
    { return _Arr.Count(X => X != null); }

    public static int CountNotNull(this float?[] _Arr)
    { return _Arr.Count(X => X != null); }

    public static bool InRange(this int _Val)
    {
        if (_Val < 1 || _Val > 3)
        { return false; }
        else
        { return true; }
    }

    public static double RadToDeg(this double _Val) =>
        _Val * (180 / Math.PI);

    public static float RadToDeg(this float _Val) =>
        _Val * (180 / (float)Math.PI);
}
