﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleEfCore.API.DbContexts;

namespace SimpleEfCore.API.Migrations
{
    [DbContext(typeof(CourseContext))]
    partial class CourseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SimpleEfCore.API.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("SimpleEfCore.API.Entities.Country", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("SimpleEfCore.API.Entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("SimpleEfCore.API.Entities.Series", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte>("Periodicity")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("ReleaseDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("WorkbookId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WorkbookId");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("SimpleEfCore.API.Entities.Workbook", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Workbook");
                });

            modelBuilder.Entity("SimpleEfCore.API.Entities.WorkbookSeries", b =>
                {
                    b.Property<Guid>("WorkbookId")
                        .HasColumnName("workbookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SeriesId")
                        .HasColumnName("seriesId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("WorkbookId", "SeriesId");

                    b.HasIndex("SeriesId");

                    b.ToTable("WorkbookSeries");
                });

            modelBuilder.Entity("SimpleEfCore.API.Entities.Author", b =>
                {
                    b.HasOne("SimpleEfCore.API.Entities.Country", "Country")
                        .WithMany("Authors")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SimpleEfCore.API.Entities.Course", b =>
                {
                    b.HasOne("SimpleEfCore.API.Entities.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SimpleEfCore.API.Entities.Series", b =>
                {
                    b.HasOne("SimpleEfCore.API.Entities.Workbook", null)
                        .WithMany("Series")
                        .HasForeignKey("WorkbookId");
                });

            modelBuilder.Entity("SimpleEfCore.API.Entities.WorkbookSeries", b =>
                {
                    b.HasOne("SimpleEfCore.API.Entities.Series", "Series")
                        .WithMany("WorkbookSeries")
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimpleEfCore.API.Entities.Workbook", "Workbook")
                        .WithMany("WorkbookSeries")
                        .HasForeignKey("WorkbookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
