namespace MoneyOperations
{
    public interface IMoneyProcessor
    {
        MoneyModel Add(MoneyModel amount1, MoneyModel amount2);
        MoneyModel Subtract(MoneyModel amount1, MoneyModel amount2);
        MoneyModel Compare(MoneyModel amount1, MoneyModel amount2);
        bool AreTheSame(MoneyModel amount1, MoneyModel amount2);
    }
}
