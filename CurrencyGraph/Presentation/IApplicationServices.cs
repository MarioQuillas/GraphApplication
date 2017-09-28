namespace CurrencyGraph.Presentation
{
    using System.Collections.Generic;

    internal interface IApplicationServices
    {
        decimal Calculate(string question, IEnumerable<string> data);
    }
}