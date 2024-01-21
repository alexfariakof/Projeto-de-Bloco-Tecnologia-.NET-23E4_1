﻿using PixCharge.Domain.Transactions.Aggreggates;
using PixCharge.Domain.Core.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PixCharge.Repository.Mapping;
public class TransactionMap : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable(nameof(Transaction));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.DtTransaction).IsRequired();
        builder.Property(x => x.Description).IsRequired().HasMaxLength(50);

        builder.HasOne(x => x.Customer)
               .WithMany(cb => cb.Transactions)
               .HasForeignKey(x => x.CorrelationId)
               .IsRequired();

        builder.OwnsOne<Monetary>(d => d.Value, c =>
        {
            c.Property(x => x.Value)
            .HasColumnName("Monetary")
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        });
    }
}