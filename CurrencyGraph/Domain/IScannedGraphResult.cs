using System;
using System.Collections.Generic;

namespace CurrencyGraph.Domain
{
    internal interface IScannedGraphResult<TVertex>
    {
        HashSet<TVertex> MarkedVertices { get; }
        TVertex SourceVertex { get; }
        Dictionary<TVertex, TVertex> VertexToParentVertex { get; }
    }
}