namespace CurrencyGraph.Domain
{
    internal class PathStep<TVertex, TEdge> where TEdge : IUndirectedEdge<TVertex>
    {
        public TVertex StartingVertex { get; }
        public TVertex EndingVertex { get; }
        public TEdge TraveledEdge { get; }

        public PathStep(TVertex startingVertex, TVertex endingVertex, TEdge traveledEdge)
        {
            StartingVertex = startingVertex;
            EndingVertex = endingVertex;
            TraveledEdge = traveledEdge;
        }
    }
}