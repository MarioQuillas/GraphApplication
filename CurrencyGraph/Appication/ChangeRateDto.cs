namespace CurrencyGraph.Appication
{
    public class ChangeRateDto
    {
        public ChangeRateDto(string source, string target, decimal rate)
        {
            this.Source = source;
            this.Target = target;
            this.Rate = rate;
        }

        public decimal Rate { get; }

        public string Source { get; }

        public string Target { get; }
    }
}