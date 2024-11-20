using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace Labratory.Helpers;

public static class Helpers
{
    public static int CombineHash<TData>(params TData[] keys) where TData : notnull => CombineHash(keys, sort: true);

    public static int CombineHash<TData>(TData[] keys, bool sort)
        where TData : notnull
    {
        int[] hashes = keys
            .Select(x => x.GetHashCode())
            .ToArray();

        if (sort)
        {
            Array.Sort(hashes);
        }

        string combined = string.Join('-', hashes);
        byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(combined));
        return Encoding.UTF8.GetString(hash).GetHashCode();
    }
}