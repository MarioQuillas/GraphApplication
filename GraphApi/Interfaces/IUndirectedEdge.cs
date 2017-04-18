namespace GraphApi.Interfaces
{
    public interface IUndirectedEdge<TVertex>
    {
        //TODO : A better design should be return a Maybe<TVertex>
        TVertex GetOtherVertex(TVertex currentVertex);
        bool ContainVertex(TVertex vertex);
    }
}