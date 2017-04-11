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

        public IEnumerable<VertexEdge<TVertex, TEdge>> Path(TVertex targetVertex)
        {
            if (!this.IsConnected(targetVertex)) return Enumerable.Empty<VertexEdge<TVertex, TEdge>>();

            var path = new Stack<VertexEdge<TVertex, TEdge>>();

            var currentVertexInPath = targetVertex;

            //TODO : implement correct equality
            while (!currentVertexInPath.Equals(this.scannedGraphResult.SourceVertex))
            {
                var edge = this.scannedGraphResult.GetVertexToParentVertexEdge(currentVertexInPath);
                path.Push(new VertexEdge<TVertex, TEdge>(currentVertexInPath, edge));
                currentVertexInPath = this.scannedGraphResult.VertexToParentVertex[currentVertexInPath];
            }
            path.Push(this.scannedGraphResult.SourceVertex);

            return path;
        }
    }
}