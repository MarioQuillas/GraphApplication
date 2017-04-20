using System;
using System.Collections.Generic;
using GraphApi.Interfaces;

namespace GraphApi
{
    public class SimplePath<TVertex, TEdge> where TEdge : IUndirectedEdge<TVertex>
    {
        public TVertex StartingVertex { get; }
        public TVertex EndingVertex { get; }

        private readonly Stack<PathStep<TVertex, TEdge>> path;
        private TVertex currentEndingVertex;

        private SimplePath(TVertex startingVertex, TVertex targetVertex)
        {
            this.StartingVertex = startingVertex;
            this.EndingVertex = targetVertex;
            this.currentEndingVertex = targetVertex;
            this.path = new Stack<PathStep<TVertex, TEdge>>();
        }

        // TODO : a special case pattern could be implemented to handle when there is no conversion path
        public IEnumerable<PathStep<TVertex, TEdge>> GetPathTraveller()
        {
            if (this.path.Count == 0) throw new InvalidOperationException("There is no conversion path");
            if (this.EndingVertex.Equals(this.currentEndingVertex)) throw new InvalidOperationException("The path is not from the starting point to the ending point");

            return this.path;
        }

        public static SimplePath<TVertex, TEdge> Empty(TVertex startingVertex, TVertex targetVertex)
        {
            return new SimplePath<TVertex, TEdge>(startingVertex, targetVertex);
        }

        //TODO : this code is not completely safe. Some assumptions are done. Maybe a builder will be a better idea to keep a consistant path at all times
        public void AddNextContinuousEdgeFromCurrentEndingVertex(TEdge edge)
        {
            if (!edge.ContainVertex(this.currentEndingVertex)) throw new InvalidOperationException("An invariant in the construction of the SimplePath was broken.");

            var newEndingVertex = edge.GetOtherVertex(this.currentEndingVertex);

            var pathStep = new PathStep<TVertex, TEdge>(newEndingVertex, this.currentEndingVertex, edge);
            this.path.Push(pathStep);

            this.currentEndingVertex = newEndingVertex;
        }
    }
}