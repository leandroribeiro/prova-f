﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProvaF.Infrastructure.Data;

namespace ProvaF.Infrastructure.Migrations
{
    [DbContext(typeof(ProvaFDbContext))]
    [Migration("20200914125718_AdicionadoDados")]
    partial class AdicionadoDados
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ProvaF.Domain.Entities.Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("Saldo")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Contas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Saldo = 100m
                        },
                        new
                        {
                            Id = 2,
                            Saldo = 200m
                        },
                        new
                        {
                            Id = 3,
                            Saldo = 300m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}