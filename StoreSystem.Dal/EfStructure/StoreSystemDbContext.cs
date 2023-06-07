namespace StoreSystem.Dal.EfStructure;

internal class StoreSystemDbContext : DbContext
{
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Seller> Sellers => Set<Seller>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderRecord> OrderRecords => Set<OrderRecord>();
    public DbSet<Sell> Sells => Set<Sell>();

    public StoreSystemDbContext(DbContextOptions options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            assembly: typeof(StoreSystemDbContext).Assembly);
    }
}
