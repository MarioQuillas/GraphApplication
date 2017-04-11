using System.Collections.Generic;

namespace CurrencyGraph.Domain
{
    internal interface IUndirectedGraph<TVertex, TEdge> where TEdge : IUndirectedEdge<TVertex>
    {
        IEnumerable<TEdge> GetAdjacentsToVertex(TVertex vertex);
    }
}