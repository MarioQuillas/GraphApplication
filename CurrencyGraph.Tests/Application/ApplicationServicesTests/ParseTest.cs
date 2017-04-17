using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyGraph.Tests.Application.ApplicationServicesTests
{
    [TestClass]
    public class ParseTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var toto = "JPY;INR;0.6571".Split(';')[2];
            var t = decimal.TryParse(toto, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal result);
        }
    }
}
