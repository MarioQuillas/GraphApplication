using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CurrencyGraph.Domain
{
    internal class BfsScanner<TVertex, TEdge> : IScannerGraphAlgorithm<TVertex, TEdge> where TEdge : IUndirectedEdge<TVertex>
    {
        private readonly IScannerResultfactory<TVertex, TEdge> scannerResultfactory;

        internal BfsScanner(IScannerResultfactory<TVertex, TEdge> scannerResultfactory)
        {
            this.scannerResultfactory = scannerResultfactory;
        }

        public IScannedGraphResult<TVertex, TEdge> TraverseGraph(IUndirectedGraph<TVertex, TEdge> undirectedGraph, TVertex sourceVertex)
        {
            var markedVertices = new HashSet<TVertex>();
            //var vertexToParentVertex = new Dictionary<TVertex, TVertex>();

            var vertexToParentEdge = new Dictionary<TVertex, TEdge>();

            var queue = new Queue<TVertex>();
            queue.Enqueue(sourceVertex);

            markedVertices.Add(sourceVertex);

            while (queue.Any())
            {
                var currentVertex = queue.Dequeue();
                foreach (var edge in undirectedGraph.GetAdjacentsToVertex(currentVertex))
                {
                    var vertex = edge.GetOtherVertex(currentVertex);

                    if (!markedVertices.Add(vertex)) continue;

                    //vertexToParentVertex[vertex] = currentVertex;
                    vertexToParentEdge[vertex] = edge;

                    queue.Enqueue(vertex);
                }
            }

            return this.scannerResultfactory.CreateResult(sourceVertex, markedVertices, vertexToParentEdge);
        }
    }
}