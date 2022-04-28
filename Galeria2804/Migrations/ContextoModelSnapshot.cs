﻿// <auto-generated />
using Galeria2804.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Galeria2804.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Galeria2804.Models.Imagem", b =>
                {
                    b.Property<int>("imagemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("imagemId"), 1L, 1);

                    b.Property<string>("imagemDescricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imagemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("imagemTam")
                        .HasColumnType("int");

                    b.Property<string>("imagemType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("imagemId");

                    b.ToTable("Imagens");
                });
#pragma warning restore 612, 618
        }
    }
}
