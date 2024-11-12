﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Personal_Store.Persistence.Contexts;

#nullable disable

namespace Personal_Store.Persistence.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20241106180139_AddBaseEntityToUserTable")]
    partial class AddBaseEntityToUserTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Personal_Store.Domain.Entities.Users.Role", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            Name = "Admin"
                        },
                        new
                        {
                            ID = 2L,
                            Name = "Operator"
                        },
                        new
                        {
                            ID = 3L,
                            Name = "Customer"
                        });
                });

            modelBuilder.Entity("Personal_Store.Domain.Entities.Users.User", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Personal_Store.Domain.Entities.Users.UserInRole", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long>("RoleID")
                        .HasColumnType("bigint");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.HasIndex("UserID");

                    b.ToTable("UserInRoles");
                });

            modelBuilder.Entity("Personal_Store.Domain.Entities.Users.UserInRole", b =>
                {
                    b.HasOne("Personal_Store.Domain.Entities.Users.Role", "Role")
                        .WithMany("UserInRoles")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Personal_Store.Domain.Entities.Users.User", "User")
                        .WithMany("UserInRoles")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Personal_Store.Domain.Entities.Users.Role", b =>
                {
                    b.Navigation("UserInRoles");
                });

            modelBuilder.Entity("Personal_Store.Domain.Entities.Users.User", b =>
                {
                    b.Navigation("UserInRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
