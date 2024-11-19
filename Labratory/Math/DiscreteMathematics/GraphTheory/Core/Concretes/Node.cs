namespace Labratory;

public struct Node(int data) : INode<int>
{
    public int Id { get; private set; } = data;

    public readonly int CompareTo(INode<int>? other)
    {
        return Id.CompareTo(other?.Id);
    }

    public readonly bool Equals(INode<int>? other)
    {
        return CompareTo(other) == 0;
    }

    public override readonly string ToString()
    {
        return Id.ToString();
    }

    public static implicit operator Node(int id)
    {
        return new Node(id);
    }

    public override readonly int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
