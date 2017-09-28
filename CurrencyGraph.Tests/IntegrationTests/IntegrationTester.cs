namespace CurrencyGraph.Tests.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IntegrationTester
    {
        // TODO : to return a better message when the assert fails
        [TestMethod]
        public void should_return_correct_error_value_in_test_files_with_error()
        {
            var registeredTests = this.RegisterErrorTests();

            foreach (var test in registeredTests)
            {
                this.ExecuteSafeAssert(test.Key, obtainedResult => Assert.IsTrue(obtainedResult == test.Value));
            }
        }

        // TODO : to return a better message when the assert fails
        [TestMethod]
        public void should_return_correct_value_in_test_files()
        {
            var registeredTests = this.RegisterNoErrorTests();

            foreach (var test in registeredTests)
            {
                this.ExecuteSafeAssert(test.Key, obtainedResult => Assert.IsTrue(obtainedResult == test.Value));
            }
        }

        private void ExecuteSafeAssert(string testFile, Action<decimal> assertAction)
        {
            var proc = this.PrepareProcess(testFile);

            try
            {
                proc.Start();

                var output = proc.StandardOutput.ReadToEnd();
                decimal parseOutput;
                if (decimal.TryParse(output, out parseOutput))
                {
                    assertAction(parseOutput);
                }
                else
                {
                    // TODO : to implement a better error handling or a special case pattern
                    Assert.Fail("The output of the program couldn't be parsed");
                }
            }
            finally
            {
                proc.WaitForExit();
                proc.Close();
            }
        }

        private Process PrepareProcess(string testFile)
        {
            var currentDirectory = Environment.CurrentDirectory;
            var testProjectDirectory = Directory.GetParent(currentDirectory).Parent.FullName;

            var solutionDirectory = Directory.GetParent(testProjectDirectory).FullName;

            var cmdPath = Path.Combine(solutionDirectory, @"CurrencyGraph\bin\Debug\CurrencyGraph.exe");

            var testFilePath = Path.Combine(testProjectDirectory, @"Resources\" + testFile);

            return new Process()
                       {
                           StartInfo = new ProcessStartInfo()
                                           {
                                               FileName = cmdPath,
                                               Arguments = testFilePath,
                                               UseShellExecute = false,
                                               RedirectStandardOutput = true,
                                               CreateNoWindow = true
                                           }
                       };
        }

        private Dictionary<string, decimal> RegisterErrorTests()
        {
            return new Dictionary<string, decimal>() { { "testFile_5.in", 123 }, };
        }

        private Dictionary<string, decimal> RegisterNoErrorTests()
        {
            return new Dictionary<string, decimal>()
                       {
                           { "testFile_1.in", 59033 },
                           { "testFile_2.in", 5 },
                           { "testFile_3.in", 550 },
                           { "testFile_4.in", 714 },
                       };
        }
    }
}