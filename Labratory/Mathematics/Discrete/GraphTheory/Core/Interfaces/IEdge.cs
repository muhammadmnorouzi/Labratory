namespace Labratory.Mathematics.Discrete.GraphTheory.Core.Interfaces;

public interface IEdge<TNode, TKey>
    where TNode : INode<TKey>
{
    TNode N1 { get; }
    TNode N2 { get; }
}
