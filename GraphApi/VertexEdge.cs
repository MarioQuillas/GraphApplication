namespace GraphApi
{
    using System;

    using GraphApi.Interfaces;

    internal class VertexEdge<TVertex, TEdge>
        where TEdge : IUndirectedEdge<TVertex>
    {
        internal VertexEdge(TVertex source, TEdge edge)
        {
            if (!edge.ContainVertex(source))
                throw new InvalidOperationException("An invariant has been broken in VertexEdge class");
            this.Source = source;
            this.Edge = edge;
        }

        public TEdge Edge { get; }

        public TVertex Source { get; }
    }
}