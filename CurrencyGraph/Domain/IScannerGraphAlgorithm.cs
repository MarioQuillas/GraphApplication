namespace CurrencyGraph.Domain
{
    internal interface IScannerGraphAlgorithm<TVertex>
    {
        IScannedGraphResult<TVertex> TraverseGraph(IGraph<TVertex> graph, TVertex sourceVertex);
    }
}