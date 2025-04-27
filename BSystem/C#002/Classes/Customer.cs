namespace BankingSystem.Models
{
    public class Customer
    {
        public string Name { get; }
        public string ContactInfo { get; }
        public string CustomerID { get; }

        public Customer(string name, string contactInfo, string customerId)
        {
            Name = name;
            ContactInfo = contactInfo;
            CustomerID = customerId;
        }

        public override string ToString()
        {
            return $"Customer ID: {CustomerID}\nName: {Name}\nContact: {ContactInfo}";
        }
    }
}