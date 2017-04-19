using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using CurrencyGraph.Appication;
using CurrencyGraph.Domain;

namespace CurrencyGraph
{
    class Program
    {
        internal static void Main(string[] args)
        {
            if (args.Length == 0 || args.Length > 1)
            {
                Console.WriteLine("The input parameters are not correct");
                Console.ReadLine();
                return;
            }

            var inputPath = args[0]; //@"C:\MyGitHub\GraphApplication\CurrencyGraph.Tests\testFile.in";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("The file does not exist");
                Console.ReadLine();
                return;
            }

            var question = "";
            var inputData = new List<string>();
            using (var reader = File.OpenText(inputPath))
            {
                question = reader.ReadLine();
                var readLine = reader.ReadLine();
                int numberInputs = 0;
                var canParse = readLine != null && int.TryParse(readLine.Trim(), out numberInputs);
                if (!canParse)
                {
                    Console.WriteLine("The second line was not in the expected format");
                    Console.ReadLine();
                    return;
                }

                for (var i = 0; i < numberInputs; i++)
                {
                    inputData.Add(reader.ReadLine());
                }
            }

            var result = new ApplicationServices(new DomainServices()).Calculate(question, inputData);

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
