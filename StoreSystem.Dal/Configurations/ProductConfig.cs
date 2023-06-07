namespace StoreSystem.Dal.Configurations;

internal class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Price)
            .HasPrecision(7, 2);
        builder.HasMany(p => p.OrderRecords)
            .WithOne(or => or.ProductNavigation)
            .HasForeignKey(or => or.ProductId);
    }
}
