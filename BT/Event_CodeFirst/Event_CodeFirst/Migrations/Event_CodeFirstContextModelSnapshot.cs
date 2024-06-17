﻿// <auto-generated />
using System;
using Event_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Event_CodeFirst.Migrations
{
    [DbContext(typeof(Event_CodeFirstContext))]
    partial class Event_CodeFirstContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Event_CodeFirst.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"), 1L, 1);

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("EventTypeId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            CreateAt = new DateTime(2024, 6, 17, 22, 59, 46, 992, DateTimeKind.Local).AddTicks(3388),
                            CreatedBy = "johndoe",
                            Description = "Annual tech conference",
                            EventTypeId = 1,
                            Title = "Tech Conference 2024"
                        },
                        new
                        {
                            EventId = 2,
                            CreateAt = new DateTime(2024, 6, 17, 22, 59, 46, 992, DateTimeKind.Local).AddTicks(3397),
                            CreatedBy = "janedoe",
                            Description = "Monthly local meetup",
                            EventTypeId = 2,
                            Title = "Local Meetup"
                        });
                });

            modelBuilder.Entity("Event_CodeFirst.Models.EventType", b =>
                {
                    b.Property<int>("EventTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventTypeId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventTypeId");

                    b.ToTable("EventTypes");

                    b.HasData(
                        new
                        {
                            EventTypeId = 1,
                            Name = "Conference"
                        },
                        new
                        {
                            EventTypeId = 2,
                            Name = "Meetup"
                        },
                        new
                        {
                            EventTypeId = 3,
                            Name = "Workshop"
                        });
                });

            modelBuilder.Entity("Event_CodeFirst.Models.Feedback", b =>
                {
                    b.Property<int>("FId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FId");

                    b.HasIndex("EventId");

                    b.ToTable("Feedbacks");

                    b.HasData(
                        new
                        {
                            FId = 1,
                            Description = "Great event!",
                            EventId = 1,
                            Rate = 5,
                            UserName = "johndoe"
                        },
                        new
                        {
                            FId = 2,
                            Description = "Very informative.",
                            EventId = 1,
                            Rate = 4,
                            UserName = "janedoe"
                        },
                        new
                        {
                            FId = 3,
                            Description = "Looking forward to the next one.",
                            EventId = 2,
                            Rate = 5,
                            UserName = "johndoe"
                        });
                });

            modelBuilder.Entity("Event_CodeFirst.Models.User", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserName");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserName = "johndoe",
                            Address = "123 Main St",
                            Dob = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "John",
                            LastName = "Doe",
                            Phone = "123-456-7890"
                        },
                        new
                        {
                            UserName = "janedoe",
                            Address = "456 Oak St",
                            Dob = new DateTime(1992, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Jane",
                            LastName = "Doe",
                            Phone = "987-654-3210"
                        });
                });

            modelBuilder.Entity("Event_CodeFirst.Models.Event", b =>
                {
                    b.HasOne("Event_CodeFirst.Models.User", "User")
                        .WithMany("Events")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Event_CodeFirst.Models.EventType", "EventType")
                        .WithMany("Events")
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Event_CodeFirst.Models.Feedback", b =>
                {
                    b.HasOne("Event_CodeFirst.Models.Event", "Event")
                        .WithMany("Feedbacks")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Event_CodeFirst.Models.Event", b =>
                {
                    b.Navigation("Feedbacks");
                });

            modelBuilder.Entity("Event_CodeFirst.Models.EventType", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("Event_CodeFirst.Models.User", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
