﻿// <auto-generated />
using System;
using CabinetBooking.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CabinetBooking.Domain.Data.Migrations
{
    [DbContext(typeof(CabinetBookingDbContext))]
    [Migration("20250222221453_AddLessons")]
    partial class AddLessons
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("cabinet_booking")
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CabinetBooking.Domain.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CabinetId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cabinet_id");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<int>("LessonId")
                        .HasColumnType("integer")
                        .HasColumnName("lesson_id");

                    b.HasKey("Id")
                        .HasName("pk_bookings");

                    b.HasIndex("CabinetId")
                        .HasDatabaseName("ix_bookings_cabinet_id");

                    b.HasIndex("LessonId")
                        .HasDatabaseName("ix_bookings_lesson_id");

                    b.ToTable("bookings", "cabinet_booking");
                });

            modelBuilder.Entity("CabinetBooking.Domain.Cabinet", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("Number");

                    b.Property<string>("CabinetType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cabinet_type");

                    b.Property<bool>("IsProjector")
                        .HasColumnType("boolean")
                        .HasColumnName("is_projector");

                    b.Property<bool>("IsTechnical")
                        .HasColumnType("boolean")
                        .HasColumnName("is_technical");

                    b.HasKey("Id")
                        .HasName("pk_cabinets");

                    b.ToTable("cabinets", "cabinet_booking");
                });

            modelBuilder.Entity("CabinetBooking.Domain.Lesson", b =>
                {
                    b.Property<int>("LessonNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("lesson_number");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LessonNumber"));

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time without time zone")
                        .HasColumnName("end_time");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time without time zone")
                        .HasColumnName("start_time");

                    b.HasKey("LessonNumber")
                        .HasName("pk_lessons");

                    b.ToTable("lessons", "cabinet_booking");
                });

            modelBuilder.Entity("CabinetBooking.Domain.Booking", b =>
                {
                    b.HasOne("CabinetBooking.Domain.Cabinet", null)
                        .WithMany("Bookings")
                        .HasForeignKey("CabinetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_bookings_cabinets_cabinet_id");

                    b.HasOne("CabinetBooking.Domain.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_bookings_lessons_lesson_id");

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("CabinetBooking.Domain.Cabinet", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
