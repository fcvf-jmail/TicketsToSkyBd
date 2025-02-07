﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TicketsToSkyBd;

#nullable disable

namespace TicketsToSkyBd.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TicketsToSkyBd.Entities.FoundTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float?>("BaggageWeight")
                        .HasColumnType("real");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DepartureCode")
                        .HasColumnType("text");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DestinationCode")
                        .HasColumnType("text");

                    b.Property<DateTime>("DestinationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("FlightDuration")
                        .HasColumnType("integer");

                    b.Property<float?>("HandBaggageWeight")
                        .HasColumnType("real");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("integer");

                    b.Property<int?>("TransfersCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DepartureCode");

                    b.HasIndex("DestinationCode");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("FoundTickets");
                });

            modelBuilder.Entity("TicketsToSkyBd.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Airport")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("TicketsToSkyBd.Entities.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AttemptedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FailureReason")
                        .HasColumnType("text");

                    b.Property<bool>("Sent")
                        .HasColumnType("boolean");

                    b.Property<int>("TicketId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("TicketsToSkyBd.Entities.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DepartureCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DestinationCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("MaxFlightDuration")
                        .HasColumnType("integer");

                    b.Property<decimal?>("MaxPrice")
                        .HasColumnType("numeric");

                    b.Property<int?>("MaxTransfersCount")
                        .HasColumnType("integer");

                    b.Property<float?>("MinBaggageWeight")
                        .HasColumnType("real");

                    b.Property<float?>("MinHandBaggageWeight")
                        .HasColumnType("real");

                    b.Property<int>("SearchCount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DepartureCode");

                    b.HasIndex("DestinationCode");

                    b.HasIndex("UserId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("TicketsToSkyBd.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ChatId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChatId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TicketsToSkyBd.Entities.FoundTicket", b =>
                {
                    b.HasOne("TicketsToSkyBd.Entities.Location", "DepartureLocation")
                        .WithMany()
                        .HasForeignKey("DepartureCode")
                        .HasPrincipalKey("Code");

                    b.HasOne("TicketsToSkyBd.Entities.Location", "DestinationLocation")
                        .WithMany()
                        .HasForeignKey("DestinationCode")
                        .HasPrincipalKey("Code");

                    b.HasOne("TicketsToSkyBd.Entities.Subscription", "Subscription")
                        .WithMany()
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DepartureLocation");

                    b.Navigation("DestinationLocation");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("TicketsToSkyBd.Entities.Notification", b =>
                {
                    b.HasOne("TicketsToSkyBd.Entities.FoundTicket", "FoundTicket")
                        .WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketsToSkyBd.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoundTicket");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TicketsToSkyBd.Entities.Subscription", b =>
                {
                    b.HasOne("TicketsToSkyBd.Entities.Location", "DepartureLocation")
                        .WithMany()
                        .HasForeignKey("DepartureCode")
                        .HasPrincipalKey("Code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketsToSkyBd.Entities.Location", "DestinationLocation")
                        .WithMany()
                        .HasForeignKey("DestinationCode")
                        .HasPrincipalKey("Code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketsToSkyBd.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DepartureLocation");

                    b.Navigation("DestinationLocation");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
