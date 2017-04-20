using System;
using GraphApi.Interfaces;

namespace GraphApi
{
    public class WeightedBidrectionalEdge<TVertex> : IUndirectedEdge<TVertex>
        where TVertex:IEquatable<TVertex>
    {
        private readonly WeightedDirectionalEdge<TVertex> edge1;
        private readonly WeightedDirectionalEdge<TVertex> edge2;

        public WeightedBidrectionalEdge(TVertex vertex1, TVertex vertex2, decimal weight12, decimal weight21)
        {
            this.edge1 = new WeightedDirectionalEdge<TVertex>(vertex1, vertex2, weight12);
            this.edge2 = new WeightedDirectionalEdge<TVertex>(vertex2, vertex1, weight21);
        }

        public TVertex GetOtherVertex(TVertex currentVertex)
        {
            return currentVertex.Equals(this.edge1.Source) ? this.edge1.Target : this.edge1.Source;
        }

        public bool ContainVertex(TVertex vertex)
        {
            return this.edge1.Source.Equals(vertex) || this.edge1.Target.Equals(vertex);
        }

        public decimal GetWeightFromStartingVertex(TVertex startingVertex)
        {
            if (this.edge1.Source.Equals(startingVertex)) return this.edge1.Weight;
            if (this.edge2.Source.Equals(startingVertex)) return this.edge2.Weight;

            throw new InvalidOperationException("An Invariant was broken in the WeithedBidirectionalEdge");
        }
    }
}