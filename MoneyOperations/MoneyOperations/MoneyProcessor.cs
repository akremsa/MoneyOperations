namespace MoneyOperations
{
    public class MoneyProcessor: IMoneyProcessor
    {
        private readonly IMoneyValidator _moneyValidator;

        public MoneyProcessor(IMoneyValidator moneyValidator)
        {
            _moneyValidator = moneyValidator;
        }

        //Sums up two parameters
        public MoneyModel Add(MoneyModel amount1, MoneyModel amount2)
        {
            _moneyValidator.BasicValidation(amount1, amount2);

            decimal result = amount1.Amount + amount2.Amount;

            return new MoneyModel()
            {
                Amount = result,
                Currency = amount1.Currency
            };
        }

        //Subtracts second parameter from first parameter
        public MoneyModel Subtract(MoneyModel amount1, MoneyModel amount2)
        {
            _moneyValidator.BasicValidation(amount1, amount2);
            _moneyValidator.SubtractValidation(amount1, amount2);

            decimal result = amount1.Amount - amount2.Amount;

            return new MoneyModel()
            {
                Amount = result,
                Currency = amount1.Currency
            };
        }

        //Checks if amounts are the same
        public bool AreTheSame(MoneyModel amount1, MoneyModel amount2)
        {
            _moneyValidator.BasicValidation(amount1, amount2);

            return amount1.Amount == amount2.Amount;
        }

        //Returns a bigger value
        public MoneyModel Compare(MoneyModel amount1, MoneyModel amount2)
        {
            _moneyValidator.BasicValidation(amount1, amount2);

            return amount1.Amount >= amount2.Amount ? amount1 : amount2;
        }
    }
}
