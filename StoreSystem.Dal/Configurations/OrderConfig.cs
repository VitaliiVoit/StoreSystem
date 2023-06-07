namespace StoreSystem.Dal.Configurations;

internal class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasMany(o => o.OrderRecords)
            .WithOne(or => or.OrderNavigation)
            .HasForeignKey(or => or.OrderId);
    }
}
