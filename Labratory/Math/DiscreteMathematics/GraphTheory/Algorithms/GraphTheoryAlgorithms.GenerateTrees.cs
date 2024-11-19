using System.Diagnostics;

namespace Labratory.Math.DiscreteMathematics.GraphTheory.Algorithms;

public static partial class GraphTheoryAlgorithms
{
    public static IEnumerable<IEnumerable<int>> GeneratePruferSequence(int vertices)
    {
        // TODO Throw exception
        Debug.Assert(vertices >= 3);

        int seqSize = vertices - 2;

        foreach (IEnumerable<int> seq in GeneratePruferSequenceInternal(seqSize, [.. Enumerable.Range(1, vertices)], []))
        {
            yield return seq;
        }
    }

    private static IEnumerable<IEnumerable<int>> GeneratePruferSequenceInternal(
        int seqSize,
        List<int> nonVisited,
        List<int> current)
    {
        if (seqSize == current.Count)
        {
            yield return current;
        }
        else
        {
            foreach (int i in nonVisited)
            {
                foreach (var item in GeneratePruferSequenceInternal(seqSize, nonVisited,[.. current , i]))
                {
                    yield return item;
                }
            }
        }
    }
}