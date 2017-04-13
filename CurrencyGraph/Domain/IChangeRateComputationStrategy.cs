namespace CurrencyGraph.Domain
{
    internal interface IChangeRateComputationStrategy
    {
        decimal ComputeInverseRate(decimal changeRateRate);
    }
}