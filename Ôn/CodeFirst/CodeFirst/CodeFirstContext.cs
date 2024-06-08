using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class CodeFirstContext : DbContext
    {
        public CodeFirstContext() { }
        public CodeFirstContext(DbContextOptions<CodeFirstContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionBuilder.UseSqlServer(configuration.GetConnectionString("MyConnectionString"));
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Category 1" },
            new Category { Id = 2, Name = "Category 2" },
            new Category { Id = 3, Name = "Category 3" }
        );
            modelBuilder.Entity<Book>().HasData(
           new Book { Id = 1, Name = "Book 1", CategoryId = 1, CreateAt = DateTime.Now },
           new Book { Id = 2, Name = "Book 2", CategoryId = 1, CreateAt = DateTime.Now },
           new Book { Id = 3, Name = "Book 3", CategoryId = 1, CreateAt = DateTime.Now }
       );
        }
    }
}
