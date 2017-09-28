namespace GraphApi
{
    using System.Collections.Generic;

    using GraphApi.Interfaces;

    internal class ScannedGraphResult<TVertex, TEdge> : IScannedGraphResult<TVertex, TEdge>
        where TEdge : IUndirectedEdge<TVertex>
    {
        public ScannedGraphResult(
            TVertex sourceVertex,
            HashSet<TVertex> markedVertices,
            Dictionary<TVertex, TEdge> vertexToParentEdge)
        {
            this.SourceVertex = sourceVertex;
            this.MarkedVertices = markedVertices;
            this.VertexToParentEdge = vertexToParentEdge;
        }

        public HashSet<TVertex> MarkedVertices { get; }

        public TVertex SourceVertex { get; }

        public Dictionary<TVertex, TEdge> VertexToParentEdge { get; }
    }
}