using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyGraph.Appication
{
    public class ChangeRateDto
    {
        public string Source { get; }
        public string Target { get; }
        public decimal Rate { get; }

        public ChangeRateDto(string source, string target, decimal rate)
        {
            this.Source = source;
            this.Target = target;
            this.Rate = rate;
        }
    }
}
