﻿// <auto-generated />
using DAL.Application.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace DAL.Application.EntityFramework.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171211184057_AddApplicationUser")]
    partial class AddApplicationUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Blah", b =>
                {
                    b.Property<int>("BlahId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BlahValue")
                        .HasMaxLength(50);

                    b.HasKey("BlahId");

                    b.ToTable("Blahs");
                });

            modelBuilder.Entity("Domain.FooBar", b =>
                {
                    b.Property<int>("FooBarId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FooBarValue")
                        .HasMaxLength(50);

                    b.HasKey("FooBarId");

                    b.ToTable("FooBars");
                });

            modelBuilder.Entity("Domain.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("IdentityRoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .HasMaxLength(255);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(255);

                    b.HasKey("IdentityRoleId");

                    b.ToTable("IdentityRole<int>");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole<int>");
                });

            modelBuilder.Entity("Domain.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("IdentityRoleClaimId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("IdentityRoleId");

                    b.HasKey("IdentityRoleClaimId");

                    b.HasIndex("IdentityRoleId");

                    b.ToTable("IdentityRoleClaim<int>");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRoleClaim<int>");
                });

            modelBuilder.Entity("Domain.Identity.IdentityUser<int>", b =>
                {
                    b.Property<int>("IdentityUserId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .HasMaxLength(255);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(255);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(255);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(255);

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(255);

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(255);

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp")
                        .HasMaxLength(255);

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(255);

                    b.HasKey("IdentityUserId");

                    b.ToTable("IdentityUser<int>");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser<int>");
                });

            modelBuilder.Entity("Domain.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("IdentityUserClaimId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("IdentityUserId");

                    b.HasKey("IdentityUserClaimId");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("IdentityUserClaim<int>");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserClaim<int>");
                });

            modelBuilder.Entity("Domain.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<int>("IdentityUserLoginId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("IdentityUserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("ProviderKey");

                    b.HasKey("IdentityUserLoginId");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("IdentityUserLogin<int>");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserLogin<int>");
                });

            modelBuilder.Entity("Domain.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("IdentityUserRoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("IdentityRoleId");

                    b.Property<int>("IdentityUserId");

                    b.HasKey("IdentityUserRoleId");

                    b.HasIndex("IdentityRoleId");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("IdentityUserRole<int>");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<int>");
                });

            modelBuilder.Entity("Domain.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("IdentityUserTokenId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("IdentityUserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("IdentityUserTokenId");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("IdentityUserToken<int>");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserToken<int>");
                });

            modelBuilder.Entity("Domain.Identity.IdentityRole", b =>
                {
                    b.HasBaseType("Domain.Identity.IdentityRole<int>");


                    b.ToTable("IdentityRole");

                    b.HasDiscriminator().HasValue("IdentityRole");
                });

            modelBuilder.Entity("Domain.Identity.IdentityRoleClaim", b =>
                {
                    b.HasBaseType("Domain.Identity.IdentityRoleClaim<int>");


                    b.ToTable("IdentityRoleClaim");

                    b.HasDiscriminator().HasValue("IdentityRoleClaim");
                });

            modelBuilder.Entity("Domain.ApplicationUser", b =>
                {
                    b.HasBaseType("Domain.Identity.IdentityUser<int>");


                    b.ToTable("ApplicationUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Domain.Identity.IdentityUserClaim", b =>
                {
                    b.HasBaseType("Domain.Identity.IdentityUserClaim<int>");


                    b.ToTable("IdentityUserClaim");

                    b.HasDiscriminator().HasValue("IdentityUserClaim");
                });

            modelBuilder.Entity("Domain.Identity.IdentityUserLogin", b =>
                {
                    b.HasBaseType("Domain.Identity.IdentityUserLogin<int>");


                    b.ToTable("IdentityUserLogin");

                    b.HasDiscriminator().HasValue("IdentityUserLogin");
                });

            modelBuilder.Entity("Domain.Identity.IdentityUserRole", b =>
                {
                    b.HasBaseType("Domain.Identity.IdentityUserRole<int>");


                    b.ToTable("IdentityUserRole");

                    b.HasDiscriminator().HasValue("IdentityUserRole");
                });

            modelBuilder.Entity("Domain.Identity.IdentityUserToken", b =>
                {
                    b.HasBaseType("Domain.Identity.IdentityUserToken<int>");


                    b.ToTable("IdentityUserToken");

                    b.HasDiscriminator().HasValue("IdentityUserToken");
                });

            modelBuilder.Entity("Domain.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Domain.Identity.IdentityRole<int>", "IdentityRole")
                        .WithMany("IdentityRoleClaims")
                        .HasForeignKey("IdentityRoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Domain.Identity.IdentityUser<int>", "IdentityUser")
                        .WithMany("Claims")
                        .HasForeignKey("IdentityUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Domain.Identity.IdentityUser<int>", "IdentityUser")
                        .WithMany("Logins")
                        .HasForeignKey("IdentityUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Domain.Identity.IdentityRole<int>", "IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("IdentityRoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Identity.IdentityUser<int>", "IdentityUser")
                        .WithMany("Roles")
                        .HasForeignKey("IdentityUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Domain.Identity.IdentityUser<int>", "IdentityUser")
                        .WithMany("Tokens")
                        .HasForeignKey("IdentityUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
