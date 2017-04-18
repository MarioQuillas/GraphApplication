namespace CurrencyGraph.Domain.Interfaces
{
    internal interface IChangeRateComputationStrategy
    {
        decimal ComputeInverseRate(decimal changeRateRate);
    }
}