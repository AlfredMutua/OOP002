namespace BankingSystem.Interfaces
{
    public interface ITransaction
    {
        void ExecuteTransaction(decimal amount);
        void RecordTransaction(decimal amount, string transactionType);
    }
}