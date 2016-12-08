using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ExampleNotDisposing.Models;

namespace ExampleNotDisposing.Migrations
{
    [DbContext(typeof(CompanyDbContext))]
    [Migration("20161208034554_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExampleNotDisposing.Models.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Ein");

                    b.Property<DateTime?>("UpdatedOn")
                        .IsConcurrencyToken();

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ExampleNotDisposing.Models.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CompanyId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<DateTime?>("UpdatedOn")
                        .IsConcurrencyToken();

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ExampleNotDisposing.Models.Employee", b =>
                {
                    b.HasOne("ExampleNotDisposing.Models.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
