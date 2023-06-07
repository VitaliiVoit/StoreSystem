namespace StoreSystem.Domain.Entities;

public class Sell : BaseEntity
{
    public int OrderId { get; set; }
    public Order? OrderNavigation { get; set; }

    public int SellerId { get; set; }
    public Seller? SellerNavigation { get; set; }

    public decimal TotalAmount { get; set; }
}
