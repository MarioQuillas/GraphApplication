namespace CurrencyGraph.Appication.Interfaces
{
    using System.Collections.Generic;

    public interface IDomainServices
    {
        decimal Calculate(string source, string target, decimal quantity, IEnumerable<ChangeRateDto> rates);

        // decimal Calculate(Currency source, Currency target, decimal quantity, IEnumerable<ChangeRate> rates);
    }
}