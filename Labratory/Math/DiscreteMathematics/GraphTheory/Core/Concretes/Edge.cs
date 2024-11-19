namespace Labratory;

public struct Edge(Node n1, Node n2) : IEdge<Node, int>
{
    public Node N1 { get; private set; } = n1;
    public Node N2 { get; private set; } = n2;

    public readonly Edge Reverse()
    {
        return new Edge(N2, N1);
    }

    public override readonly int GetHashCode()
    {
        return Helpers.Helpers.CombineHash(N1, N2);
    }

    public readonly bool Equals(IEdge<Node, int>? other)
    {
        return this.N1.Equals(other?.N1) && this.N2.Equals(other?.N2);
    }
}
