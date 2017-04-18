using System;
using GraphApi.Interfaces;

namespace GraphApi
{
    public class WeightedBidrectionalEdge<TVertex> : IUndirectedEdge<TVertex>
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
            //TODO : implement equals correctly
            return currentVertex.Equals(this.edge1.Source) ? this.edge1.Target : this.edge1.Source;
        }

        public bool ContainVertex(TVertex vertex)
        {
            //TODO : implement equals correctly
            var toto1 = this.edge1.Source.Equals(vertex);

            var toto2 = this.edge1.Target.Equals(vertex);

            return toto1 || toto2;
        }

        public decimal GetWeightFromStartingVertex(TVertex startingVertex)
        {
            //TODO : implement equals correctly
            if (this.edge1.Source.Equals(startingVertex)) return this.edge1.Weight;
            if (this.edge2.Source.Equals(startingVertex)) return this.edge2.Weight;

            throw new InvalidOperationException("An Invariant was broken in the WeithedBidirectionalEdge");
        }

        //TODO : for debugging purpose
        public override string ToString()
        {
            return this.edge1.Source+ "," + this.edge1.Target;
        }
    }
}