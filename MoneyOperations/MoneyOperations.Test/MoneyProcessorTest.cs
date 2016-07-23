using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MoneyOperations.Test
{
    [TestClass]
    public class MoneyProcessorTest
    {
        private IMoneyProcessor _moneyProcessor;
        private Mock<IMoneyValidator> _moneyValidatorMock;

        [TestInitialize]
        public void Initialize()
        {
            _moneyValidatorMock = new Mock<IMoneyValidator>();
            _moneyValidatorMock.Setup(x => x.BasicValidation(It.IsAny<MoneyModel>(), It.IsAny<MoneyModel>())).Verifiable();
            _moneyProcessor = new MoneyProcessor(_moneyValidatorMock.Object);
        }

        [TestMethod]
        public void Add_ValidAmounts_ObjectWithCorrectAmount()
        {
            //arrange
            var amount1 = new MoneyModel()
            {
                Amount = 11m,
                Currency = Currency.Rub
            };

            var amount2 = new MoneyModel()
            {
                Amount = 10m,
                Currency = Currency.Rub
            };

            //act
            var result = _moneyProcessor.Add(amount1, amount2);

            //assert
            Assert.IsTrue(result.Amount == 21m);
            Assert.IsTrue(result.Currency == Currency.Rub);
            _moneyValidatorMock.Verify(x => x.BasicValidation(amount1, amount2), Times.Once);
        }

        [TestMethod]
        public void Subtract_ValidAmounts_ObjectWithCorrectAmount()
        {
            //arrange
            var amount1 = new MoneyModel()
            {
                Amount = 11m,
                Currency = Currency.Rub
            };

            var amount2 = new MoneyModel()
            {
                Amount = 1m,
                Currency = Currency.Rub
            };

            //act
            var result = _moneyProcessor.Subtract(amount1, amount2);

            //assert
            Assert.IsTrue(result.Amount == 10m);
            Assert.IsTrue(result.Currency == Currency.Rub);
            _moneyValidatorMock.Verify(x => x.BasicValidation(amount1, amount2), Times.Once);
            _moneyValidatorMock.Verify(x => x.SubtractValidation(amount1, amount2), Times.Once);
        }

        [TestMethod]
        public void AreTheSame_ValidAmounts_True()
        {
            //arrange
            var amount1 = new MoneyModel()
            {
                Amount = 11m,
                Currency = Currency.Rub
            };

            var amount2 = new MoneyModel()
            {
                Amount = 11m,
                Currency = Currency.Rub
            };

            //act
            var result = _moneyProcessor.AreTheSame(amount1, amount2);

            //assert
            Assert.IsTrue(result);
            _moneyValidatorMock.Verify(x => x.BasicValidation(amount1, amount2), Times.Once);
        }

        [TestMethod]
        public void Compare_ValidAmounts_ObjectWithABiggerAmount()
        {
            //arrange
            var amount1 = new MoneyModel()
            {
                Amount = 11m,
                Currency = Currency.Rub
            };

            var amount2 = new MoneyModel()
            {
                Amount = 2m,
                Currency = Currency.Rub
            };

            //act
            var result = _moneyProcessor.Compare(amount1, amount2);

            //assert
            Assert.IsTrue(result.Amount == 11m);
            Assert.IsTrue(result.Currency == Currency.Rub);
            _moneyValidatorMock.Verify(x => x.BasicValidation(amount1, amount2), Times.Once);
        }

        [TestMethod]
        public void Compare_ValidEqualAmounts_TheSameObject()
        {
            //arrange
            var amount1 = new MoneyModel()
            {
                Amount = 11m,
                Currency = Currency.Rub
            };

            var amount2 = new MoneyModel()
            {
                Amount = 11m,
                Currency = Currency.Rub
            };

            //act
            var result = _moneyProcessor.Compare(amount1, amount2);

            //assert
            Assert.IsTrue(result.Amount == 11m);
            Assert.IsTrue(result.Currency == Currency.Rub);
            _moneyValidatorMock.Verify(x => x.BasicValidation(amount1, amount2), Times.Once);
        }
    }
}
