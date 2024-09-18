﻿// <auto-generated />
using System;
using DATA.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DATA.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240918123214_UpdateBookModel")]
    partial class UpdateBookModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StartMyNewApp.Domain.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateEdition")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Disponibilite")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("StartMyNewApp.Domain.Models.Loan", b =>
                {
                    b.Property<int>("IdEmprunt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmprunt"));

                    b.Property<DateTime>("DateEmprunt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateRetour")
                        .HasColumnType("datetime2");

                    b.Property<int>("FKAdherent")
                        .HasColumnType("int");

                    b.Property<int>("FKLivre")
                        .HasColumnType("int");

                    b.HasKey("IdEmprunt");

                    b.HasIndex("FKAdherent");

                    b.HasIndex("FKLivre");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("StartMyNewApp.Domain.Models.Person", b =>
                {
                    b.Property<int>("IdPersonne")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPersonne"));

                    b.Property<string>("Cin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FKAdherent")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPersonne");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("StartMyNewApp.Domain.Models.Reservation", b =>
                {
                    b.Property<int>("IdReservation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReservation"));

                    b.Property<int>("FKLivre")
                        .HasColumnType("int");

                    b.Property<int>("FKPersonne")
                        .HasColumnType("int");

                    b.HasKey("IdReservation");

                    b.HasIndex("FKLivre");

                    b.HasIndex("FKPersonne");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("StartMyNewApp.Domain.Models.Loan", b =>
                {
                    b.HasOne("StartMyNewApp.Domain.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("FKAdherent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StartMyNewApp.Domain.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("FKLivre")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StartMyNewApp.Domain.Models.Reservation", b =>
                {
                    b.HasOne("StartMyNewApp.Domain.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("FKLivre")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StartMyNewApp.Domain.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("FKPersonne")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
