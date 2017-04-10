using System.Collections.Generic;

namespace CurrencyGraph.Domain
{
    class TraverserResultfactory<TVertex> : ITraverserResultfactory<TVertex>
    {
        public IScannedGraphResult<TVertex> CreateResult(TVertex sourceVertex, HashSet<TVertex> markedVertices,
            Dictionary<TVertex, TVertex> vertexToParentVertex)
        {
            return new ScannedGraphResult<TVertex>(sourceVertex, markedVertices, vertexToParentVertex);
        }
    }
}