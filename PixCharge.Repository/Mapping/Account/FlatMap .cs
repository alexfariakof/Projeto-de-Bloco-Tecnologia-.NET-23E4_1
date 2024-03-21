using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PixCharge.Domain.Account.Aggregates;

namespace PixCharge.Repository.Mapping.Account;
public class FlatMap : IEntityTypeConfiguration<Flat>
{
    public void Configure(EntityTypeBuilder<Flat> builder)
    {
        builder.ToTable(nameof(Flat));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.DtCreated).IsRequired().ValueGeneratedOnAdd();
        builder.Property(x => x.DtActivation).IsRequired();

        builder.OwnsOne(d => d.Value, c =>
        {
            c.Property(x => x.Value)
            .HasColumnName("Monetary")
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        });

        builder.HasOne(x => x.Customer).WithMany(c => c.Flats).IsRequired();
    }
}