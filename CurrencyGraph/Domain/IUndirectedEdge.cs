namespace CurrencyGraph.Domain
{
    interface IUndirectedEdge<TVertex>
    {
        TVertex GetOtherVertex(TVertex currentVertex);
        bool ContainVertex(TVertex vertex);
    }
}