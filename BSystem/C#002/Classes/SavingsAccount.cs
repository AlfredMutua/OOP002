using BankingSystem.Interfaces;
using BankingSystem.Models;
using System;

namespace BankingSystem.Models
{
    public class SavingsAccount : Account
    {
        public decimal InterestRate { get; } = 0.02m;

        public SavingsAccount(string accountNumber, Customer accountHolder, decimal initialBalance)
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

        public void ApplyInterest()
        {
            decimal interest = Balance * InterestRate;
            Balance += interest;
            RecordTransaction(interest, "Interest Applied");
        }

        public override void DisplayBalance()
        {
            base.DisplayBalance();
            Console.WriteLine($"Interest Rate: {InterestRate:P}");
        }
    }
}