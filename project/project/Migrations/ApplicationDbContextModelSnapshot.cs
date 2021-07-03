﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using project.Data;

namespace project.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("project.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("isSuperAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isWorker")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("project.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("project.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<int>("Stars")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Warsaw",
                            Country = "Poland",
                            Name = "Hotel Grand",
                            Stars = 4
                        },
                        new
                        {
                            Id = 2,
                            City = "Warsaw",
                            Country = "Poland",
                            Name = "Hotel Superb",
                            Stars = 4
                        },
                        new
                        {
                            Id = 3,
                            City = "Krakow",
                            Country = "Poland",
                            Name = "Hotel Tajwand",
                            Stars = 5
                        });
                });

            modelBuilder.Entity("project.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("FromEmail")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MessageContent")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<int>("ToEmail")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isAnswer")
                        .HasColumnType("INTEGER");

                    b.Property<int>("isAnswerTo")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isToWorker")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("project.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BedsQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HotelId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsApartament")
                        .HasColumnType("INTEGER");

                    b.Property<double>("PricePerNight")
                        .HasColumnType("REAL");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StandardQuality")
                        .HasColumnType("INTEGER");

                    b.HasKey("RoomId");

                    b.HasIndex("HotelId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            RoomId = 1,
                            BedsQuantity = 2,
                            HotelId = 1,
                            IsApartament = false,
                            PricePerNight = 200.0,
                            RoomNumber = 1,
                            StandardQuality = 2
                        },
                        new
                        {
                            RoomId = 2,
                            BedsQuantity = 2,
                            HotelId = 1,
                            IsApartament = false,
                            PricePerNight = 250.0,
                            RoomNumber = 2,
                            StandardQuality = 2
                        },
                        new
                        {
                            RoomId = 3,
                            BedsQuantity = 2,
                            HotelId = 1,
                            IsApartament = false,
                            PricePerNight = 200.0,
                            RoomNumber = 3,
                            StandardQuality = 2
                        },
                        new
                        {
                            RoomId = 4,
                            BedsQuantity = 2,
                            HotelId = 1,
                            IsApartament = false,
                            PricePerNight = 300.0,
                            RoomNumber = 4,
                            StandardQuality = 2
                        },
                        new
                        {
                            RoomId = 5,
                            BedsQuantity = 2,
                            HotelId = 1,
                            IsApartament = false,
                            PricePerNight = 250.0,
                            RoomNumber = 5,
                            StandardQuality = 2
                        },
                        new
                        {
                            RoomId = 6,
                            BedsQuantity = 2,
                            HotelId = 1,
                            IsApartament = false,
                            PricePerNight = 200.0,
                            RoomNumber = 6,
                            StandardQuality = 2
                        },
                        new
                        {
                            RoomId = 7,
                            BedsQuantity = 2,
                            HotelId = 1,
                            IsApartament = false,
                            PricePerNight = 250.0,
                            RoomNumber = 7,
                            StandardQuality = 2
                        },
                        new
                        {
                            RoomId = 8,
                            BedsQuantity = 4,
                            HotelId = 1,
                            IsApartament = true,
                            PricePerNight = 400.0,
                            RoomNumber = 8,
                            StandardQuality = 3
                        },
                        new
                        {
                            RoomId = 9,
                            BedsQuantity = 4,
                            HotelId = 1,
                            IsApartament = true,
                            PricePerNight = 400.0,
                            RoomNumber = 9,
                            StandardQuality = 3
                        },
                        new
                        {
                            RoomId = 10,
                            BedsQuantity = 5,
                            HotelId = 1,
                            IsApartament = true,
                            PricePerNight = 500.0,
                            RoomNumber = 10,
                            StandardQuality = 3
                        },
                        new
                        {
                            RoomId = 11,
                            BedsQuantity = 2,
                            HotelId = 2,
                            IsApartament = false,
                            PricePerNight = 200.0,
                            RoomNumber = 1,
                            StandardQuality = 2
                        },
                        new
                        {
                            RoomId = 12,
                            BedsQuantity = 2,
                            HotelId = 2,
                            IsApartament = false,
                            PricePerNight = 250.0,
                            RoomNumber = 2,
                            StandardQuality = 2
                        },
                        new
                        {
                            RoomId = 13,
                            BedsQuantity = 2,
                            HotelId = 2,
                            IsApartament = false,
                            PricePerNight = 200.0,
                            RoomNumber = 3,
                            StandardQuality = 2
                        },
                        new
                        {
                            RoomId = 14,
                            BedsQuantity = 2,
                            HotelId = 2,
                            IsApartament = false,
                            PricePerNight = 300.0,
                            RoomNumber = 4,
                            StandardQuality = 2
                        },
                        new
                        {
                            RoomId = 15,
                            BedsQuantity = 2,
                            HotelId = 2,
                            IsApartament = false,
                            PricePerNight = 250.0,
                            RoomNumber = 5,
                            StandardQuality = 2
                        },
                        new
                        {
                            RoomId = 16,
                            BedsQuantity = 2,
                            HotelId = 2,
                            IsApartament = false,
                            PricePerNight = 200.0,
                            RoomNumber = 6,
                            StandardQuality = 2
                        },
                        new
                        {
                            RoomId = 17,
                            BedsQuantity = 2,
                            HotelId = 2,
                            IsApartament = false,
                            PricePerNight = 250.0,
                            RoomNumber = 7,
                            StandardQuality = 2
                        },
                        new
                        {
                            RoomId = 18,
                            BedsQuantity = 4,
                            HotelId = 2,
                            IsApartament = true,
                            PricePerNight = 400.0,
                            RoomNumber = 8,
                            StandardQuality = 3
                        },
                        new
                        {
                            RoomId = 19,
                            BedsQuantity = 4,
                            HotelId = 2,
                            IsApartament = true,
                            PricePerNight = 400.0,
                            RoomNumber = 9,
                            StandardQuality = 3
                        },
                        new
                        {
                            RoomId = 20,
                            BedsQuantity = 5,
                            HotelId = 2,
                            IsApartament = true,
                            PricePerNight = 500.0,
                            RoomNumber = 10,
                            StandardQuality = 3
                        },
                        new
                        {
                            RoomId = 21,
                            BedsQuantity = 2,
                            HotelId = 3,
                            IsApartament = false,
                            PricePerNight = 200.0,
                            RoomNumber = 1,
                            StandardQuality = 2
                        },
                        new
                        {
                            RoomId = 22,
                            BedsQuantity = 2,
                            HotelId = 3,
                            IsApartament = false,
                            PricePerNight = 250.0,
                            RoomNumber = 2,
                            StandardQuality = 2
                        },
                        new
                        {
                            RoomId = 23,
                            BedsQuantity = 2,
                            HotelId = 3,
                            IsApartament = false,
                            PricePerNight = 200.0,
                            RoomNumber = 3,
                            StandardQuality = 2
                        },
                        new
                        {
                            RoomId = 24,
                            BedsQuantity = 2,
                            HotelId = 3,
                            IsApartament = false,
                            PricePerNight = 300.0,
                            RoomNumber = 4,
                            StandardQuality = 2
                        },
                        new
                        {
                            RoomId = 25,
                            BedsQuantity = 2,
                            HotelId = 3,
                            IsApartament = false,
                            PricePerNight = 250.0,
                            RoomNumber = 5,
                            StandardQuality = 2
                        },
                        new
                        {
                            RoomId = 26,
                            BedsQuantity = 2,
                            HotelId = 3,
                            IsApartament = false,
                            PricePerNight = 200.0,
                            RoomNumber = 6,
                            StandardQuality = 2
                        },
                        new
                        {
                            RoomId = 27,
                            BedsQuantity = 2,
                            HotelId = 3,
                            IsApartament = false,
                            PricePerNight = 250.0,
                            RoomNumber = 7,
                            StandardQuality = 2
                        },
                        new
                        {
                            RoomId = 28,
                            BedsQuantity = 4,
                            HotelId = 3,
                            IsApartament = true,
                            PricePerNight = 400.0,
                            RoomNumber = 8,
                            StandardQuality = 3
                        },
                        new
                        {
                            RoomId = 29,
                            BedsQuantity = 4,
                            HotelId = 3,
                            IsApartament = true,
                            PricePerNight = 400.0,
                            RoomNumber = 9,
                            StandardQuality = 3
                        },
                        new
                        {
                            RoomId = 30,
                            BedsQuantity = 5,
                            HotelId = 3,
                            IsApartament = true,
                            PricePerNight = 500.0,
                            RoomNumber = 10,
                            StandardQuality = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("project.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("project.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("project.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("project.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("project.Models.Room", b =>
                {
                    b.HasOne("project.Models.Hotel", null)
                        .WithMany("AllRooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("project.Models.Hotel", b =>
                {
                    b.Navigation("AllRooms");
                });
#pragma warning restore 612, 618
        }
    }
}
