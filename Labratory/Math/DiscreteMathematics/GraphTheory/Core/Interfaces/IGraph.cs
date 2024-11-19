namespace Labratory;

public interface IGraph<TNode, TEdge, TKey>
    where TNode : INode<TKey>
    where TEdge : IEdge<TNode, TKey>
{
    public void AddNode(TNode node);
    public void AddEdge(TEdge edge);
}