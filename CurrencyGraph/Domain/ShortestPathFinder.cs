using System.Collections.Generic;
using System.Linq;

namespace CurrencyGraph.Domain
{
    internal class ShortestPathFinder<TVertex, TEdge> where TEdge : IUndirectedEdge<TVertex>
    {
        private readonly IScannedGraphResult<TVertex, TEdge> scannedGraphResult;

        internal ShortestPathFinder(IScannedGraphResult<TVertex, TEdge> scannedGraphResult)
        {
            this.scannedGraphResult = scannedGraphResult;
        }

        public bool IsConnected(TVertex targetVertex) => this.scannedGraphResult.MarkedVertices.Contains(targetVertex);

        public SimplePath<TVertex, TEdge> Path(TVertex targetVertex)
        {
            var startingVertex = this.scannedGraphResult.SourceVertex;

            var path = SimplePath<TVertex, TEdge>.Empty(startingVertex);

            if (!this.IsConnected(targetVertex)) return path;
            
            //var path = new Stack<VertexEdge<TVertex, TEdge>>();

            var currentVertexInPath = targetVertex;

            //TODO : implement correct equality
            while (!currentVertexInPath.Equals(startingVertex))
            {
                var edge = this.scannedGraphResult.VertexToParentEdge[currentVertexInPath];
                path.AddNextContinuousEdge(edge);
                currentVertexInPath = edge.GetOtherVertex(currentVertexInPath);
                //currentVertexInPath = this.scannedGraphResult.VertexToParentVertex[currentVertexInPath];
            }
            //path.Push(this.scannedGraphResult.SourceVertex);

            return path;
        }
    }
}