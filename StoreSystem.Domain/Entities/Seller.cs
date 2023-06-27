namespace StoreSystem.Domain.Entities;

public class Seller : Person
{
    [Required, StringLength(10)]
    public string Phone { get; set; }

    [Required, StringLength(50)]
    public string Password { get; set; }
    public IEnumerable<Sell> Sells { get; set; } = new List<Sell>();
    public Seller(string firstName, string lastName, string phone, string password) 
        : base(firstName, lastName)
    {
        Phone = phone;
        Password = password;
    }
}
