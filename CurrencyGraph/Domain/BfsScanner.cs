using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CurrencyGraph.Domain
{
    internal class BfsScanner<TVertex, TEdge> : IScannerGraphAlgorithm<TVertex, TEdge> where TEdge : IUndirectedEdge<TVertex>
    {
        private readonly IScannerResultfactory<TVertex> scannerResultfactory;

        internal BfsScanner(IScannerResultfactory<TVertex> scannerResultfactory)
        {
            this.scannerResultfactory = scannerResultfactory;
        }

        //public IScannedGraphResult<TVertex> TraverseGraph(IUndirectedGraph<TVertex, TEdge> undirectedGraph, TVertex sourceVertex)
        //{
        //    throw new System.NotImplementedException();
        //}

        public IScannedGraphResult<TVertex> TraverseGraph(IUndirectedGraph<TVertex, TEdge> undirectedGraph, TVertex sourceVertex)
        {
            var markedVertices = new HashSet<TVertex>();
            var vertexToParentVertex = new Dictionary<TVertex, TVertex>();

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

                    vertexToParentVertex[vertex] = currentVertex;
                    queue.Enqueue(vertex);
                }
            }

            return this.scannerResultfactory.CreateResult(sourceVertex, markedVertices, vertexToParentVertex);
        }
    }
}