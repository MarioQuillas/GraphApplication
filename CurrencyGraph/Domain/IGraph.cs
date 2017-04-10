using System.Collections.Generic;

namespace CurrencyGraph.Domain
{
    internal interface IGraph<TVertex>
    {
        IEnumerable<TVertex> GetAdjacentsToVertex(TVertex vertex);
    }
}