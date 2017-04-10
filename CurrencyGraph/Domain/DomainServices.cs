using System.Collections.Generic;
using CurrencyGraph.Appication.Interfaces;

namespace CurrencyGraph.Domain
{
    public class DomainServices : IDomainServices
    {
        public void Calculate(string question, List<string> data)
        {
            throw new System.NotImplementedException();
        }

        public decimal Calculate(Currency source, Currency target,
            decimal quantity,
            List<ChangeRate> rates)
        {


            return 0;
        }

        public IEnumerable<Currency> CalculateConversionPath(Currency source, Currency target, IEnumerable<ChangeRate> rates)
        {
            var graph = new CurrencyGraph(rates);

            return graph.GetShortestPath(source, target);
        }
    }
}