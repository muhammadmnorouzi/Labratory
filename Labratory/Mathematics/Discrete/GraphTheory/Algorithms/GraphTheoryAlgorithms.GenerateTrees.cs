using System.Diagnostics;
using Labratory.Extensions;
using Labratory.Mathematics.Discrete.GraphTheory.Core.Concretes;

namespace Labratory.Mathematics.Discrete.GraphTheory.Algorithms;

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

    public static IEnumerable<Graph> GenerateTrees(int vertices)
    {
        // TODO Throw exception
        Debug.Assert(vertices >= 3);

        foreach (IEnumerable<int> seq in GeneratePruferSequence(vertices))
        {
            yield return GenerateTreeOfPruferSequence(seq, validate: false);
        }
    }

    private static Graph GenerateTreeOfPruferSequence(IEnumerable<int> seq, bool validate = true)
    {
        if (validate)
        {
            // TODO Throw exception
            Debug.Assert(IsValidPruferSequence(seq));
        }

        int vertexCount = seq.Count() + 2;
        List<int> vertices = [.. Enumerable.Range(1, vertexCount).Order()];
        List<Edge> edges = [];

        foreach (int v in seq)
        {
            int index = 0;
            int minV = vertices[index];

            while (true)
            {
                if (minV != v && edges.Contains(new(minV, v)).Not())
                {
                    break;
                }

                index++;
                minV = vertices[index];
            }

            edges.Add(new(minV, v));
            vertices.RemoveAt(index);
        }


        // TODO Throw exception
        Debug.Assert(vertices.Count == 2);

        edges.Add(new(vertices[0], vertices[1]));

        return Graph.From(edges);
    }

    public static bool IsValidPruferSequence(IEnumerable<int> seq)
    {
        // TODO Throw exception
        Debug.Assert(seq.Any());

        int seqSize = seq.Count();
        int vertexCount = seqSize + 2;

        return seq.All(x => x >= 1 && x <= vertexCount);
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
                foreach (var item in GeneratePruferSequenceInternal(seqSize, nonVisited, [.. current, i]))
                {
                    yield return item;
                }
            }
        }
    }
}