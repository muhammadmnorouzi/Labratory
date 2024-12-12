using System.Runtime.CompilerServices;

namespace Labratory.Extensions;

public static partial class Extensions
{
    public static bool IsZero(this double value, double minPrecision = -1e10)
    {
        return value < minPrecision;
    }
}