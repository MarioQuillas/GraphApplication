using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyGraph.Tests.IntegrationTests
{
    [TestClass]
    public class IntegrationTester
    {
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

        [TestMethod]
        public void should_return_correct_value_in_test_files()
        {
            var Files = "";

            this.ExecuteSafeAssert("testFile_1.in", obtainedResult => Assert.IsTrue(obtainedResult == 59033));
        }
    }
}