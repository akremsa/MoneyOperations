using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoneyOperations.Test
{
    [TestClass]
    public class MoneyValidatorTest
    {
        private IMoneyValidator _moneyValidator;

        [TestInitialize]
        public void Initialize()
        {
            _moneyValidator = new MoneyValidator();
        }

        [TestMethod]
        public void BasicValidation_FirstParameterNull_ThrowsArgumentNullException()
        {
            var parameter = new MoneyModel()
            {
                Amount = 5m,
                Currency = Currency.Eur
            };

            ExceptionAssert.Throws<ArgumentNullException>(() => _moneyValidator.BasicValidation(null, parameter));
        }

        [TestMethod]
        public void BasicValidation_SecondParameterNull_ThrowsArgumentNullException()
        {
            var parameter = new MoneyModel()
            {
                Amount = 5m,
                Currency = Currency.Eur
            };

            ExceptionAssert.Throws<ArgumentNullException>(() => _moneyValidator.BasicValidation(parameter, null));
        }

        [TestMethod]
        public void BasicValidation_DifferentCurrencies_ThrowsArgumentException()
        {
            var parameter1 = new MoneyModel()
            {
                Amount = 5m,
                Currency = Currency.Eur
            };

            var parameter2 = new MoneyModel()
            {
                Amount = 5m,
                Currency = Currency.Usd
            };

            ExceptionAssert.Throws<ArgumentException>(() => _moneyValidator.BasicValidation(parameter1, parameter2));
        }


        [TestMethod]
        public void BasicValidation_FirstParamLessThanZero_ThrowsArgumentException()
        {
            var parameter1 = new MoneyModel()
            {
                Amount = -2m,
                Currency = Currency.Eur
            };

            var parameter2 = new MoneyModel()
            {
                Amount = 5m,
                Currency = Currency.Eur
            };

            ExceptionAssert.Throws<ArgumentException>(() => _moneyValidator.BasicValidation(parameter1, parameter2));
        }

        [TestMethod]
        public void BasicValidation_SecondParamLessThanZero_ThrowsArgumentException()
        {
            var parameter1 = new MoneyModel()
            {
                Amount = 2m,
                Currency = Currency.Eur
            };

            var parameter2 = new MoneyModel()
            {
                Amount = -5m,
                Currency = Currency.Eur
            };

            ExceptionAssert.Throws<ArgumentException>(() => _moneyValidator.BasicValidation(parameter1, parameter2));
        }


        [TestMethod]
        public void SubtractValidation_FirstParamLessThanSecond_ThrowsArgumentException()
        {
            var parameter1 = new MoneyModel()
            {
                Amount = 2m,
                Currency = Currency.Eur
            };

            var parameter2 = new MoneyModel()
            {
                Amount = 15m,
                Currency = Currency.Eur
            };

            ExceptionAssert.Throws<ArgumentException>(() => _moneyValidator.SubtractValidation(parameter1, parameter2));
        }
    }
}
