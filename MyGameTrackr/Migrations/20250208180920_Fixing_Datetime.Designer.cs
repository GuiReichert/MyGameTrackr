﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyGameTrackr.Database;

#nullable disable

namespace MyGameTrackr.Migrations
{
    [DbContext(typeof(MyGameTrackr_Context))]
    [Migration("20250208180920_Fixing_Datetime")]
    partial class Fixing_Datetime
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyGameTrackr.Models.User.LibraryGames_Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("APIGameId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CurrentState")
                        .HasColumnType("int");

                    b.Property<string>("GameName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastStateUpdated")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Score")
                        .HasColumnType("int");

                    b.Property<int>("UserLibraryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserLibraryId");

                    b.ToTable("UserGames");
                });

            modelBuilder.Entity("MyGameTrackr.Models.User.UserLibrary_Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("User_ModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("User_ModelId")
                        .IsUnique();

                    b.ToTable("UserLibraries");
                });

            modelBuilder.Entity("MyGameTrackr.Models.User.User_Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyGameTrackr.Models.User.LibraryGames_Model", b =>
                {
                    b.HasOne("MyGameTrackr.Models.User.UserLibrary_Model", "UserLibrary")
                        .WithMany("Games")
                        .HasForeignKey("UserLibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserLibrary");
                });

            modelBuilder.Entity("MyGameTrackr.Models.User.UserLibrary_Model", b =>
                {
                    b.HasOne("MyGameTrackr.Models.User.User_Model", "User")
                        .WithOne("UserLibrary")
                        .HasForeignKey("MyGameTrackr.Models.User.UserLibrary_Model", "User_ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyGameTrackr.Models.User.UserLibrary_Model", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("MyGameTrackr.Models.User.User_Model", b =>
                {
                    b.Navigation("UserLibrary")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
