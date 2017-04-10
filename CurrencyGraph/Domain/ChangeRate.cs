namespace CurrencyGraph.Domain
{
    public class ChangeRate
    {
        public Currency Source { get; }

        public Currency Target { get; }

        public decimal Rate { get; }

        public ChangeRate(Currency source, Currency target, decimal rate)
        {
            this.Source = source;
            this.Target = target;
            this.Rate = rate;
        }
    }
}