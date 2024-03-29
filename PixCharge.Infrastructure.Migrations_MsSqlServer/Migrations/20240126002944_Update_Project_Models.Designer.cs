﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PixCharge.Repository;

#nullable disable

namespace PixCharge.Infrastructure.Migrations_MsSqlServer.Migrations
{
    [DbContext(typeof(RegisterContext))]
    [Migration("20240126002944_Update_Project_Models")]
    partial class Update_Project_Models
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PixCharge.Domain.Account.Aggregates.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birth")
                        .HasColumnType("datetime2");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<Guid?>("CorrelationID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Customer_Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TaxID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("PixCharge.Domain.Account.ValueObject.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zipcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("PixCharge.Domain.Transactions.Aggregates.Charge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CorrelationID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpiresDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExpiresIn")
                        .HasColumnType("int");

                    b.Property<string>("GlobalID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentLinkID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentLinkUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PixKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QrCodeImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ValueWithDiscount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CorrelationID");

                    b.ToTable("Charge", (string)null);
                });

            modelBuilder.Entity("PixCharge.Domain.Transactions.Aggregates.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CorrelationId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DtTransaction")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CorrelationId");

                    b.ToTable("Transaction", (string)null);
                });

            modelBuilder.Entity("PixCharge.Domain.Account.Aggregates.Customer", b =>
                {
                    b.HasOne("PixCharge.Domain.Account.ValueObject.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("PixCharge.Domain.Account.ValueObject.Login", "Login", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)")
                                .HasColumnName("Email");

                            b1.Property<string>("Password")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)")
                                .HasColumnName("Password");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customer");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("PixCharge.Domain.Account.ValueObject.Phone", "Phone", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
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

            modelBuilder.Entity("PixCharge.Domain.Transactions.Aggregates.Charge", b =>
                {
                    b.HasOne("PixCharge.Domain.Account.Aggregates.Customer", "Customer")
                        .WithMany("Charges")
                        .HasForeignKey("CorrelationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("PixCharge.Domain.Core.ValueObject.Monetary", "Value", b1 =>
                        {
                            b1.Property<Guid>("ChargeId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Monetary");

                            b1.HasKey("ChargeId");

                            b1.ToTable("Charge");

                            b1.WithOwner()
                                .HasForeignKey("ChargeId");
                        });

                    b.Navigation("Customer");

                    b.Navigation("Value")
                        .IsRequired();
                });

            modelBuilder.Entity("PixCharge.Domain.Transactions.Aggregates.Transaction", b =>
                {
                    b.HasOne("PixCharge.Domain.Account.Aggregates.Customer", "Customer")
                        .WithMany("Transactions")
                        .HasForeignKey("CorrelationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("PixCharge.Domain.Core.ValueObject.Monetary", "Value", b1 =>
                        {
                            b1.Property<Guid>("TransactionId")
                                .HasColumnType("uniqueidentifier");

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

            modelBuilder.Entity("PixCharge.Domain.Account.Aggregates.Customer", b =>
                {
                    b.Navigation("Charges");

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
