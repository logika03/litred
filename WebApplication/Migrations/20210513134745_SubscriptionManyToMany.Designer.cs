﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication.Models;

namespace WebApplication.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210513134745_SubscriptionManyToMany")]
    partial class SubscriptionManyToMany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<string>("AuthorsId")
                        .HasColumnType("text");

                    b.Property<string>("BooksId")
                        .HasColumnType("text");

                    b.HasKey("AuthorsId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("BookCopyrightHolder", b =>
                {
                    b.Property<string>("BooksId")
                        .HasColumnType("text");

                    b.Property<string>("CopyrightHoldersId")
                        .HasColumnType("text");

                    b.HasKey("BooksId", "CopyrightHoldersId");

                    b.HasIndex("CopyrightHoldersId");

                    b.ToTable("BookCopyrightHolder");
                });

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.Property<string>("BooksId")
                        .HasColumnType("text");

                    b.Property<string>("GenresId")
                        .HasColumnType("text");

                    b.HasKey("BooksId", "GenresId");

                    b.HasIndex("GenresId");

                    b.ToTable("BookGenre");
                });

            modelBuilder.Entity("BookTheme", b =>
                {
                    b.Property<string>("BooksId")
                        .HasColumnType("text");

                    b.Property<string>("ThemesId")
                        .HasColumnType("text");

                    b.HasKey("BooksId", "ThemesId");

                    b.HasIndex("ThemesId");

                    b.ToTable("BookTheme");
                });

            modelBuilder.Entity("BookTranslator", b =>
                {
                    b.Property<string>("BooksId")
                        .HasColumnType("text");

                    b.Property<string>("TranslatorsId")
                        .HasColumnType("text");

                    b.HasKey("BooksId", "TranslatorsId");

                    b.HasIndex("TranslatorsId");

                    b.ToTable("BookTranslator");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

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
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SubscriptionUser", b =>
                {
                    b.Property<string>("SubscriptionsId")
                        .HasColumnType("text");

                    b.Property<string>("UsersId")
                        .HasColumnType("text");

                    b.HasKey("SubscriptionsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("SubscriptionUser");
                });

            modelBuilder.Entity("WebApplication.Models.Author", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Biography")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("WebApplication.Models.Book", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("BookCover")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("PublicationYear")
                        .HasColumnType("text");

                    b.Property<string>("Rating")
                        .HasColumnType("text");

                    b.Property<string>("SubscriptionTypeId")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionTypeId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("WebApplication.Models.CopyrightHolder", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CopyrightHolders");
                });

            modelBuilder.Entity("WebApplication.Models.FAQ", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Answer")
                        .HasColumnType("text");

                    b.Property<string>("Question")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FAQs");
                });

            modelBuilder.Entity("WebApplication.Models.Genre", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("WebApplication.Models.ReaderDiary", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("BookId")
                        .HasColumnType("text");

                    b.Property<string>("ReadingStatusId")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("ReadingStatusId");

                    b.HasIndex("UserId");

                    b.ToTable("ReaderDiaries");
                });

            modelBuilder.Entity("WebApplication.Models.ReadingStatus", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ReadingStatuses");
                });

            modelBuilder.Entity("WebApplication.Models.Review", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AuthorId")
                        .HasColumnType("text");

                    b.Property<string>("BookId")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("Raiting")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("WebApplication.Models.Subscription", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("SubscriptionStatusId")
                        .HasColumnType("text");

                    b.Property<string>("SubscriptionTypeId")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("WeekCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionStatusId");

                    b.HasIndex("SubscriptionTypeId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("WebApplication.Models.SubscriptionStatus", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SubscriptionStatuses");
                });

            modelBuilder.Entity("WebApplication.Models.SubscriptionType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SubscriptionTypes");
                });

            modelBuilder.Entity("WebApplication.Models.Theme", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("WebApplication.Models.Translator", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Translators");
                });

            modelBuilder.Entity("WebApplication.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("WebApplication.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookCopyrightHolder", b =>
                {
                    b.HasOne("WebApplication.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication.Models.CopyrightHolder", null)
                        .WithMany()
                        .HasForeignKey("CopyrightHoldersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.HasOne("WebApplication.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookTheme", b =>
                {
                    b.HasOne("WebApplication.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication.Models.Theme", null)
                        .WithMany()
                        .HasForeignKey("ThemesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookTranslator", b =>
                {
                    b.HasOne("WebApplication.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication.Models.Translator", null)
                        .WithMany()
                        .HasForeignKey("TranslatorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.HasOne("WebApplication.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebApplication.Models.User", null)
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

                    b.HasOne("WebApplication.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebApplication.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SubscriptionUser", b =>
                {
                    b.HasOne("WebApplication.Models.Subscription", null)
                        .WithMany()
                        .HasForeignKey("SubscriptionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication.Models.Book", b =>
                {
                    b.HasOne("WebApplication.Models.SubscriptionType", "SubscriptionType")
                        .WithMany()
                        .HasForeignKey("SubscriptionTypeId");

                    b.Navigation("SubscriptionType");
                });

            modelBuilder.Entity("WebApplication.Models.ReaderDiary", b =>
                {
                    b.HasOne("WebApplication.Models.Book", "Book")
                        .WithMany("ReaderDiaries")
                        .HasForeignKey("BookId");

                    b.HasOne("WebApplication.Models.ReadingStatus", "ReadingStatus")
                        .WithMany("ReaderDiaries")
                        .HasForeignKey("ReadingStatusId");

                    b.HasOne("WebApplication.Models.User", "User")
                        .WithMany("ReaderDiaries")
                        .HasForeignKey("UserId");

                    b.Navigation("Book");

                    b.Navigation("ReadingStatus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplication.Models.Review", b =>
                {
                    b.HasOne("WebApplication.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("WebApplication.Models.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId");

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("WebApplication.Models.Subscription", b =>
                {
                    b.HasOne("WebApplication.Models.SubscriptionStatus", "SubscriptionStatus")
                        .WithMany()
                        .HasForeignKey("SubscriptionStatusId");

                    b.HasOne("WebApplication.Models.SubscriptionType", "SubscriptionType")
                        .WithMany()
                        .HasForeignKey("SubscriptionTypeId");

                    b.Navigation("SubscriptionStatus");

                    b.Navigation("SubscriptionType");
                });

            modelBuilder.Entity("WebApplication.Models.Book", b =>
                {
                    b.Navigation("ReaderDiaries");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("WebApplication.Models.ReadingStatus", b =>
                {
                    b.Navigation("ReaderDiaries");
                });

            modelBuilder.Entity("WebApplication.Models.User", b =>
                {
                    b.Navigation("ReaderDiaries");
                });
#pragma warning restore 612, 618
        }
    }
}