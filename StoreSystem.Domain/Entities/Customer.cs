namespace StoreSystem.Domain.Entities;

public class Customer : Person
{
    public IEnumerable<Order> Orders { get; set; } = new List<Order>();
    public IEnumerable<Debtor> Debtors { get; set; } = new List<Debtor>();
    public Customer(string firstName, string lastName) 
        : base(firstName, lastName)
    {
    }
}
