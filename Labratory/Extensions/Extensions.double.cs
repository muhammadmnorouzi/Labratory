namespace Labratory.Extensions;

public static partial class Extensions
{
    public static bool IsZero(this double value, double minPrecision = 1e-10)
    {
        return value < minPrecision;
    }
}