using System;
using System.Collections.Generic;

namespace CurrencyGraph.Domain
{
    internal interface IScannedGraphResult<TVertex, TEdge> where TEdge : IUndirectedEdge<TVertex>
    {
        HashSet<TVertex> MarkedVertices { get; }
        TVertex SourceVertex { get; }
        Dictionary<TVertex, TVertex> VertexToParentVertex { get; }
        TEdge GetVertexToParentVertexEdge(TVertex vertex);
    }
}