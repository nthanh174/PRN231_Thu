using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Event_CodeFirst.Models
{
    public class Event_CodeFirstContext : DbContext
    {
        public Event_CodeFirstContext() { }

        public Event_CodeFirstContext(DbContextOptions<Event_CodeFirstContext> options) : base(options)
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

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventType> EventTypes { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { UserName = "johndoe", FirstName = "John", LastName = "Doe", Dob = new DateTime(1990, 1, 1), Address = "123 Main St", Phone = "123-456-7890" },
                new User { UserName = "janedoe", FirstName = "Jane", LastName = "Doe", Dob = new DateTime(1992, 2, 2), Address = "456 Oak St", Phone = "987-654-3210" }
            );

            modelBuilder.Entity<EventType>().HasData(
                new EventType { EventTypeId = 1, Name = "Conference" },
                new EventType { EventTypeId = 2, Name = "Meetup" },
                new EventType { EventTypeId = 3, Name = "Workshop" }
            );

            modelBuilder.Entity<Event>().HasData(
                new Event { EventId = 1, Title = "Tech Conference 2024", Description = "Annual tech conference", EventTypeId = 1, CreateAt = DateTime.Now, CreatedBy = "johndoe" },
                new Event { EventId = 2, Title = "Local Meetup", Description = "Monthly local meetup", EventTypeId = 2, CreateAt = DateTime.Now, CreatedBy = "janedoe" }
            );

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback { FId = 1, Description = "Great event!", UserName = "johndoe", EventId = 1, Rate = 5 },
                new Feedback { FId = 2, Description = "Very informative.", UserName = "janedoe", EventId = 1, Rate = 4 },
                new Feedback { FId = 3, Description = "Looking forward to the next one.", UserName = "johndoe", EventId = 2, Rate = 5 }
            );
        }
    }
}
