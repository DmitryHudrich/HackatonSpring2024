﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ServerApp.Logic;

#nullable disable

namespace ServerApp.Logic.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240420043821_weqaadsa")]
    partial class weqaadsa
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "postgis");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ActivityActivityType", b =>
                {
                    b.Property<long>("ActivitiesId")
                        .HasColumnType("bigint");

                    b.Property<long>("TypesId")
                        .HasColumnType("bigint");

                    b.HasKey("ActivitiesId", "TypesId");

                    b.HasIndex("TypesId");

                    b.ToTable("ActivityActivityType");
                });

            modelBuilder.Entity("ActivityTypeHobby", b =>
                {
                    b.Property<long>("LinkedActivityTypesId")
                        .HasColumnType("bigint");

                    b.Property<long>("LinkedHobbiesId")
                        .HasColumnType("bigint");

                    b.HasKey("LinkedActivityTypesId", "LinkedHobbiesId");

                    b.HasIndex("LinkedHobbiesId");

                    b.ToTable("ActivityTypeHobby");
                });

            modelBuilder.Entity("HobbyUser", b =>
                {
                    b.Property<long>("HobbiesId")
                        .HasColumnType("bigint");

                    b.Property<long>("HobbyOwnersId")
                        .HasColumnType("bigint");

                    b.HasKey("HobbiesId", "HobbyOwnersId");

                    b.HasIndex("HobbyOwnersId");

                    b.ToTable("HobbyUser");
                });

            modelBuilder.Entity("ServerApp.Logic.Entities.Activity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("CancelAge")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp(6)");

                    b.Property<Point>("Geoposition")
                        .IsRequired()
                        .HasColumnType("geography");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("WorkBegin")
                        .HasColumnType("timestamp(6)");

                    b.Property<DateTime>("WorkEnd")
                        .HasColumnType("timestamp(6)");

                    b.HasKey("Id");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("ServerApp.Logic.Entities.ActivityType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Decription")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ActivityTypes");
                });

            modelBuilder.Entity("ServerApp.Logic.Entities.FriendsPair", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("RecieverId")
                        .HasColumnType("bigint");

                    b.Property<long>("SenderId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RecieverId");

                    b.HasIndex("SenderId");

                    b.ToTable("FriendsPairs");
                });

            modelBuilder.Entity("ServerApp.Logic.Entities.Hobby", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Hobbies");
                });

            modelBuilder.Entity("ServerApp.Logic.Entities.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ServerApp.Logic.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhotoBase64")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp(6)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<Point>("SearchGeoposition")
                        .HasColumnType("geography");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ActivityActivityType", b =>
                {
                    b.HasOne("ServerApp.Logic.Entities.Activity", null)
                        .WithMany()
                        .HasForeignKey("ActivitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServerApp.Logic.Entities.ActivityType", null)
                        .WithMany()
                        .HasForeignKey("TypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ActivityTypeHobby", b =>
                {
                    b.HasOne("ServerApp.Logic.Entities.ActivityType", null)
                        .WithMany()
                        .HasForeignKey("LinkedActivityTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServerApp.Logic.Entities.Hobby", null)
                        .WithMany()
                        .HasForeignKey("LinkedHobbiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HobbyUser", b =>
                {
                    b.HasOne("ServerApp.Logic.Entities.Hobby", null)
                        .WithMany()
                        .HasForeignKey("HobbiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServerApp.Logic.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("HobbyOwnersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ServerApp.Logic.Entities.FriendsPair", b =>
                {
                    b.HasOne("ServerApp.Logic.Entities.User", "Reciever")
                        .WithMany("FriendSenders")
                        .HasForeignKey("RecieverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServerApp.Logic.Entities.User", "Sender")
                        .WithMany("FriendRecievers")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reciever");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("ServerApp.Logic.Entities.User", b =>
                {
                    b.HasOne("ServerApp.Logic.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ServerApp.Logic.Entities.User", b =>
                {
                    b.Navigation("FriendRecievers");

                    b.Navigation("FriendSenders");
                });
#pragma warning restore 612, 618
        }
    }
}
