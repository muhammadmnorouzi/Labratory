using System.Diagnostics;
using Labratory.Mathematics.Discrete.GraphTheory.Core.Concretes;

namespace Labratory.Mathematics.Discrete.GraphTheory.Algorithms;

public static partial class Algorithms
{
    public static bool IsGraphic(params int[] seq)
    {
        // TODO throw exception
        Debug.Assert(seq.All(item => item >= 0), "Negative values are not allowed in graphics sequences");

        seq = [.. seq.OrderDescending()];

        int i = 0;

        while (seq[i] > 0)
        {
            int k = seq[i];
            seq[i] -= k;

            for (int j = i + 1; j < seq.Length && k != 0; ++j)
            {
                --seq[j];
                --k;

                if (seq[j] < 0)
                {
                    return false;
                }
            }

            if (k != 0)
            {
                return false;
            }

            ++i;
        }

        return true;
    }

    public static Graph GenerateFromGraphicSequence(params int[] seq)
    {
        // TODO throw exception
        Debug.Assert(IsGraphic(seq), "Input sequence is not graphic!");

        seq = [.. seq.OrderDescending()];

        Graph graph = new();

        for (int i = 0; i < seq.Length; ++i)
        {
            graph.AddNode(i);
            int k = seq[i];
            seq[i] -= k;

            if (k == 0)
            {
                continue;
            }

            while (k > 0)
            {
                graph.AddEdge((i, i + k));
                --seq[i + k];
                --k;
            }
        }

        Debug.Assert(seq.All(item => item == 0) , "Failed to generate graph properly!");

        return graph;
    }
}