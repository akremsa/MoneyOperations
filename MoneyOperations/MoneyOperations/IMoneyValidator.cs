namespace MoneyOperations
{
    public interface IMoneyValidator
    {
        void BasicValidation(MoneyModel amount1, MoneyModel amount2);
        void SubtractValidation(MoneyModel amount1, MoneyModel amount2);
    }
}
