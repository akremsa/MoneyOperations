using System;

namespace MoneyOperations
{
    public class MoneyValidator: IMoneyValidator
    {
        public void BasicValidation(MoneyModel amount1, MoneyModel amount2)
        {
            ThrowIfNull(amount1);
            ThrowIfNull(amount2);
            ThrowIfDifferentCurrencies(amount1, amount2);
            ThrowIfLessThanZero(amount1);
            ThrowIfLessThanZero(amount2);
        }

        public void SubtractValidation(MoneyModel amount1, MoneyModel amount2)
        {
            ThrowIfFirstLessThanSecond(amount1, amount2);
        }

        private void ThrowIfFirstLessThanSecond(MoneyModel amount1, MoneyModel amount2)
        {
            if (amount1.Amount < amount2.Amount)
            {
                throw new ArgumentException("First parameter is less than second. Can not perform subtraction.");
            }
        }

        private static void ThrowIfNull(MoneyModel amount)
        {
            if (amount == null)
            {
                throw new ArgumentNullException("amount", "Provided parameter is null");
            }
        }

        private static void ThrowIfDifferentCurrencies(MoneyModel amount1, MoneyModel amount2)
        {
            if (amount1.Currency != amount2.Currency)
            {
                throw new ArgumentException("Provided amounts of money have different currencies");
            }
        }

        private static void ThrowIfLessThanZero(MoneyModel amount)
        {
            if (amount.Amount < 0)
            {
                throw new ArgumentException("Amount of money cold nod be less than a zero");
            }
        }
    }
}
