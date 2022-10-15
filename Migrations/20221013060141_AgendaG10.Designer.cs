﻿// <auto-generated />
using BackendFinalGrupo10.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackendFinalGrupo10.Migrations
{
    [DbContext(typeof(AgendaContext))]
    [Migration("20221013060141_AgendaG10")]
    partial class AgendaG10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("BackendFinalGrupo10.Entitys.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Andrea",
                            Number = "(341) 155-544-333",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ariana",
                            Number = "(341) 155-222-333",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Victor",
                            Number = "(341) 155-111-333",
                            UserId = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "Carlos",
                            Number = "(341) 155-544-683",
                            UserId = 3
                        });
                });

            modelBuilder.Entity("BackendFinalGrupo10.Entitys.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "a@gmail.com",
                            LastName = "Ligorria",
                            Name = "Franco",
                            Password = "12345",
                            UserName = "franco12345"
                        },
                        new
                        {
                            Id = 2,
                            Email = "a@gmail.com",
                            LastName = "Luciano",
                            Name = "Olivia",
                            Password = "12345",
                            UserName = "olivia12345"
                        },
                        new
                        {
                            Id = 3,
                            Email = "a@gmail.com",
                            LastName = "Maranzana",
                            Name = "Agustin",
                            Password = "12345",
                            UserName = "agustin12345"
                        });
                });

            modelBuilder.Entity("BackendFinalGrupo10.Entitys.Contact", b =>
                {
                    b.HasOne("BackendFinalGrupo10.Entitys.User", "User")
                        .WithMany("Contacts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BackendFinalGrupo10.Entitys.User", b =>
                {
                    b.Navigation("Contacts");
                });
#pragma warning restore 612, 618
        }
    }
}
