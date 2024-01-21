﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PixCharge.Infrastructure;

#nullable disable

namespace PixCharge.Infrastructure.Migrations_MySqlServer.Migrations
{
    [DbContext(typeof(RegisterContext))]
    [Migration("20240121125551_ChargeMap_Domain")]
    partial class ChargeMap_Domain
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PixCharge.Domain.Account.Aggegrates.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Birth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("CorrelationID")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext")
                        .HasColumnName("Customer_Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("TaxID")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("PixCharge.Domain.Account.ValueObject.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Zipcode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("PixCharge.Domain.Transactions.Aggreggates.Charge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("BrCode")
                        .HasColumnType("longtext");

                    b.Property<string>("CorrelationID")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpiresDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ExpiresIn")
                        .HasColumnType("int");

                    b.Property<string>("GlobalID")
                        .HasColumnType("longtext");

                    b.Property<string>("Identifier")
                        .HasColumnType("longtext");

                    b.Property<string>("PaymentLinkID")
                        .HasColumnType("longtext");

                    b.Property<string>("PaymentLinkUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("PixKey")
                        .HasColumnType("longtext");

                    b.Property<string>("QrCodeImage")
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.Property<string>("TransactionID")
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("Value")
                        .HasColumnType("bigint");

                    b.Property<int>("ValueWithDiscount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Charge", (string)null);
                });

            modelBuilder.Entity("PixCharge.Domain.Transactions.Aggreggates.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CorrelationId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("DtTransaction")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Transaction", (string)null);
                });

            modelBuilder.Entity("PixCharge.Domain.Transactions.ValueObject.AdditionalInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ChargeId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Key")
                        .HasColumnType("longtext");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ChargeId");

                    b.ToTable("AdditionalInfo");
                });

            modelBuilder.Entity("PixCharge.Domain.Account.Aggegrates.Customer", b =>
                {
                    b.HasOne("PixCharge.Domain.Account.ValueObject.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("PixCharge.Domain.Account.ValueObject.Login", "Login", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("varchar(150)")
                                .HasColumnName("Email");

                            b1.Property<string>("Password")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("varchar(255)")
                                .HasColumnName("Password");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customer");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("PixCharge.Domain.Account.ValueObject.Phone", "Phone", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("varchar(50)")
                                .HasColumnName("Phone");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customer");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("Address");

                    b.Navigation("Login")
                        .IsRequired();

                    b.Navigation("Phone")
                        .IsRequired();
                });

            modelBuilder.Entity("PixCharge.Domain.Transactions.Aggreggates.Charge", b =>
                {
                    b.HasOne("PixCharge.Domain.Account.Aggegrates.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("PixCharge.Domain.Transactions.Aggreggates.Transaction", b =>
                {
                    b.HasOne("PixCharge.Domain.Account.Aggegrates.Customer", "Customer")
                        .WithMany("Transactions")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("PixCharge.Domain.Core.ValueObject.Monetary", "Value", b1 =>
                        {
                            b1.Property<Guid>("TransactionId")
                                .HasColumnType("char(36)");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Monetary");

                            b1.HasKey("TransactionId");

                            b1.ToTable("Transaction");

                            b1.WithOwner()
                                .HasForeignKey("TransactionId");
                        });

                    b.Navigation("Customer");

                    b.Navigation("Value")
                        .IsRequired();
                });

            modelBuilder.Entity("PixCharge.Domain.Transactions.ValueObject.AdditionalInfo", b =>
                {
                    b.HasOne("PixCharge.Domain.Transactions.Aggreggates.Charge", null)
                        .WithMany("AdditionalInfo")
                        .HasForeignKey("ChargeId");
                });

            modelBuilder.Entity("PixCharge.Domain.Account.Aggegrates.Customer", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("PixCharge.Domain.Transactions.Aggreggates.Charge", b =>
                {
                    b.Navigation("AdditionalInfo");
                });
#pragma warning restore 612, 618
        }
    }
}