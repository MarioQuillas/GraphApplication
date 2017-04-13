using System.Collections.Generic;

namespace CurrencyGraph.Domain
{
    internal class ScannedGraphResult<TVertex, TEdge> : IScannedGraphResult<TVertex, TEdge>
        where TEdge : IUndirectedEdge<TVertex>
    {
        public TVertex SourceVertex { get; }
        public HashSet<TVertex> MarkedVertices { get; }
        public Dictionary<TVertex, TEdge> VertexToParentEdge { get; }

        public ScannedGraphResult(TVertex sourceVertex, HashSet<TVertex> markedVertices,
            Dictionary<TVertex, TEdge> vertexToParentEdge)
        {
            this.SourceVertex = sourceVertex;
            this.MarkedVertices = markedVertices;
            this.VertexToParentEdge = vertexToParentEdge;
        }
    }
}