namespace GraphApi.Interfaces
{
    public interface IUndirectedEdge<TVertex>
    {
        bool ContainVertex(TVertex vertex);

        // TODO : A better design should be return a Maybe<TVertex>
        TVertex GetOtherVertex(TVertex currentVertex);
    }
}