namespace __mock__;
public class MockRegisterContext : DbContext
{
    public MockRegisterContext(DbContextOptions<MockRegisterContext> options) : base(options) {}

    public DbSet<Customer> Custumer{ get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //modelBuilder.ApplyConfiguration(new CustomerMap());
        //modelBuilder.ApplyConfiguration(new TransactionMap());
        Assert.True(true);
    }
}