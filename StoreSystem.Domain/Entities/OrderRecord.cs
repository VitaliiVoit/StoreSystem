namespace StoreSystem.Domain.Entities;

public class OrderRecord : BaseEntity
{
    public int ProductId { get; set; }
    public Product? ProductNavigation { get; set; }

    public int ProductCount { get; set; }

    public int OrderId { get; set; }
    public Order? OrderNavigation { get; set; }
}
