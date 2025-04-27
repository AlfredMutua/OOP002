using System;
using System.Collections.Generic;
using System.Linq;
using BankingSystem.Interfaces;


namespace BankingSystem.Models
{
    public abstract class Account : ITransaction
    {
        public string AccountNumber { get; }
        public decimal Balance { get; protected set; }
        public Customer AccountHolder { get; }
        public List<Transaction> Transactions { get; }

        protected Account(string accountNumber, Customer accountHolder, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            Balance = initialBalance;
            Transactions = new List<Transaction>();

            if (initialBalance > 0)
            {
                RecordTransaction(initialBalance, "Initial Deposit");
            }
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }

            Balance += amount;
            RecordTransaction(amount, "Deposit");
        }

        public abstract void Withdraw(decimal amount);

        public void ExecuteTransaction(decimal amount)
        {
            if (amount > 0)
            {
                Deposit(amount);
            }
            else
            {
                Withdraw(Math.Abs(amount));
            }
        }

        public void RecordTransaction(decimal amount, string transactionType)
        {
            Transactions.Add(new Transaction(AccountNumber, amount, transactionType));
        }

        public virtual void DisplayBalance()
        {
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Balance: {Balance:C}");
        }

        public void DisplayTransactionHistory()
        {
            Console.WriteLine($"\nTransaction History for Account: {AccountNumber}");
            Console.WriteLine(new string('-', 50));

            if (!Transactions.Any())
            {
                Console.WriteLine("No transactions found.");
                return;
            }

            foreach (var transaction in Transactions)
            {
                Console.WriteLine(transaction);
            }
        }

        public override string ToString()
        {
            return $"Account Number: {AccountNumber}\nType: {GetType().Name}\nHolder: {AccountHolder.Name}\nBalance: {Balance:C}";
        }
    }
}