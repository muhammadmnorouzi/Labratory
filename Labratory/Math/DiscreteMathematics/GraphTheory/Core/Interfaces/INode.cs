namespace Labratory;

public interface INode<TKey> : IComparable<INode<TKey>>, IEquatable<INode<TKey>>
{
    TKey Id { get; }
}
