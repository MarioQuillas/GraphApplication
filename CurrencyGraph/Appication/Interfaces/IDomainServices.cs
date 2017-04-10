using System.Collections.Generic;

namespace CurrencyGraph.Appication.Interfaces
{
    public interface IDomainServices
    {
        void Calculate(string question, List<string> data);
    }
}