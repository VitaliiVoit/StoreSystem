namespace StoreSystem.Dal.Configurations;

internal class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(c => c.FullName)
            .HasColumnName(nameof(Customer.FullName))
            .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");
        builder.HasMany(c => c.Orders)
            .WithOne(o => o.CustomerNavigation)
            .HasForeignKey(o => o.CustomerId);
    }
}
