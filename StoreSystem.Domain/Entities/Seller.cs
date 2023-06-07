namespace StoreSystem.Domain.Entities;

public class Seller : Person
{
    public IEnumerable<Sell> Sells { get; set; } = new List<Sell>();
    public Seller(string firstName, string lastName) 
        : base(firstName, lastName)
    {
    }
}
