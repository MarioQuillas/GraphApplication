using System;
using System.Collections.Generic;
using System.IO;

namespace CurrencyGraph.Domain
{
    internal class SimplePath<TVertex, TEdge> where TEdge : IUndirectedEdge<TVertex>
    {
        public TVertex StartingVertex { get; }
        public TVertex EndingVertex { get; private set; }

        private readonly Stack<PathStep<TVertex, TEdge>> path;

        private SimplePath(TVertex startingVertex)
        {
            this.StartingVertex = startingVertex;
            this.EndingVertex = startingVertex;
            this.path = new Stack<PathStep<TVertex, TEdge>>();
        }

        public IEnumerable<PathStep<TVertex, TEdge>> GetPathTraveller()
        {
            return this.path;
        }

        public static SimplePath<TVertex, TEdge> Empty(TVertex startingVertex)
        {
            return new SimplePath<TVertex, TEdge>(startingVertex);
        }

        public void AddNextContinuousEdge(TEdge edge)
        {
            if (edge.ContainVertex(this.EndingVertex)) throw new InvalidOperationException("An invariant in the construction of the SimplePath was broken.");

            var newEndingVertex = edge.GetOtherVertex(this.EndingVertex);

            var pathStep = new PathStep<TVertex, TEdge>(this.EndingVertex, newEndingVertex, edge);
            this.path.Push(pathStep);

            this.EndingVertex = newEndingVertex;
        }
    }
}