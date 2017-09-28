namespace GraphApi.Interfaces
{
    public interface IScannerGraphAlgorithm<TVertex, TEdge>
        where TEdge : IUndirectedEdge<TVertex>
    {
        IScannedGraphResult<TVertex, TEdge> TraverseGraph(
            IUndirectedGraph<TVertex, TEdge> undirectedGraph,
            TVertex sourceVertex);
    }
}