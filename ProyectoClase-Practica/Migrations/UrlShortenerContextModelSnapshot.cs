﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoClase_Practica.Data;

#nullable disable

namespace ProyectoClase_Practica.Migrations
{
    [DbContext(typeof(UrlShortenerContext))]
    partial class UrlShortenerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("ProyectoClase_Practica.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Categoria 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Categoria 2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Categoria 3"
                        });
                });

            modelBuilder.Entity("ProyectoClase_Practica.Entities.UrlShortener", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LongUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Visit")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Urls");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            LongUrl = "https://www.youtube.com/watch?v=8cKvvmPwgP4&list=RD8cKvvmPwgP4&start_radio=1&ab_channel=ElCanserbero",
                            ShortUrl = "g9Kr21",
                            UserId = 1,
                            Visit = 0
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            LongUrl = "https://www.youtube.com/watch?v=v_zZmsFZDaM&list=RD8cKvvmPwgP4&index=2&ab_channel=elvecindariocalle13",
                            ShortUrl = "jrE43Ps",
                            UserId = 1,
                            Visit = 0
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            LongUrl = "https://www.youtube.com/watch?v=8SOr5IEAxbc&ab_channel=PeloMusicGroup",
                            ShortUrl = "4fOd9S",
                            UserId = 2,
                            Visit = 0
                        });
                });

            modelBuilder.Entity("ProyectoClase_Practica.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Rol")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Karen",
                            LastName = "Lasot",
                            Password = "Pa$$w0rd",
                            Rol = 0,
                            UserName = "karenbailapiola@gmail.com"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Luis Gonzalez",
                            LastName = "Gonzales",
                            Password = "lamismadesiempre",
                            Rol = 1,
                            UserName = "elluismidetotoras@gmail.com"
                        });
                });

            modelBuilder.Entity("ProyectoClase_Practica.Entities.UrlShortener", b =>
                {
                    b.HasOne("ProyectoClase_Practica.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoClase_Practica.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
