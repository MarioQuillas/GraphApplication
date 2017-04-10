using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CurrencyGraph.Domain
{
    internal class BfsScanner<TVertex> : IScannerGraphAlgorithm<TVertex>
    {
        private readonly ITraverserResultfactory<TVertex> traverserResultfactory;

        internal BfsScanner(ITraverserResultfactory<TVertex> traverserResultfactory)
        {
            this.traverserResultfactory = traverserResultfactory;
        }

        public IScannedGraphResult<TVertex> TraverseGraph(IGraph<TVertex> graph, TVertex sourceVertex)
        {
            var markedVertices = new HashSet<TVertex>();
            var vertexToParentVertex = new Dictionary<TVertex, TVertex>();

            var queue = new Queue<TVertex>();
            queue.Enqueue(sourceVertex);

            markedVertices.Add(sourceVertex);

            while (queue.Any())
            {
                var currentVertex = queue.Dequeue();
                foreach (var vertex in graph.GetAdjacentsToVertex(currentVertex))
                {
                    if (!markedVertices.Add(vertex)) continue;

                    vertexToParentVertex[vertex] = currentVertex;
                    queue.Enqueue(vertex);
                }
            }

            return this.traverserResultfactory.CreateResult(sourceVertex, markedVertices, vertexToParentVertex);
        }
    }
}