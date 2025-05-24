using BookClubApp.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace BookClubApp.Server.Data
{
    public class BookClubAppContext : DbContext
    {

        public BookClubAppContext(DbContextOptions<BookClubAppContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookClub> BookClubs { get; set; }

        public DbSet<BookClubMember> BookClubMembers { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<BookMemberCompletion> BookMemberCompletions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<BookClub>().ToTable("BookClub");
            modelBuilder.Entity<BookClubMember>().ToTable("BookClubMember");
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<BookMemberCompletion>().ToTable("BookMemberCompletion");

            modelBuilder.Entity<BookClub>()
            .HasMany(e => e.Members)
            .WithOne(e => e.BookClub)
            .HasForeignKey(e => e.BookClubId)
            .IsRequired(false);
        }
    }
}
