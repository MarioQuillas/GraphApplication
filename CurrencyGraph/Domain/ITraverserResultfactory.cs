using System.Collections.Generic;

namespace CurrencyGraph.Domain
{
    internal interface ITraverserResultfactory<TVertex>
    {
        IScannedGraphResult<TVertex> CreateResult
            (TVertex sourceVertex, HashSet<TVertex> markedVertices, Dictionary<TVertex, TVertex> vertexToParentVertex);
    }
}