using System;
using GraphApi.Interfaces;

namespace GraphApi
{
    internal class VertexEdge<TVertex, TEdge> where TEdge : IUndirectedEdge<TVertex>
    {
        public TVertex Source { get; }
        public TEdge Edge { get; }

        internal VertexEdge(TVertex source, TEdge edge)
        {
            if (!edge.ContainVertex(source)) throw new InvalidOperationException("An invariant has been broken in VertexEdge class");
            Source = source;
            Edge = edge;
        }
    }
}