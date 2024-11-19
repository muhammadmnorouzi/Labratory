using Labratory.Extensions;

namespace Labratory.Math.DiscreteMathematics.GraphTheory;

public class Graph : IGraph<Node, Edge, int>
{
    private HashSet<Node> _nodes { get; set; } = [];
    private Dictionary<Node, HashSet<Edge>> _edges { get; set; } = [];

    public void AddNode(Node node)
    {
        if (_nodes.Contains(node).Not())
        {
            _nodes.Add(node);
            _edges[node] = [];
        }
    }

    public void AddEdge(Edge edge)
    {
        AddNode(edge.N1);
        AddNode(edge.N2);

        if (_edges[edge.N1].Contains(edge).Not().And(_edges[edge.N2].Contains(edge)))
        {
            _edges[edge.N1].Add(edge);
            _edges[edge.N2].Add(edge);
        }
    }
}
