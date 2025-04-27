using System;

namespace BankingSystem.Models
{
    public class Transaction
    {
        public DateTime Timestamp { get; }
        public decimal Amount { get; }
        public string TransactionType { get; }
        public string AccountNumber { get; }

        public Transaction(string accountNumber, decimal amount, string transactionType)
        {
            AccountNumber = accountNumber;
            Amount = amount;
            TransactionType = transactionType;
            Timestamp = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Timestamp:yyyy-MM-dd HH:mm:ss} | {TransactionType} | Amount: {Amount:C}";
        }
    }
}