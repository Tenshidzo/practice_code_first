using practice_code_first.models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace practice_code_first
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Book")
        {
        }

        public DbSet<Library> Libraries { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publication> Publications { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Настройка связи "один ко многим" между Library и Book
            modelBuilder.Entity<Library>()
                .HasMany(l => l.Books)
                .WithRequired(b => b.Library)
                .HasForeignKey(b => b.LibraryId);

            // Настройка связи "один ко многим" между Book и Publication
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Publications)
                .WithRequired(p => p.Book)
                .HasForeignKey(p => p.BookId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
