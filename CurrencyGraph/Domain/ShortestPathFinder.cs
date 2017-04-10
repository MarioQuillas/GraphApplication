using System.Collections.Generic;
using System.Linq;

namespace CurrencyGraph.Domain
{
    internal class ShortestPathFinder<TVertex>
    {
        private readonly IScannedGraphResult<TVertex> scannedGraphResult;

        internal ShortestPathFinder(IScannedGraphResult<TVertex> scannedGraphResult)
        {
            this.scannedGraphResult = scannedGraphResult;
        }

        public bool IsConnected(TVertex targetVertex) => this.scannedGraphResult.MarkedVertices.Contains(targetVertex);

        public IEnumerable<TVertex> Path(TVertex targetVertex)
        {
            if (!this.IsConnected(targetVertex)) return Enumerable.Empty<TVertex>();

            var path = new Stack<TVertex>();

            var currentVertexInPath = targetVertex;

            //TODO : implement correct equality
            while (!currentVertexInPath.Equals(this.scannedGraphResult.SourceVertex))
            {
                path.Push(currentVertexInPath);
                currentVertexInPath = this.scannedGraphResult.VertexToParentVertex[currentVertexInPath];
            }
            path.Push(this.scannedGraphResult.SourceVertex);

            return path;
        }
    }
}