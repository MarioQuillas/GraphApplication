using System;
using System.Collections.Generic;

namespace CurrencyGraph
{
    class Program
    {
        //private IApplicationServices appServices;

        static void Main(string[] args)
        {
            var toto = new CommandParser();
            var titi = toto.Parse(args);

            // while()
            var question = "";
            var lines = 0;
            var data = new List<string>(lines);

            IApplicationServices appServices = null;

            var result = appServices.Calculate(question, data);
        }
    }

    internal interface IApplicationServices
    {
        object Calculate(string question, List<string> data);
    }

    internal class CommandParser
    {
        public object Parse(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
