using System.Collections.Generic;

namespace CurrencyGraph.Presentation
{
    internal interface IApplicationServices
    {
        decimal Calculate(string question, IEnumerable<string> data);
    }
}