using System.Collections.Generic;

namespace CurrencyGraph.Domain
{
    class ScannedGraphResult<TVertex> : IScannedGraphResult<TVertex>
    {
        public TVertex SourceVertex { get; }
        public HashSet<TVertex> MarkedVertices { get; }
        public Dictionary<TVertex, TVertex> VertexToParentVertex { get; }

        public ScannedGraphResult(TVertex sourceVertex, HashSet<TVertex> markedVertices, Dictionary<TVertex, TVertex> vertexToParentVertex)
        {
            SourceVertex = sourceVertex;
            MarkedVertices = markedVertices;
            VertexToParentVertex = vertexToParentVertex;
        }
    }
}