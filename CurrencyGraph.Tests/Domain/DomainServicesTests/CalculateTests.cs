using System;
using System.Collections.Generic;
using CurrencyGraph.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyGraph.Tests.Domain.DomainServicesTests
{
    [TestClass]
    public class CalculateTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var deviceSource = new Currency("EUR");
            var deviceTarget = new Currency("JPY");

            var rates = new List<ChangeRate>()
            {
                new ChangeRate("AUD", "CHF", (decimal) 0.9661),
                new ChangeRate("JPY", "KRW", (decimal) 13.1151),
                new ChangeRate("EUR", "CHF", (decimal) 1.2053),
                new ChangeRate("AUD", "JPY", (decimal) 86.0305),
                new ChangeRate("EUR", "USD", (decimal) 1.2989),
                new ChangeRate("JPY", "INR", (decimal) 0.6571),
            };

            var result = new DomainServices().Calculate(
                deviceSource, deviceTarget, 550, rates);

            Assert.IsTrue(result == 59033);
        }

    }
}
