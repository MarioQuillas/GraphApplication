using System.Collections.Generic;

namespace GraphApi.Interfaces
{
    public interface IScannedGraphResult<TVertex, TEdge> where TEdge : IUndirectedEdge<TVertex>
    {
        HashSet<TVertex> MarkedVertices { get; }
        TVertex SourceVertex { get; }
        Dictionary<TVertex, TEdge> VertexToParentEdge { get; }
    }
}