namespace GraphApi
{
    internal class WeightedDirectionalEdge<TVertex>
    {
        public WeightedDirectionalEdge(TVertex source, TVertex target, decimal weight)
        {
            this.Source = source;
            this.Target = target;
            this.Weight = weight;
        }

        public TVertex Source { get; }

        public TVertex Target { get; }

        public decimal Weight { get; }
    }
}