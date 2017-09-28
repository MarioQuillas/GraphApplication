namespace GraphApi.Interfaces
{
    using System.Collections.Generic;

    public interface IScannedGraphResult<TVertex, TEdge>
        where TEdge : IUndirectedEdge<TVertex>
    {
        HashSet<TVertex> MarkedVertices { get; }

        TVertex SourceVertex { get; }

        Dictionary<TVertex, TEdge> VertexToParentEdge { get; }
    }
}