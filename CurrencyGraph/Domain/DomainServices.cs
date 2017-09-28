namespace CurrencyGraph.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using global::CurrencyGraph.Appication;
    using global::CurrencyGraph.Appication.Interfaces;

    using GraphApi;

    public class DomainServices : IDomainServices
    {
        public const int RoundNumberDecimals = 4;

        public decimal Calculate(Currency source, Currency target, decimal quantity, IEnumerable<ChangeRate> rates)
        {
            var path = this.GetConversionPath(source, target, rates);

            var result = path.Aggregate(
                quantity,
                (current, pathStep) => current * decimal.Round(
                                           pathStep.TravelledEdge.GetWeightFromStartingVertex(pathStep.StartingVertex),
                                           RoundNumberDecimals));
            return Math.Round(result, MidpointRounding.AwayFromZero);
        }

        public decimal Calculate(string source, string target, decimal quantity, IEnumerable<ChangeRateDto> rates)
        {
            return this.Calculate(
                source,
                target,
                quantity,
                rates.Select(
                    changeRateDto => new ChangeRate(changeRateDto.Source, changeRateDto.Target, changeRateDto.Rate)));
        }

        public IEnumerable<PathStep<Currency, WeightedBidrectionalEdge<Currency>>> GetConversionPath(
            Currency source,
            Currency target,
            IEnumerable<ChangeRate> rates)
        {
            var graph = new CurrencyGraph(rates, new ChangeRateComputationStrategy(RoundNumberDecimals));

            return graph.GetShortestPath(source, target);
        }
    }
}