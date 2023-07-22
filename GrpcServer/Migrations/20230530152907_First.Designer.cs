﻿// <auto-generated />
using System;
using GrpcServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GrpcServer.Migrations
{
    [DbContext(typeof(SistD2Context))]
    [Migration("20230530152907_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GrpcServer.Models.Cobertura", b =>
                {
                    b.Property<string>("NumAdmin")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("num_administrativo");

                    b.Property<string>("Estado")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("estado");

                    b.Property<string>("Modalidade")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("modalidade");

                    b.Property<int?>("Numero")
                        .HasColumnType("int")
                        .HasColumnName("numero");

                    b.Property<string>("Operator")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("operator");

                    b.Property<string>("Rua")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("rua");

                    b.HasKey("NumAdmin")
                        .HasName("PK__Cobertura__F37EB4978306F78A");

                    b.ToTable("Cobertura");
                });

            modelBuilder.Entity("GrpcServer.Models.Operacoes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Dataatual")
                        .HasColumnType("datetime")
                        .HasColumnName("dataatual");

                    b.Property<string>("NumAdministrativo")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("num_administrativo");

                    b.Property<string>("Operacao")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("operacao");

                    b.Property<string>("Operador")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("operador");

                    b.HasKey("Id")
                        .HasName("PK__Operacoes__3213E83F240AE940");

                    b.ToTable("Operacoes");
                });

            modelBuilder.Entity("GrpcServer.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Operator")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("operator");

                    b.Property<string>("Password")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("PK__Users__3213E83F8A2C33C3");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
