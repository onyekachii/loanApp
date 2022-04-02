﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace loanApp.Migrations
{
    [DbContext(typeof(LoanContext))]
    partial class LoanContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Models.Address", b =>
                {
                    b.Property<Guid>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("LGA")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("State")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Street")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("AddressID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Entities.Models.Bank", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AccountNumber")
                        .HasColumnType("float");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("Entities.Models.CompanyBank", b =>
                {
                    b.Property<Guid>("CompanyUserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("CompanyUserID");

                    b.ToTable("CompanyBanks");
                });

            modelBuilder.Entity("Entities.Models.CompanyDocument", b =>
                {
                    b.Property<Guid>("CompanyUserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("CompanyUserID");

                    b.ToTable("CompanyDocuments");
                });

            modelBuilder.Entity("Entities.Models.CompanyUser", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Industry")
                        .HasColumnType("int");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ProfileUpdated")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("CompanyUsers");
                });

            modelBuilder.Entity("Entities.Models.Contact", b =>
                {
                    b.Property<Guid>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyBranch")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("CompanyUserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.HasKey("ContactID");

                    b.HasIndex("AddressID");

                    b.HasIndex("CompanyUserID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Entities.Models.Document", b =>
                {
                    b.Property<Guid>("DocumentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DocumentTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("File")
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid?>("LoanApplicationReferenceNumber")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DocumentID");

                    b.HasIndex("LoanApplicationReferenceNumber");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Entities.Models.LoanApplication", b =>
                {
                    b.Property<Guid>("ReferenceNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,4)");

                    b.Property<Guid>("BankID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyUserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("bit");

                    b.Property<string>("PurposeForLoan")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("RepaymentPlan")
                        .HasColumnType("int");

                    b.Property<int>("TimelineType")
                        .HasColumnType("int");

                    b.HasKey("ReferenceNumber");

                    b.HasIndex("BankID");

                    b.HasIndex("CompanyUserID");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("Entities.Models.CompanyBank", b =>
                {
                    b.HasOne("Entities.Models.CompanyUser", "CompanyUser")
                        .WithMany()
                        .HasForeignKey("CompanyUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyUser");
                });

            modelBuilder.Entity("Entities.Models.CompanyDocument", b =>
                {
                    b.HasOne("Entities.Models.CompanyUser", "CompanyUser")
                        .WithMany()
                        .HasForeignKey("CompanyUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyUser");
                });

            modelBuilder.Entity("Entities.Models.Contact", b =>
                {
                    b.HasOne("Entities.Models.Address", "Address")
                        .WithMany("Contacts")
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.CompanyUser", "CompanyUser")
                        .WithMany("Contacts")
                        .HasForeignKey("CompanyUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("CompanyUser");
                });

            modelBuilder.Entity("Entities.Models.Document", b =>
                {
                    b.HasOne("Entities.Models.LoanApplication", null)
                        .WithMany("SupportingDocuments")
                        .HasForeignKey("LoanApplicationReferenceNumber");
                });

            modelBuilder.Entity("Entities.Models.LoanApplication", b =>
                {
                    b.HasOne("Entities.Models.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.CompanyUser", "CompanyUser")
                        .WithMany()
                        .HasForeignKey("CompanyUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");

                    b.Navigation("CompanyUser");
                });

            modelBuilder.Entity("Entities.Models.Address", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("Entities.Models.CompanyUser", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("Entities.Models.LoanApplication", b =>
                {
                    b.Navigation("SupportingDocuments");
                });
#pragma warning restore 612, 618
        }
    }
}
