using System.Diagnostics.CodeAnalysis;
using Labratory.Extensions;

namespace Labratory;

public struct Edge(Node n1, Node n2) : IEdge<Node, int>
{
    public Node N1 { get; private set; } = n1;
    public Node N2 { get; private set; } = n2;

    public readonly Edge Reverse()
    {
        return new Edge(N2, N1);
    }

    public override string ToString()
    {
        return $"<{N1} - {N2}>";
    }

    public readonly Node Other(Node node)
    {
        if (node.Equals(N1))
        {
            return N2;
        }
        else if (node.Equals(N2))
        {
            return N1;
        }
        else
        {
            // TODO Throw Proper Exception
            throw new NotImplementedException();
        }
    }

    public override readonly int GetHashCode()
    {
        return Helpers.Helpers.CombineHash(N1, N2);
    }

    public override readonly bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is Edge edge && GetHashCode() == edge.GetHashCode();
    }

    public static bool operator ==(Edge left, Edge right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Edge left, Edge right)
    {
        return left.Equals(right).Not();
    }
}
