namespace CurrencyGraph.Domain
{
    interface IUndirectedEdge<TVertex>
    {
        //TODO : A better design should be return a Maybe<TVertex>
        TVertex GetOtherVertex(TVertex currentVertex);
        bool ContainVertex(TVertex vertex);
    }
}