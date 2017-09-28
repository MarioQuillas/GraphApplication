namespace CurrencyGraph.Domain
{
    using System.Collections.Generic;

    using global::CurrencyGraph.Domain.Interfaces;

    using GraphApi;
    using GraphApi.Interfaces;

    internal class CurrencyGraph : IUndirectedGraph<Currency, WeightedBidrectionalEdge<Currency>>
    {
        private readonly Dictionary<Currency, ICollection<WeightedBidrectionalEdge<Currency>>> adjacency;

        private readonly IScannerGraphAlgorithm<Currency, WeightedBidrectionalEdge<Currency>> scannerGraphAlgorithm;

        internal CurrencyGraph(
            IEnumerable<ChangeRate> changeRates,
            IChangeRateComputationStrategy changeRateComputationStrategy)
        {
            this.adjacency = new Dictionary<Currency, ICollection<WeightedBidrectionalEdge<Currency>>>();
            this.TotalEdges = 0;
            this.TotalVertices = 0;

            foreach (var changeRate in changeRates)
            {
                this.AddEdge(changeRate, changeRateComputationStrategy);
            }

            this.scannerGraphAlgorithm = new BfsScanner<Currency, WeightedBidrectionalEdge<Currency>>(
                new ScannerResultfactory<Currency, WeightedBidrectionalEdge<Currency>>());
        }

        public int TotalEdges { get; private set; }

        public int TotalVertices { get; private set; }

        public IEnumerable<WeightedBidrectionalEdge<Currency>> GetAdjacentsToVertex(Currency vertex)
        {
            return this.adjacency[vertex];
        }

        internal IEnumerable<PathStep<Currency, WeightedBidrectionalEdge<Currency>>> GetShortestPath(
            Currency source,
            Currency target)
        {
            var scannedGraphResult = this.scannerGraphAlgorithm.TraverseGraph(this, source);
            var shortestPathFinder =
                new ShortestPathFinder<Currency, WeightedBidrectionalEdge<Currency>>(scannedGraphResult);
            var result = shortestPathFinder.Path(target);
            return result.GetPathTraveller();
        }

        private void AddEdge(ChangeRate changeRate, IChangeRateComputationStrategy changeRateComputationStrategy)
        {
            var source = changeRate.Source;
            var target = changeRate.Target;

            if (!this.adjacency.ContainsKey(source))
            {
                this.adjacency[source] = new List<WeightedBidrectionalEdge<Currency>>();
                this.TotalVertices += 1;
            }

            if (!this.adjacency.ContainsKey(target))
            {
                this.adjacency[target] = new List<WeightedBidrectionalEdge<Currency>>();
                this.TotalVertices += 1;
            }

            var originalRate = changeRate.Rate;
            var inverseRate = changeRateComputationStrategy.ComputeInverseRate(originalRate);

            this.adjacency[source]
                .Add(new WeightedBidrectionalEdge<Currency>(source, target, originalRate, inverseRate));
            this.adjacency[target]
                .Add(new WeightedBidrectionalEdge<Currency>(target, source, inverseRate, originalRate));

            this.TotalEdges += 1;
        }
    }
}