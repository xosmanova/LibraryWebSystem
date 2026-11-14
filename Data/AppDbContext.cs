using System;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Member> Members { get; set; } = null!;
        public DbSet<Publisher> Publishers { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial books catalog
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1001,
                    Title = "Independent Women",
                    AlternateTitle = "A Tale of Courage",
                    Author = "Elizabeth Hailey",
                    Category = "Self development",
                    Publisher = "Dar al-shorouk",
                    Language = "English",
                    CopiesAvailable = 15,
                    Price = 1000,
                    Status = "Available",
                    IsActive = true,
                    Description = "An inspiring novel exploring resilience, personal growth, and self-discovery.",
                    CoverImageUrl = "/images/covers/book1001.svg",
                    CreatedAt = new DateTime(2024, 1, 10, 10, 0, 0)
                },
                new Book
                {
                    Id = 1002,
                    Title = "Never Ending Sky",
                    AlternateTitle = "Endless Horizons",
                    Author = "Joseph Kirland",
                    Category = "Novels",
                    Publisher = "Dar dawen",
                    Language = "English",
                    CopiesAvailable = 8,
                    Price = 800,
                    Status = "Issued",
                    IsActive = true,
                    Description = "A modern adventure novel traversing uncharted horizons and life discoveries.",
                    CoverImageUrl = "/images/covers/book1002.svg",
                    CreatedAt = new DateTime(2024, 1, 15, 11, 30, 0)
                },
                new Book
                {
                    Id = 1003,
                    Title = "Bands Of Sisters",
                    AlternateTitle = "Together We Stand",
                    Author = "Lauren Willig",
                    Category = "Comedy",
                    Publisher = "Aseer alktob",
                    Language = "English",
                    CopiesAvailable = 12,
                    Price = 1000,
                    Status = "Available",
                    IsActive = true,
                    Description = "A witty and heartwarming tale of sisterhood, humor, and wartime solidarity.",
                    CoverImageUrl = "/images/covers/book1003.svg",
                    CreatedAt = new DateTime(2024, 2, 1, 14, 20, 0)
                },
                new Book
                {
                    Id = 1004,
                    Title = "Harry Potter",
                    AlternateTitle = "The Sorcerer's Stone",
                    Author = "J. K. Rowling",
                    Category = "Novels",
                    Publisher = "Dar al-shorouk",
                    Language = "English",
                    CopiesAvailable = 30,
                    Price = 5000,
                    Status = "Reserved",
                    IsActive = false,
                    Description = "The legendary beginning of Harry Potter's journey at Hogwarts School of Witchcraft and Wizardry.",
                    CoverImageUrl = "/images/covers/book1004.svg",
                    CreatedAt = new DateTime(2024, 2, 10, 9, 15, 0)
                },
                new Book
                {
                    Id = 1005,
                    Title = "It Ends With Us",
                    AlternateTitle = "Breaking the Cycle",
                    Author = "Colleen Hoover",
                    Category = "Drama & Romance",
                    Publisher = "Dar dawen",
                    Language = "English",
                    CopiesAvailable = 25,
                    Price = 5000,
                    Status = "Issued",
                    IsActive = true,
                    Description = "A deeply moving story of love, difficult choices, and breaking painful cycles.",
                    CoverImageUrl = "/images/covers/book1005.svg",
                    CreatedAt = new DateTime(2024, 2, 18, 16, 45, 0)
                },
                new Book
                {
                    Id = 1006,
                    Title = "Genius Foods",
                    AlternateTitle = "Become Smarter, Happier",
                    Author = "Paul Grewal",
                    Category = "Health, Fitness & Dieting",
                    Publisher = "Aseer alktob",
                    Language = "English",
                    CopiesAvailable = 18,
                    Price = 5000,
                    Status = "Available",
                    IsActive = false,
                    Description = "A practical guide exploring the connection between nutritious diet, cognitive health, and mental clarity.",
                    CoverImageUrl = "/images/covers/book1006.svg",
                    CreatedAt = new DateTime(2024, 2, 25, 12, 0, 0)
                },
                new Book
                {
                    Id = 1007,
                    Title = "Heart Bones",
                    AlternateTitle = "Ocean Whispers",
                    Author = "Colleen Hoover",
                    Category = "Drama & Romance",
                    Publisher = "Dar dawen",
                    Language = "English",
                    CopiesAvailable = 10,
                    Price = 5000,
                    Status = "Overdue",
                    IsActive = true,
                    Description = "A poignant summer romance unraveling secrets from the past on the Texas coast.",
                    CoverImageUrl = "/images/covers/book1007.svg",
                    CreatedAt = new DateTime(2024, 3, 2, 15, 30, 0)
                },
                new Book
                {
                    Id = 1008,
                    Title = "Reminders of Him",
                    AlternateTitle = "Letters to the Past",
                    Author = "Colleen Hoover",
                    Category = "Novels",
                    Publisher = "Dar al-shorouk",
                    Language = "English",
                    CopiesAvailable = 14,
                    Price = 1000,
                    Status = "Available",
                    IsActive = false,
                    Description = "A gripping and emotional journey of redemption, motherhood, and finding hope against all odds.",
                    CoverImageUrl = "/images/covers/book1008.svg",
                    CreatedAt = new DateTime(2024, 3, 10, 18, 0, 0)
                }
            );

            // Seed Members
            modelBuilder.Entity<Member>().HasData(
                new Member { Id = 1, FullName = "Karim Jannat", Email = "karim.j@gmail.com", Phone = "+1 (555) 123-4567", MembershipType = "Student", BooksBorrowed = 2, Status = "Active", JoinedDate = new DateTime(2023, 9, 1), AvatarUrl = "/images/avatars/avatar1.svg" },
                new Member { Id = 2, FullName = "Abdul Samad", Email = "abdul.s@yahoo.com", Phone = "+1 (555) 234-5678", MembershipType = "Faculty", BooksBorrowed = 3, Status = "Active", JoinedDate = new DateTime(2023, 10, 12), AvatarUrl = "/images/avatars/avatar2.svg" },
                new Member { Id = 3, FullName = "Will Sameed", Email = "will.sameed@outlook.com", Phone = "+1 (555) 345-6789", MembershipType = "Student", BooksBorrowed = 1, Status = "Active", JoinedDate = new DateTime(2023, 11, 5), AvatarUrl = "/images/avatars/avatar3.svg" },
                new Member { Id = 4, FullName = "Azaduzamman Mia", Email = "azad.mia@mail.com", Phone = "+1 (555) 456-7890", MembershipType = "Premium", BooksBorrowed = 4, Status = "Active", JoinedDate = new DateTime(2023, 11, 20), AvatarUrl = "/images/avatars/avatar4.svg" },
                new Member { Id = 5, FullName = "Hosneyara Gulbahar", Email = "gulbahar.h@gmail.com", Phone = "+1 (555) 567-8901", MembershipType = "Standard", BooksBorrowed = 0, Status = "Active", JoinedDate = new DateTime(2024, 1, 15), AvatarUrl = "/images/avatars/avatar5.svg" },
                new Member { Id = 6, FullName = "Asif Mahmud", Email = "asif.mahmud@library.edu", Phone = "+1 (555) 678-9012", MembershipType = "Student", BooksBorrowed = 2, Status = "Suspended", JoinedDate = new DateTime(2024, 2, 1), AvatarUrl = "/images/avatars/avatar6.svg" }
            );

            // Seed Publishers
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "Dar al-shorouk", Country = "Egypt", Email = "info@shorouk.com", Phone = "+20 2 24023399", Address = "Cairo, Egypt", TotalBooks = 3, EstablishedYear = 1968 },
                new Publisher { Id = 2, Name = "Dar dawen", Country = "Egypt", Email = "contact@dawen.net", Phone = "+20 2 27951122", Address = "Cairo, Egypt", TotalBooks = 3, EstablishedYear = 2008 },
                new Publisher { Id = 3, Name = "Aseer alktob", Country = "Saudi Arabia", Email = "help@aseeralktob.com", Phone = "+966 11 4056789", Address = "Riyadh, Saudi Arabia", TotalBooks = 2, EstablishedYear = 2012 },
                new Publisher { Id = 4, Name = "Pajeri Publication", Country = "Turkey", Email = "info@pajeri.com.tr", Phone = "+90 212 555 1234", Address = "Istanbul, Turkey", TotalBooks = 4, EstablishedYear = 1995 },
                new Publisher { Id = 5, Name = "Haque Publications", Country = "United Kingdom", Email = "info@haque.co.uk", Phone = "+44 20 7946 0912", Address = "London, UK", TotalBooks = 2, EstablishedYear = 2005 },
                new Publisher { Id = 6, Name = "Crown Publishing", Country = "United States", Email = "contact@crownpublishing.com", Phone = "+1 (212) 555-0145", Address = "New York, NY", TotalBooks = 5, EstablishedYear = 1992 }
            );

            // Seed Authors
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "Elizabeth Hailey", Country = "United States", BooksCount = 1, PopularGenre = "Self development", Biography = "American journalist and author known for compelling character-driven personal narratives.", AvatarUrl = "/images/avatars/avatar1.svg" },
                new Author { Id = 2, Name = "Joseph Kirland", Country = "United Kingdom", BooksCount = 1, PopularGenre = "Novels", Biography = "British author renowned for fast-paced contemporary adventure and speculative fiction.", AvatarUrl = "/images/avatars/avatar2.svg" },
                new Author { Id = 3, Name = "Lauren Willig", Country = "United States", BooksCount = 1, PopularGenre = "Comedy", Biography = "Bestselling novelist recognized for historical fiction, engaging dialogue, and wit.", AvatarUrl = "/images/avatars/avatar3.svg" },
                new Author { Id = 4, Name = "J. K. Rowling", Country = "United Kingdom", BooksCount = 1, PopularGenre = "Novels", Biography = "British author renowned worldwide for the acclaimed Harry Potter fantasy series.", AvatarUrl = "/images/avatars/avatar4.svg" },
                new Author { Id = 5, Name = "Colleen Hoover", Country = "United States", BooksCount = 3, PopularGenre = "Drama & Romance", Biography = "Number one New York Times bestselling author of contemporary romance and poignant psychological fiction.", AvatarUrl = "/images/avatars/avatar5.svg" },
                new Author { Id = 6, Name = "Paul Grewal", Country = "Canada", BooksCount = 1, PopularGenre = "Health, Fitness & Dieting", Biography = "Physician and internal medicine specialist focused on functional wellness, nutrition, and metabolic health.", AvatarUrl = "/images/avatars/avatar6.svg" }
            );
        }
    }
}
