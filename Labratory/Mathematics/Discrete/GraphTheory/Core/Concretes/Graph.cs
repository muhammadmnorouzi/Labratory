using Labratory.Extensions;
using Labratory.Mathematics.Discrete.GraphTheory.Core.Interfaces;

namespace Labratory.Mathematics.Discrete.GraphTheory.Core.Concretes;

public class Graph : IGraph<Node, Edge, int>
{
    private readonly HashSet<Node> _nodes = [];
    private readonly List<Edge> _edges = [];
    private readonly Dictionary<Node, List<Edge>> _mappings = [];

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

        _mappings[edge.N1].Add(edge);
        _mappings[edge.N2].Add(edge);
        _edges.Add(edge);
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
