using System;
using BankingSystem.Models;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("🏦 Welcome to the Banking System Console App!");
            Console.ResetColor();

            BankingSystem bank = new BankingSystem();

            // sample customers
            Customer customer1 = new Customer("John Doe", "john.doe@email.com", "C1001");
            Customer customer2 = new Customer("Jane Smith", "jane.smith@email.com", "C1002");

            bank.AddCustomer(customer1);
            bank.AddCustomer(customer2);

            // sample accounts
            SavingsAccount savings1 = new SavingsAccount("SA1001", customer1, 1000m);
            CurrentAccount current1 = new CurrentAccount("CA1001", customer1, 500m);
            SavingsAccount savings2 = new SavingsAccount("SA1002", customer2, 2000m);

            bank.CreateAccount(savings1);
            bank.CreateAccount(current1);
            bank.CreateAccount(savings2);

            bool exit = false;
            while (!exit)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. View All Customers");
                Console.WriteLine("2. View All Accounts");
                Console.WriteLine("3. Perform Transaction");
                Console.WriteLine("4. View Account Details");
                Console.WriteLine("5. Apply Interest (Savings Account)");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                Console.ResetColor();

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            bank.DisplayAllCustomers();
                            break;

                        case "2":
                            bank.DisplayAllAccounts();
                            break;

                        case "3":
                            PerformTransaction(bank);
                            break;

                        case "4":
                            ViewAccountDetails(bank);
                            break;

                        case "5":
                            ApplyInterest(bank);
                            break;

                        case "6":
                            exit = true;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Thank you for using the Banking System. Goodbye!");
                            Console.ResetColor();
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid choice. Please try again.");
                            Console.ResetColor();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                }
            }
        }

        static void PerformTransaction(BankingSystem bank)
        {
            Console.Write("\nEnter account number: ");
            string accNumber = Console.ReadLine();

            Account account = bank.FindAccount(accNumber);
            if (account == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Account not found.");
                Console.ResetColor();
                return;
            }

            Console.Write("Enter amount (positive for deposit, negative for withdrawal): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid amount.");
                Console.ResetColor();
                return;
            }

            account.ExecuteTransaction(amount);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Transaction completed successfully.");
            Console.WriteLine($"New Balance: {account.Balance:C}");
            Console.ResetColor();
        }

        static void ViewAccountDetails(BankingSystem bank)
        {
            Console.Write("\nEnter account number: ");
            string accNumber = Console.ReadLine();

            Account account = bank.FindAccount(accNumber);
            if (account == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Account not found.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nAccount Details:");
            Console.WriteLine(new string('=', 50));
            Console.ResetColor();

            Console.WriteLine(account);
            account.DisplayBalance();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nCustomer Details:");
            Console.WriteLine(new string('=', 50));
            Console.ResetColor();

            Console.WriteLine(account.AccountHolder);

            account.DisplayTransactionHistory();
        }

        static void ApplyInterest(BankingSystem bank)
        {
            Console.Write("\nEnter savings account number: ");
            string accNumber = Console.ReadLine();

            Account account = bank.FindAccount(accNumber);
            if (account == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Account not found.");
                Console.ResetColor();
                return;
            }

            if (account is SavingsAccount savingsAccount)
            {
                savingsAccount.ApplyInterest();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Interest applied successfully.");
                Console.WriteLine($"New Balance: {savingsAccount.Balance:C}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Interest can only be applied to savings accounts.");
                Console.ResetColor();
            }
        }
    }
}