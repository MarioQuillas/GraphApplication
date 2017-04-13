using System;
using System.Collections.Generic;

namespace CurrencyGraph.Domain
{
    class ScannerResultfactory<TVertex, TEdge> : IScannerResultfactory<TVertex, TEdge>
        where TEdge : IUndirectedEdge<TVertex>
    {
        public IScannedGraphResult<TVertex, TEdge> CreateResult(TVertex sourceVertex, HashSet<TVertex> markedVertices,
            Dictionary<TVertex, TEdge> vertexToParentEdge)
        {
            return new ScannedGraphResult<TVertex, TEdge>(sourceVertex, markedVertices, vertexToParentEdge);
        }
    }
}