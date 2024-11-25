namespace Labratory.Generics;

public static class Extensions
{
    public static IEnumerable<IDictionary<T, T>> Permutate<T>(this IEnumerable<T> values) where T : notnull
    {
        List<T> distinctValues = values
        .Distinct()
        .ToList();

        foreach (IEnumerable<T> permutation in PermutateInternal(distinctValues, []))
        {
            yield return distinctValues
                .Zip(permutation, (key, value) => (key, value))
                .ToDictionary(pair => pair.key, pair => pair.value);
        }
    }

    private static IEnumerable<IEnumerable<T>> PermutateInternal<T>(List<T> remaining, List<T> current)
    {
        if (remaining.Count == 0)
        {
            yield return current;
        }
        else
        {
            for (int i = 0; i < remaining.Count; i++)
            {
                List<T> nextCurrent = [.. current, remaining[i]];

                List<T> nextRemaining = [.. remaining];
                nextRemaining.RemoveAt(i);

                foreach (IEnumerable<T> result in PermutateInternal(nextRemaining, nextCurrent))
                {
                    yield return result;
                }
            }
        }
    }

}