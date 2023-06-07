namespace StoreSystem.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }

    public int Count { get; set; }

    public decimal Price { get; set; }

    public IEnumerable<OrderRecord> OrderRecords { get; set; } = new List<OrderRecord>();

    public Product(string name, int count , decimal price)
    {
        Name = name;
        Count = count;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Name} ${Price} | In Storage : {Count}";
    }
}
