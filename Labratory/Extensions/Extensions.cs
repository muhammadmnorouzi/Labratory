using System.Runtime.CompilerServices;

namespace Labratory.Extensions;

public static class Extensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Not(this bool b)
    {
        return !b;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool And(this bool a, bool b)
    {
        return a && b;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Or(this bool a, bool b)
    {
        return a || b;
    }
}