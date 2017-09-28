namespace CurrencyGraph.Tests.Domain.CurrencyGraphTests
{
    using System.Collections.Generic;
    using System.Linq;

    using CurrencyGraph.Domain;

    using GraphApi;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetShortestPathtTests
    {
        [TestMethod]
        public void should_return_correct_value_in_example_test_case()
        {
            var deviceSource = new Currency("EUR");
            var deviceTarget = new Currency("JPY");

            var rates = new List<ChangeRate>()
                            {
                                new ChangeRate("AUD", "CHF", (decimal)0.9661),
                                new ChangeRate("JPY", "KRW", (decimal)13.1151),
                                new ChangeRate("EUR", "CHF", (decimal)1.2053),
                                new ChangeRate("AUD", "JPY", (decimal)86.0305),
                                new ChangeRate("EUR", "USD", (decimal)1.2989),
                                new ChangeRate("JPY", "INR", (decimal)0.6571),
                            };

            var currencyGraph = new global::CurrencyGraph.Domain.CurrencyGraph(
                rates,
                new ChangeRateComputationStrategy(4));

            var result = currencyGraph.GetShortestPath(deviceSource, deviceTarget);

            var actualResult = new List<PathStep<Currency, WeightedBidrectionalEdge<Currency>>>()
                                   {
                                       new PathStep<
                                           Currency,
                                           WeightedBidrectionalEdge<Currency>>(
                                           "EUR",
                                           "CHF",
                                           null),
                                       new PathStep<
                                           Currency,
                                           WeightedBidrectionalEdge<Currency>>(
                                           "CHF",
                                           "AUD",
                                           null),
                                       new PathStep<
                                           Currency,
                                           WeightedBidrectionalEdge<Currency>>(
                                           "AUD",
                                           "JPY",
                                           null),
                                   };

            Assert.IsTrue(this.CompareEqualityPaths(result, actualResult));
        }

        [TestMethod]
        public void should_return_one_travelled_edge_for_trivial_case()
        {
            var deviceSource = new Currency("EUR");
            var deviceTarget = new Currency("JPY");

            var rates = new List<ChangeRate>() { new ChangeRate("EUR", "JPY", (decimal)0.6571), };

            var currencyGraph = new global::CurrencyGraph.Domain.CurrencyGraph(
                rates,
                new ChangeRateComputationStrategy(4));

            var result = currencyGraph.GetShortestPath(deviceSource, deviceTarget);

            var actualResult =
                new List<PathStep<Currency, WeightedBidrectionalEdge<Currency>>>()
                    {
                        new PathStep<Currency,
                            WeightedBidrectionalEdge<Currency>>(
                            "EUR",
                            "JPY",
                            null),
                    };

            Assert.IsTrue(this.CompareEqualityPaths(result, actualResult));
        }

        private bool CompareEqualityPaths(
            IEnumerable<PathStep<Currency, WeightedBidrectionalEdge<Currency>>> path1,
            IEnumerable<PathStep<Currency, WeightedBidrectionalEdge<Currency>>> path2)
        {
            return path1.Zip(
                    path2,
                    (step1, step2) =>
                        step1.StartingVertex == step2.StartingVertex && step1.EndingVertex == step2.EndingVertex)
                .Aggregate(true, (a, b) => a && b);
        }
    }
}