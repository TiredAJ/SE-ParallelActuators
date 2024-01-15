namespace IngameScript
{
    // This template is intended for extension classes. For most purposes you're going to want a normal
    // utility class.
    // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
    internal static class Extensions
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
    }
}
