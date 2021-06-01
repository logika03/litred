using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<User> User { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<CopyrightHolder> CopyrightHolders { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Translator> Translators { get; set; }
        public DbSet<ReaderDiary> ReaderDiaries { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<ReadingStatus> ReadingStatuses { get; set; }
        public DbSet<SubscriptionStatus> SubscriptionStatuses { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql(
        //        "Host=localhost;Port=5432;Database=library;Username=postgres;Password=postgres"
        //        );
        //}

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);
        //     var author = new Author
        //     {
        //         Id = "10",
        //         Biography = "Что-то интересное",
        //         FirstName = "Александр",
        //         LastName = "Пушкин",
        //     };
        //
        //     var genre = new Genre
        //     {
        //         Id = "4",
        //         Description = "Научно-популярная литература",
        //     };
        //
        //     var book = new Book
        //     {
        //         Id = "10",
        //         Title = "Виоамд",
        //         Authors = new List<Author> {author},
        //         Genres = new List<Genre> {genre},
        //         Description = "вомтвыаомтвам",
        //         PublicationYear = "1909",
        //         Rating = "4.5",
        //     };
        //     modelBuilder.Entity<Author>().HasData(
        //                      new Author[]
        //                      {
        //                          author
        //                      });
        //     modelBuilder.Entity<Genre>().HasData(
        //         new Genre[]
        //         {
        //             genre,
        //         });
        //     modelBuilder.Entity<Book>().HasData(
        //         new Book[]
        //         {
        //             book,
        //         });
        // }
    }
}
