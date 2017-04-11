namespace CurrencyGraph.Domain
{
    internal interface IScannerGraphAlgorithm<TVertex, TEdge> where TEdge : IUndirectedEdge<TVertex>
    {
        IScannedGraphResult<TVertex> TraverseGraph(IUndirectedGraph<TVertex, TEdge> undirectedGraph, TVertex sourceVertex);
    }
}