using System.Diagnostics.CodeAnalysis;
using Labratory.Extensions;
using Labratory.Mathematics.Discrete.GraphTheory.Core.Interfaces;

namespace Labratory.Mathematics.Discrete.GraphTheory.Core.Concretes;

public struct Node(int data) : INode<int>
{
    public int Id { get; private set; } = data;

    public override readonly bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is Node node && GetHashCode() == node.GetHashCode();
    }

    public override readonly int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override readonly string ToString()
    {
        return $"{Id}";
    }

    public static implicit operator Node(int id)
    {
        return new Node(id);
    }

    public static bool operator ==(Node node1, Node node2)
    {
        return node1.Equals(node2);
    }

    public static bool operator !=(Node node1, Node node2)
    {
        return node1.Equals(node2).Not();
    }
}
