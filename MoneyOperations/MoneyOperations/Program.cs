using System;

namespace MoneyOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IMoneyProcessor moneyProcessor = new MoneyProcessor(new MoneyValidator());

                var amount1 = new MoneyModel()
                {
                    Amount = 100m,
                    Currency = Currency.Eur
                };

                var amount2 = new MoneyModel()
                {
                    Amount = 50.5m,
                    Currency = Currency.Eur
                };

                var result = moneyProcessor.Subtract(amount1, amount2);

                Console.WriteLine("Result: Amount = {0}, Currency = {1}", result.Amount, result.Currency);
            }

            catch (ArgumentNullException e)
            {
                Console.WriteLine("{0}", e.Message);
            }

            catch (ArgumentException e)
            {
                Console.WriteLine("{0}", e.Message);
            }

            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }
        }
    }
}
