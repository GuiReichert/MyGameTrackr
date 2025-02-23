﻿// <auto-generated />
using System;
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
    [Migration("20250212074447_Renaming_LastStateUpdated_to_LastUpdate")]
    partial class Renaming_LastStateUpdated_to_LastUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyGameTrackr.Models.GameReview_Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CurrentState")
                        .HasColumnType("int");

                    b.Property<int>("Game_ModelId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("UserLibraryId")
                        .HasColumnType("int");

                    b.Property<bool>("isAnonymousReview")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Game_ModelId");

                    b.HasIndex("UserLibraryId");

                    b.ToTable("GameReviews");
                });

            modelBuilder.Entity("MyGameTrackr.Models.Game_Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("APIGameId")
                        .HasColumnType("int");

                    b.Property<string>("GameName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("OverallScore")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Games");
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

            modelBuilder.Entity("MyGameTrackr.Models.GameReview_Model", b =>
                {
                    b.HasOne("MyGameTrackr.Models.Game_Model", "Game_Model")
                        .WithMany("Reviews")
                        .HasForeignKey("Game_ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyGameTrackr.Models.User.UserLibrary_Model", "UserLibrary")
                        .WithMany("GamesReviews")
                        .HasForeignKey("UserLibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game_Model");

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

            modelBuilder.Entity("MyGameTrackr.Models.Game_Model", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("MyGameTrackr.Models.User.UserLibrary_Model", b =>
                {
                    b.Navigation("GamesReviews");
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
