using System.Collections.Generic;
using CurrencyGraph.Appication.Interfaces;

namespace CurrencyGraph.Appication
{
    public class ApplicationServices: IApplicationServices
    {
        private readonly IDomainServices domainServices;

        public ApplicationServices(IDomainServices domainServices)
        {
            this.domainServices = domainServices;
        }

        public object Calculate(string question, List<string> data)
        {
            this.domainServices.Calculate(question, data);

            throw new System.NotImplementedException();
        }
    }
}