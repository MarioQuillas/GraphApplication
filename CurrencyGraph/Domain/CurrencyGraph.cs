using System.Collections.Generic;

namespace CurrencyGraph.Domain
{
    public class CurrencyGraph : IStatelessAceptor<CurrencyGraph>
    {
        private readonly Dictionary<Currency, ICollection<Currency>> adjacency;

        public int TotalVertices { get; private set; }
        public int TotalEdges { get; private set;  }

        public CurrencyGraph(IEnumerable<ChangeRate> changeRates)
        {
            this.adjacency = new Dictionary<Currency, ICollection<Currency>>();
            this.TotalEdges = 0;
            this.TotalVertices = 0;

            foreach (var rate in changeRates)
            {
                this.AddEdge(rate.Source, rate.Target);
            }
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

        public IEnumerable<Currency> AdjacentToVertex(Currency vertex)
        {
            return this.adjacency[vertex];
        }

        public TResult Accept<TResult>(IStatelessVisitor<CurrencyGraph, TResult> statelessVisitor)
        {
            return statelessVisitor.Visit(this);
        }
    }
}