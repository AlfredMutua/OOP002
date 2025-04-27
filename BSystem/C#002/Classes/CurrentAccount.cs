using BankingSystem.Interfaces;
using BankingSystem.Models;
using System;

namespace BankingSystem.Models
{
    public class CurrentAccount : Account
    {
        public decimal OverdraftLimit { get; } = 1000m;

        public CurrentAccount(string accountNumber, Customer accountHolder, decimal initialBalance)
            : base(accountNumber, accountHolder, initialBalance) { }

        public override void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }

           

            Balance -= amount;
            RecordTransaction(amount, "Withdrawal");
        }

        public override void DisplayBalance()
        {
            base.DisplayBalance();
            Console.WriteLine($"Overdraft Limit: {OverdraftLimit:C}");
        }
    }
}