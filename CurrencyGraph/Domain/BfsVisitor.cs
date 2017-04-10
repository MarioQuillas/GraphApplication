using System.Collections.Generic;
using System.Linq;

namespace CurrencyGraph.Domain
{
    public class BfsVisitor : IStatelessVisitor<CurrencyGraph, ShortestPathFinder>
    {
        private readonly Currency sourceVertex;

        public BfsVisitor(Currency sourceVertex)
        {
            this.sourceVertex = sourceVertex;
         }

        public ShortestPathFinder Visit(CurrencyGraph @this)
        {
            var markedVertices = new HashSet<Currency>();
            var vertexToParentVertex = new Dictionary<Currency, Currency>();

            var queue = new Queue<Currency>();
            queue.Enqueue(this.sourceVertex);

            markedVertices.Add(this.sourceVertex);

            while (queue.Any())
            {
                var currentVertex = queue.Dequeue();
                foreach (var vertex in @this.AdjacentToVertex(currentVertex))
                {
                    if (!markedVertices.Add(vertex)) continue;

                    vertexToParentVertex[vertex] = currentVertex;
                    queue.Enqueue(vertex);
                }
            }

            return new ShortestPathFinder(this.sourceVertex, markedVertices, vertexToParentVertex);
        }
    }
}