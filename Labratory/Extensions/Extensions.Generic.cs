namespace Labratory.Extensions;

public static partial class Extensions
{
    public static IEnumerable<IDictionary<T, T>> Permutations<T>(this IEnumerable<T> values)
        where T : notnull
    {
        var distinctValues = values
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

    public static IEnumerable<IEnumerable<T>> Permutations<T>(IEnumerable<T> list, int length)
    {
        return length == 1
            ? list.Select(t => new T[] { t })
            : Permutations(list, length - 1)
            .SelectMany(t => list.Where(e => !t.Contains(e)),
                        (t1, t2) => t1.Concat(new T[] { t2 }));
    }

    public static IEnumerable<IEnumerable<T>> Combinations<T>(IEnumerable<T> list, int length)
    {
        if (length == 0)
        {
            yield return new T[0];
        }

        var enumerable = list.ToList();

        for (int i = 0; i < enumerable.Count; i++)
        {
            IEnumerable<T> head = enumerable.Skip(i).Take(1);
            IEnumerable<IEnumerable<T>> tailCombinations = Combinations(enumerable.Skip(i + 1), length - 1);
            foreach (IEnumerable<T> tail in tailCombinations)
            {
                yield return head.Concat(tail);
            }
        }
    }
}