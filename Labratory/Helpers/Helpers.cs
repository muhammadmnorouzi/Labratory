using System.Security.Cryptography;
using System.Text;

namespace Labratory.Helpers;

public static class Helpers
{
    public static int CombineHash<TData>(params TData[] keys) where TData : notnull => CombineHash(keys, sort: true);

    public static int CombineHash<TData>(TData[] keys, bool sort)
        where TData : notnull
    {
        string?[] string_keys = keys
            .Select(x => x.ToString())
            .ToArray();

        if (sort)
        {
            Array.Sort(string_keys);
        }

        string combined = string.Concat(string_keys);
        byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(combined));

        return Convert.ToHexStringLower(hash).GetHashCode();
    }
}