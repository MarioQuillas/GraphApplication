namespace CurrencyGraph.Domain
{
    public class PathStep<TVertex, TEdge> where TEdge : IUndirectedEdge<TVertex>
    {
        public TVertex StartingVertex { get; }
        public TVertex EndingVertex { get; }
        public TEdge TravelledEdge { get; }

        public PathStep(TVertex startingVertex, TVertex endingVertex, TEdge travelledEdge)
        {
            StartingVertex = startingVertex;
            EndingVertex = endingVertex;
            TravelledEdge = travelledEdge;
        }

        //TODO : for debugging purpose
        public override string ToString()
        {
            return this.StartingVertex + ", " + this.EndingVertex;
        }
    }
}