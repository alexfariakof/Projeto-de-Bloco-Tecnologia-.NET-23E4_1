using PixCharge.Domain.Transactions.Aggreggates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PixCharge.Repository.Mapping;
public class ChargeMap : IEntityTypeConfiguration<Charge>
{
    public void Configure(EntityTypeBuilder<Charge> builder)
    {
        builder.ToTable(nameof(Charge));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasOne(x => x.Customer)
       .WithMany(cb => cb.Charges)
       .HasForeignKey(x => x.CorrelationID)
       .IsRequired();
    }
}