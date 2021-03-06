﻿// <auto-generated />
using System;
using Acongrebility.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Acongrebility.Migrations
{
    [DbContext(typeof(AcongrebilityContext))]
    partial class AcongrebilityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Acongrebility.Models.Bills", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatePassedFailed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateProposed")
                        .HasColumnType("datetime2");

                    b.Property<int>("DemSupport")
                        .HasColumnType("int");

                    b.Property<int>("IndSupport")
                        .HasColumnType("int");

                    b.Property<string>("LegalName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PassedHouse")
                        .HasColumnType("bit");

                    b.Property<bool>("PassedSenate")
                        .HasColumnType("bit");

                    b.Property<string>("ProposedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RepSupport")
                        .HasColumnType("int");

                    b.Property<string>("StreetName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("Acongrebility.Models.Congressmembers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTookOffice")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Party")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VotingHistory")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Congressmembers");
                });
#pragma warning restore 612, 618
        }
    }
}
