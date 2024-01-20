﻿using PixCharge.Domain.Account.Aggegrates;
using PixCharge.Domain.Account.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PixCharge.Repository.Mapping;
public class CustomerMap : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(nameof(Customer));

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();            
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Birth).IsRequired();
        builder.Property(x => x.CPF).IsRequired().HasMaxLength(14);

        builder.OwnsOne<Phone>(e => e.Phone, c =>
        {
            c.Property(x => x.Number).HasColumnName("Phone").HasMaxLength(50).IsRequired();

        });

        builder.OwnsOne<Login>(e => e.Login, c =>
        {
           c.Property(x => x.Email).HasColumnName("Email").HasMaxLength(150).IsRequired();
            c.Property(x => x.Password).HasColumnName("Password").HasMaxLength(255).IsRequired();
        });       

    }
}
