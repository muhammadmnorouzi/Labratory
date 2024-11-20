using System.Diagnostics.CodeAnalysis;
using Labratory.Extensions;

namespace Labratory.Math.DiscreteMathematics.GraphTheory;

public class Graph : IGraph<Node, Edge, int>
{
    private readonly HashSet<Node> _nodes = [];
    private readonly HashSet<Edge> _edges = [];
    private readonly Dictionary<Node, HashSet<Edge>> _mappings = [];

    public void AddNode(Node node)
    {
        if (_nodes.Contains(node).Not())
        {
            _nodes.Add(node);
            _mappings[node] = [];
        }
    }

    public void AddEdge(Edge edge)
    {
        AddNode(edge.N1);
        AddNode(edge.N2);

        if (_mappings[edge.N1].Contains(edge).Not().Or(_mappings[edge.N2].Contains(edge).Not()))
        {
            _mappings[edge.N1].Add(edge);
            _mappings[edge.N2].Add(edge);
        }

        if (_edges.Contains(edge).Not())
        {
            _edges.Add(edge);
        }
    }

    public IEnumerable<Node> Nodes() => _nodes;
    public IEnumerable<Edge> EdgesOf(Node node) => _mappings[node];
    public IEnumerable<Edge> Edges() => _edges;


    public static Graph From(IEnumerable<Edge> input)
    {
        Graph g = new();

        foreach (Edge e in input)
        {
            g.AddEdge(e);
        }

        return g;
    }

    public void Print(TextWriter stream)
    {
        foreach (Node node in Nodes())
        {
            stream.Write($" {node} => ");

            foreach (Edge edge in EdgesOf(node))
            {
                stream.Write($"{edge.Other(node)} | ");
            }

            stream.WriteLine();
        }
    }
}
