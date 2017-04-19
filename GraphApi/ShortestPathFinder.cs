using System;
using GraphApi.Interfaces;

namespace GraphApi
{
    public class ShortestPathFinder<TVertex, TEdge>
        where TEdge : IUndirectedEdge<TVertex>
        where TVertex : IEquatable<TVertex>
    {
        private readonly IScannedGraphResult<TVertex, TEdge> scannedGraphResult;

        public ShortestPathFinder(IScannedGraphResult<TVertex, TEdge> scannedGraphResult)
        {
            this.scannedGraphResult = scannedGraphResult;
        }

        public bool IsConnected(TVertex targetVertex) => this.scannedGraphResult.MarkedVertices.Contains(targetVertex);

        public SimplePath<TVertex, TEdge> Path(TVertex targetVertex)
        {
            var startingVertex = this.scannedGraphResult.SourceVertex;

            var path = SimplePath<TVertex, TEdge>.Empty(startingVertex, targetVertex);

            if (!this.IsConnected(targetVertex)) return path;

            //var path = new Stack<VertexEdge<TVertex, TEdge>>();

            var currentVertexInPath = targetVertex;

            while (!currentVertexInPath.Equals(startingVertex))
            {
                var edge = this.scannedGraphResult.VertexToParentEdge[currentVertexInPath];
                path.AddNextContinuousEdgeFromCurrentEndingVertex(edge);
                currentVertexInPath = edge.GetOtherVertex(currentVertexInPath);
                //currentVertexInPath = this.scannedGraphResult.VertexToParentVertex[currentVertexInPath];
            }
            //path.Push(this.scannedGraphResult.SourceVertex);

            return path;
        }
    }
}