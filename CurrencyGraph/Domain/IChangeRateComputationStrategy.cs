namespace CurrencyGraph.Domain
{
    internal interface IChangeRateComputationStrategy
    {
        decimal Inverse(decimal changeRateRate);
    }
}