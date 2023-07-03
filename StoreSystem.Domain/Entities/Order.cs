namespace StoreSystem.Domain.Entities;

public class Order : BaseEntity
{
    public int CustomerId { get; set; }
    public Customer? CustomerNavigation { get; set; }

    public Sell? SellNavigation { get; set; }

    [JsonIgnore]
    public IEnumerable<OrderRecord> OrderRecords { get; set; } = new List<OrderRecord>();
}
