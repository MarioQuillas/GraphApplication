using System;
using System.Collections.Generic;
using System.ComponentModel;
using CurrencyGraph.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyGraph.Tests.Domain.DomainServicesTests
{
    [TestClass]
    public class CalculateTests
    {
        [TestMethod]
        public void should_return_correct_value_for_custom_case_with_one_conversion_path()
        {
            var deviceSource = new Currency("cc1");
            var deviceTarget = new Currency("cc5");

            var rates = new List<ChangeRate>()
            {
                new ChangeRate("cc1", "cc2", (decimal) 0.9661),
                new ChangeRate("cc1", "cc4", (decimal) 13.1151),
                new ChangeRate("cc4", "cc3", (decimal) 1.2053),
                new ChangeRate("cc3", "cc2", (decimal) 86.0305),
                new ChangeRate("cc3", "cc6", (decimal) 1.2989),
                new ChangeRate("cc6", "cc7", (decimal) 0.6571),
                new ChangeRate("cc3", "cc5", (decimal) 100.1234),
            };

            var result = new DomainServices().Calculate(
                deviceSource, deviceTarget, 456, rates);

            Assert.IsTrue(result == 512);
        }

        [TestMethod]
        public void should_return_correct_value_for_example_case()
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

        [TestMethod]
        public void should_return_correct_value_for_custom_case_with_two_possible_conversion_paths()
        {
            var deviceSource = new Currency("cc1");
            var deviceTarget = new Currency("cc5");

            var rates = new List<ChangeRate>()
            {
                new ChangeRate("cc1", "cc2", (decimal) 0.9661),
                new ChangeRate("cc1", "cc4", (decimal) 13.1151),
                new ChangeRate("cc4", "cc3", (decimal) 1.2053),
                new ChangeRate("cc3", "cc2", (decimal) 86.0305),
                new ChangeRate("cc3", "cc6", (decimal) 1.2989),
                new ChangeRate("cc6", "cc7", (decimal) 0.6571),
                new ChangeRate("cc3", "cc5", (decimal) 100.1234),
                new ChangeRate("cc1", "cc5", (decimal) 10.7807),
            };

            var result = new DomainServices().Calculate(
                deviceSource, deviceTarget, 456, rates);

            Assert.IsTrue(result == 4916);
        }

        [TestMethod]
        public void should_return_correct_value_for_custom_case_with_more_than_three_possible_conversion_paths()
        {
            var deviceSource = new Currency("cc1");
            var deviceTarget = new Currency("cc5");

            var rates = new List<ChangeRate>()
            {
                new ChangeRate("cc1", "cc2", (decimal) 0.9661),
                new ChangeRate("cc1", "cc4", (decimal) 13.1151),
                new ChangeRate("cc4", "cc3", (decimal) 1.2053),
                new ChangeRate("cc3", "cc2", (decimal) 86.0305),
                new ChangeRate("cc3", "cc6", (decimal) 1.2989),
                new ChangeRate("cc6", "cc7", (decimal) 0.6571),
                new ChangeRate("cc3", "cc7", (decimal) 0.1114),
                new ChangeRate("cc7", "cc5", (decimal) 10.7807),
                new ChangeRate("cc5", "cc2", (decimal) 2.7774),
                new ChangeRate("cc3", "cc5", (decimal) 8.2348),
            };

            var result = new DomainServices().Calculate(
                deviceSource, deviceTarget, 48963, rates);

            Assert.IsTrue(result == 17029);
        }

        [TestMethod]
        public void should_return_correct_value_for_two_input_data()
        {
            var deviceSource = new Currency("EUR");
            var deviceTarget = new Currency("JPY");

            var rates = new List<ChangeRate>()
            {
                new ChangeRate("EUR", "CHF", (decimal) 0.9661),
                new ChangeRate("CHF", "JPY", (decimal) 13.1151),
            };

            var result = new DomainServices().Calculate(
                deviceSource, deviceTarget, 1000, rates);

            Assert.IsTrue(result == 12670);
        }

        [TestMethod]
        public void should_return_upper_middle_point_rounded_when_two_input_data_with_middle_point_data()
        {
            var deviceSource = new Currency("EUR");
            var deviceTarget = new Currency("JPY");

            var rates = new List<ChangeRate>()
            {
                new ChangeRate("EUR", "CHF", (decimal) 1),
                new ChangeRate("CHF", "JPY", (decimal) 1.5),
            };

            var result = new DomainServices().Calculate(
                deviceSource, deviceTarget, 1, rates);

            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void should_return_same_change_rate_when_only_one_input_data()
        {
            var deviceSource = new Currency("EUR");
            var deviceTarget = new Currency("JPY");

            var rates = new List<ChangeRate>()
            {
                new ChangeRate("EUR", "JPY", (decimal) 1),
            };

            var result = new DomainServices().Calculate(
                deviceSource, deviceTarget, 1, rates);

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void should_return_correct_inverted_value_for_one_input_value_with_quantity_one_and_change_rate_bigger_than_one()
        {
            var deviceSource = new Currency("EUR");
            var deviceTarget = new Currency("JPY");

            var rates = new List<ChangeRate>()
            {
                new ChangeRate("JPY", "EUR", (decimal) 1.789),
            };

            var result = new DomainServices().Calculate(
                deviceSource, deviceTarget, 1, rates);

            Assert.IsTrue(result == 1);
        }

        [TestMethod] public void should_return_correct_inverted_value_for_one_input_value_with_quantity_one_and_change_rate_smaller_than_one()
        {
            var deviceSource = new Currency("EUR");
            var deviceTarget = new Currency("JPY");

            var rates = new List<ChangeRate>()
            {
                new ChangeRate("JPY", "EUR", (decimal) 0.119),
            };

            var result = new DomainServices().Calculate(
                deviceSource, deviceTarget, 1, rates);

            Assert.IsTrue(result == 8);
        }

        [TestMethod]
        public void should_return_correct_inverted_value_for_one_input_value_with_quantity_more_than_one()
        {
            var deviceSource = new Currency("EUR");
            var deviceTarget = new Currency("JPY");

            var rates = new List<ChangeRate>()
            {
                new ChangeRate("JPY", "EUR", (decimal) 0.119),
            };

            var result = new DomainServices().Calculate(
                deviceSource, deviceTarget, 459, rates);

            Assert.IsTrue(result == 3857);
        }

        [TestMethod]
        public void should_return_correct_upper_rounded_value_for_one_input_value()
        {
            var deviceSource = new Currency("EUR");
            var deviceTarget = new Currency("JPY");

            var rates = new List<ChangeRate>()
            {
                new ChangeRate("EUR", "JPY", (decimal) 1.789),
            };

            var result = new DomainServices().Calculate(
                deviceSource, deviceTarget, 1, rates);

            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void should_return_correct_lower_rounded_value_for_one_input_value()
        {
            var deviceSource = new Currency("EUR");
            var deviceTarget = new Currency("JPY");

            var rates = new List<ChangeRate>()
            {
                new ChangeRate("EUR", "JPY", (decimal) 1.23),
            };

            var result = new DomainServices().Calculate(
                deviceSource, deviceTarget, 1, rates);

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void should_return_correct_rounded_value_for_one_input_value_and_quantity_different_than_one()
        {
            var deviceSource = new Currency("EUR");
            var deviceTarget = new Currency("JPY");

            var rates = new List<ChangeRate>()
            {
                new ChangeRate("EUR", "JPY", (decimal) 2.111),
            };

            var result = new DomainServices().Calculate(
                deviceSource, deviceTarget, 10, rates);

            Assert.IsTrue(result == 21);
        }

        // TODO : add a custom exception or a result class or a special case pattern
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "There is no conversion path")]
        public void should_fail_when_there_is_no_conversion_path_in_simple_case()
        {
            var deviceSource = new Currency("EUR");
            var deviceTarget = new Currency("JPY");

            var rates = new List<ChangeRate>()
            {
                new ChangeRate("EUR", "CHF", (decimal) 2.111),
            };

            var result = new DomainServices().Calculate(
                deviceSource, deviceTarget, 10, rates);
        }
    }
}
