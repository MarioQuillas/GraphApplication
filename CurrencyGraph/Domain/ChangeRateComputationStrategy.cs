namespace CurrencyGraph.Domain
{
    using global::CurrencyGraph.Domain.Interfaces;

    internal class ChangeRateComputationStrategy : IChangeRateComputationStrategy
    {
        public ChangeRateComputationStrategy(int roundNumberDecimals)
        {
            this.RoundNumberDecimals = roundNumberDecimals;
        }

        public int RoundNumberDecimals { get; }

        public decimal ComputeInverseRate(decimal changeRateRate)
        {
            return decimal.Round(1 / changeRateRate, this.RoundNumberDecimals);
        }
    }
}