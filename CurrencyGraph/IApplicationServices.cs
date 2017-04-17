using System.Collections.Generic;
using CurrencyGraph.Appication;

namespace CurrencyGraph
{
    internal interface IApplicationServices
    {
        decimal Calculate(string question, IEnumerable<string> data);
    }
}