namespace CurrencyGraph.Appication
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using CurrencyGraph.Appication.Interfaces;
    using CurrencyGraph.Presentation;

    public class ApplicationServices : IApplicationServices
    {
        private readonly IDomainServices domainServices;

        public ApplicationServices(IDomainServices domainServices)
        {
            this.domainServices = domainServices;
        }

        public decimal Calculate(string question, IEnumerable<string> data)
        {
            var splitQuestion = question.Trim().Split(';');

            if (splitQuestion.Length != 3)
                throw new ArgumentException("The first line containing the question was not correctly formated");

            var source = splitQuestion[0];
            var target = splitQuestion[2];

            decimal quantity;

            if (!decimal.TryParse(
                    splitQuestion[1],
                    NumberStyles.AllowDecimalPoint,
                    CultureInfo.InvariantCulture,
                    out quantity))
                throw new ArgumentException(
                    "The first line contained a second parameter that does not represent a quantity");

            var changeRateDtoList = new List<ChangeRateDto>();
            foreach (var changeRate in data)
            {
                var splitInputChangeRate = changeRate.Trim().Split(';');

                if (splitInputChangeRate.Length != 3)
                    throw new ArgumentException("The input of change rates has a format issue");

                decimal rate;

                if (!decimal.TryParse(
                        splitInputChangeRate[2],
                        NumberStyles.AllowDecimalPoint,
                        CultureInfo.InvariantCulture,
                        out rate))
                    throw new ArgumentException("The change rate of one of the inputs was not in the correct format");
                var changeRateDto = new ChangeRateDto(splitInputChangeRate[0], splitInputChangeRate[1], rate);
                changeRateDtoList.Add(changeRateDto);
            }

            return this.domainServices.Calculate(source, target, quantity, changeRateDtoList);
        }
    }
}