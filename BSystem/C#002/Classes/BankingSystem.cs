using System;
using System.Collections.Generic;
using System.Linq;
using BankingSystem.Models;

namespace BankingSystem
{
    public class BankingSystem
    {
        private List<Customer> customers = new List<Customer>();
        private List<Account> accounts = new List<Account>();

        public void AddCustomer(Customer customer) => customers.Add(customer);
        public void CreateAccount(Account account) => accounts.Add(account);

        public Customer FindCustomer(string customerId) =>
            customers.FirstOrDefault(c => c.CustomerID == customerId);

        public Account FindAccount(string accountNumber) =>
            accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);

        public void DisplayAllCustomers()
        {
            Console.WriteLine("\nAll Customers:");
            Console.WriteLine(new string('=', 50));
            customers.ForEach(c => {
                Console.WriteLine(c);
                Console.WriteLine(new string('-', 50));
            });
        }

        public void DisplayAllAccounts()
        {
            Console.WriteLine("\nAll Accounts:");
            Console.WriteLine(new string('=', 50));
            accounts.ForEach(a => {
                Console.WriteLine(a);
                Console.WriteLine(new string('-', 50));
            });
        }
    }
}