﻿// <auto-generated />
using LiamellCruz_Ap1_P2.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LiamellCruz_Ap1_P2.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20241118001649_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LiamellCruz_Ap1_P2.Models.Registro", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("MyProperty1")
                        .HasColumnType("int");

                    b.Property<int>("MyProperty2")
                        .HasColumnType("int");

                    b.Property<int>("MyProperty3")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Registro");
                });
#pragma warning restore 612, 618
        }
    }
}