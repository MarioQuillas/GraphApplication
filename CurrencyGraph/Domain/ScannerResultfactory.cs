using System.Collections.Generic;

namespace CurrencyGraph.Domain
{
    class ScannerResultfactory<TVertex> : IScannerResultfactory<TVertex>
    {
        public IScannedGraphResult<TVertex> CreateResult(TVertex sourceVertex, HashSet<TVertex> markedVertices,
            Dictionary<TVertex, TVertex> vertexToParentVertex)
        {
            return new ScannedGraphResult<TVertex>(sourceVertex, markedVertices, vertexToParentVertex);
        }
    }
}