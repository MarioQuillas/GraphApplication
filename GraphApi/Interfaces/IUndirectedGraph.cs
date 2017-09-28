namespace GraphApi.Interfaces
{
    using System.Collections.Generic;

    public interface IUndirectedGraph<TVertex, TEdge>
        where TEdge : IUndirectedEdge<TVertex>
    {
        IEnumerable<TEdge> GetAdjacentsToVertex(TVertex vertex);
    }
}