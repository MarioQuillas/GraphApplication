using System;
using System.Collections.Generic;
using System.Linq;
using CurrencyGraph.Appication.Interfaces;

namespace CurrencyGraph.Domain
{
    public class DomainServices : IDomainServices
    {
        public const int RoundNumberDecimals = 4;

        public void Calculate(string question, List<string> data)
        {
            throw new System.NotImplementedException();
        }

        public decimal Calculate(Currency source, Currency target,
            decimal quantity,
            IEnumerable<ChangeRate> rates)
        {
            var path = this.GetConversionPath(source, target, rates);

            var result = path.Aggregate(quantity,
                (current, pathStep) =>
                    current *
                    decimal.Round(pathStep.TravelledEdge.GetWeightFromStartingVertex(pathStep.StartingVertex),
                        RoundNumberDecimals));
            return Math.Round(result, MidpointRounding.AwayFromZero);
        }

        public IEnumerable<PathStep<Currency, WeightedBidrectionalEdge<Currency>>> GetConversionPath(
            Currency source, Currency target, IEnumerable<ChangeRate> rates)
        {
            var graph = new CurrencyGraph(rates, new ChangeRateComputationStrategy(RoundNumberDecimals));

            return graph.GetShortestPath(source, target);
        }
    }
}