namespace GraphApi
{
    using GraphApi.Interfaces;

    public class PathStep<TVertex, TEdge>
        where TEdge : IUndirectedEdge<TVertex>
    {
        public PathStep(TVertex startingVertex, TVertex endingVertex, TEdge travelledEdge)
        {
            this.StartingVertex = startingVertex;
            this.EndingVertex = endingVertex;
            this.TravelledEdge = travelledEdge;
        }

        public TVertex EndingVertex { get; }

        public TVertex StartingVertex { get; }

        public TEdge TravelledEdge { get; }
    }
}