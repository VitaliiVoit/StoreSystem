namespace StoreSystem.Dal.Configurations;

internal class SellConfig : IEntityTypeConfiguration<Sell>
{
    public void Configure(EntityTypeBuilder<Sell> builder)
    {
        builder.Property(s => s.TotalAmount)
            .HasPrecision(7, 2);
        builder.HasOne(s => s.OrderNavigation)
            .WithOne(o => o.SellNavigation)
            .HasForeignKey<Sell>(s => s.OrderId);
    }
}
