namespace GraphApi.Interfaces
{
    using System.Collections.Generic;

    public interface IScannerResultfactory<TVertex, TEdge>
        where TEdge : IUndirectedEdge<TVertex>
    {
        IScannedGraphResult<TVertex, TEdge> CreateResult(
            TVertex sourceVertex,
            HashSet<TVertex> markedVertices,
            Dictionary<TVertex, TEdge> vertexToParentEdge);
    }
}