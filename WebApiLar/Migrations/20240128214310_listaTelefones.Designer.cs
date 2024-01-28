﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiLar.DataContext;

#nullable disable

namespace WebApiLar.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240128214310_listaTelefones")]
    partial class listaTelefones
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApiLar.Models.PessoaModel", b =>
                {
                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataDeNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cpf");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("WebApiLar.Models.TelefoneModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CpfPessoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PessoaModelCpf")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PessoaModelCpf");

                    b.ToTable("Telefone");
                });

            modelBuilder.Entity("WebApiLar.Models.TelefoneModel", b =>
                {
                    b.HasOne("WebApiLar.Models.PessoaModel", null)
                        .WithMany("Telefones")
                        .HasForeignKey("PessoaModelCpf");
                });

            modelBuilder.Entity("WebApiLar.Models.PessoaModel", b =>
                {
                    b.Navigation("Telefones");
                });
#pragma warning restore 612, 618
        }
    }
}
