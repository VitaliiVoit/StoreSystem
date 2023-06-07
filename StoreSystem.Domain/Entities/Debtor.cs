namespace StoreSystem.Domain.Entities;

public class Debtor : BaseEntity
{
    public int CustomerId { get; set; }
    public Customer? CustomerNavigation { get; set; }

    public int OrderId { get; set; }
    public Order? OrderNavigation { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime? DebtClosedDate { get; set; }
}
