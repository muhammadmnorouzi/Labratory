namespace Labratory.Mathematics.Discrete.GraphTheory.Core.Interfaces;

public interface IGraph<TNode, TEdge, TKey>
    where TNode : INode<TKey>
    where TEdge : IEdge<TNode, TKey>
{
    void AddNode(TNode node);
    void AddEdge(TEdge edge);
}