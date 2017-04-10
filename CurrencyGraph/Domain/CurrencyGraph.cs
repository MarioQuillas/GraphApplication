using System.Collections.Generic;

namespace CurrencyGraph.Domain
{
    internal class CurrencyGraph : IGraph<Currency>
    {
        private readonly Dictionary<Currency, ICollection<Currency>> adjacency;
        private readonly IScannerGraphAlgorithm<Currency> scannerGraphAlgorithm;

        public int TotalVertices { get; private set; }
        public int TotalEdges { get; private set;  }

        internal CurrencyGraph(IEnumerable<ChangeRate> changeRates)
        {
            this.adjacency = new Dictionary<Currency, ICollection<Currency>>();
            this.TotalEdges = 0;
            this.TotalVertices = 0;

            foreach (var rate in changeRates)
            {
                this.AddEdge(rate.Source, rate.Target);
            }

            this.scannerGraphAlgorithm = new BfsScanner<Currency>(new TraverserResultfactory<Currency>());
        }

        private void AddEdge(Currency currency1, Currency currency2)
        {
            if (!this.adjacency.ContainsKey(currency1))
            {
                this.adjacency[currency1] = new List<Currency>();
                this.TotalVertices += 1;
            }

            if (!this.adjacency.ContainsKey(currency2))
            {
                this.adjacency[currency2] = new List<Currency>();
                this.TotalVertices += 1;
            }

            this.adjacency[currency1].Add(currency2);
            this.adjacency[currency2].Add(currency1);

            this.TotalEdges += 1;
        }

        public IEnumerable<Currency> GetAdjacentsToVertex(Currency vertex)
        {
            return this.adjacency[vertex];
        }

        internal IEnumerable<Currency> GetShortestPath(Currency source, Currency target)
        {
            var scannedGraphResult = this.scannerGraphAlgorithm.TraverseGraph(this, source);
            return new ShortestPathFinder<Currency>(scannedGraphResult).Path(target);
        }
    }
}