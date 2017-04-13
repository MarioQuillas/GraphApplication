using System;

namespace CurrencyGraph.Domain
{
    internal class ChangeRateComputationStrategy : IChangeRateComputationStrategy
    {
        public int RoundNumberDecimals { get; }

        public ChangeRateComputationStrategy(int roundNumberDecimals)
        {
            RoundNumberDecimals = roundNumberDecimals;
        }

        public decimal ComputeInverseRate(decimal changeRateRate)
        {
            return decimal.Round( 1 / changeRateRate, this.RoundNumberDecimals);
        }
    }
}