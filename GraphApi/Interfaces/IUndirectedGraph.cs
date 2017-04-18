using System.Collections.Generic;

namespace GraphApi.Interfaces
{
    public interface IUndirectedGraph<TVertex, TEdge> where TEdge : IUndirectedEdge<TVertex>
    {
        IEnumerable<TEdge> GetAdjacentsToVertex(TVertex vertex);
    }
}