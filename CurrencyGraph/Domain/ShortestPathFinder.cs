using System.Collections.Generic;
using System.Linq;

namespace CurrencyGraph.Domain
{
    public class ShortestPathFinder
    {
        private readonly Currency sourceVertex;
        private readonly HashSet<Currency> markedVertices;
        private readonly Dictionary<Currency, Currency> vertexToParentVertex;

        public ShortestPathFinder(Currency sourceVertex, HashSet<Currency> markedVertices, Dictionary<Currency, Currency> vertexToParentVertex)
        {
            this.sourceVertex = sourceVertex;
            this.markedVertices = markedVertices;
            this.vertexToParentVertex = vertexToParentVertex;
        }

        public bool IsConnected(Currency targetVertex) => this.markedVertices.Contains(targetVertex);

        public IEnumerable<Currency> Path(Currency targetVertex)
        {
            if (!this.IsConnected(targetVertex)) return Enumerable.Empty<Currency>();

            var path = new Stack<Currency>();

            var currentVertexInPath = targetVertex;
            while (currentVertexInPath != this.sourceVertex)
            {
                path.Push(currentVertexInPath);
                currentVertexInPath = this.vertexToParentVertex[currentVertexInPath];
            }
            path.Push(this.sourceVertex);

            return path;
        }
    }
}