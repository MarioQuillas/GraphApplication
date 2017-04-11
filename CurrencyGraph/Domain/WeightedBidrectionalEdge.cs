using System.Data;

namespace CurrencyGraph.Domain
{
    internal class WeightedBidrectionalEdge<TVertex> : IUndirectedEdge<TVertex>
    {
        private readonly WeightedDirectionalEdge<TVertex> edge1;
        private readonly WeightedDirectionalEdge<TVertex> edge2;

        internal WeightedBidrectionalEdge(TVertex vertex1, TVertex vertex2, decimal weight12, decimal weight21)
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
            return this.edge1.Source.Equals(vertex) || this.edge1.Target.Equals(vertex);
        }
    }
}