namespace StoreSystem.Domain.Entities;

public class Customer : Person
{
    public IEnumerable<Order> Orders { get; set; } = new List<Order>();
    public Customer(string firstName, string lastName) 
        : base(firstName, lastName)
    {
    }
}
