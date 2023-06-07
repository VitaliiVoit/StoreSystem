namespace StoreSystem.Dal.Configurations;

internal class SellerConfig : IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        builder.Property(s => s.FullName)
            .HasColumnName(nameof(Seller.FullName))
            .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");
        builder.HasMany(s => s.Sells)
            .WithOne(s => s.SellerNavigation)
            .HasForeignKey(s => s.SellerId);
    }
}
