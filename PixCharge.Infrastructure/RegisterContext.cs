using Microsoft.EntityFrameworkCore;
using PixCharge.Domain.Account.Aggegrates;
using PixCharge.Domain.Transactions.Aggreggates;
using PixCharge.Repository.Mapping;

namespace PixCharge.Infrastructure;
public class RegisterContext: DbContext
{
    public RegisterContext(DbContextOptions<RegisterContext> options) : base(options) { }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Transaction> Transaction { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CustomerMap());
        modelBuilder.ApplyConfiguration(new TransactionMap());
    }
}
