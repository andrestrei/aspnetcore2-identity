﻿// <auto-generated />
using DAL.Application.EFString;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace DAL.Application.EFString.Migrations
{
    [DbContext(typeof(ApplicationDbContextString))]
    [Migration("20180109204531_InitialStringBasedDatabase")]
    partial class InitialStringBasedDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
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

            modelBuilder.Entity("Domain.Identity.IdentityRole<string>", b =>
                {
                    b.Property<string>("IdentityRoleId")
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

                    b.ToTable("IdentityRole<string>");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole<string>");
                });

            modelBuilder.Entity("Domain.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<string>("IdentityRoleClaimId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("IdentityRoleId");

                    b.HasKey("IdentityRoleClaimId");

                    b.HasIndex("IdentityRoleId");

                    b.ToTable("IdentityRoleClaim<string>");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRoleClaim<string>");
                });

            modelBuilder.Entity("Domain.Identity.IdentityUser<string>", b =>
                {
                    b.Property<string>("IdentityUserId")
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

                    b.ToTable("IdentityUser<string>");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser<string>");
                });

            modelBuilder.Entity("Domain.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<string>("IdentityUserClaimId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("IdentityUserId");

                    b.HasKey("IdentityUserClaimId");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("IdentityUserClaim<string>");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserClaim<string>");
                });

            modelBuilder.Entity("Domain.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("IdentityUserLoginId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("IdentityUserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("ProviderKey");

                    b.HasKey("IdentityUserLoginId");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("IdentityUserLogin<string>");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserLogin<string>");
                });

            modelBuilder.Entity("Domain.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("IdentityUserRoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("IdentityRoleId");

                    b.Property<string>("IdentityUserId");

                    b.HasKey("IdentityUserRoleId");

                    b.HasIndex("IdentityRoleId");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("IdentityUserRole<string>");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<string>");
                });

            modelBuilder.Entity("Domain.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("IdentityUserTokenId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("IdentityUserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("IdentityUserTokenId");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("IdentityUserToken<string>");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserToken<string>");
                });

            modelBuilder.Entity("Domain.Identity.IdentityRoleStr", b =>
                {
                    b.HasBaseType("Domain.Identity.IdentityRole<string>");


                    b.ToTable("IdentityRoleStr");

                    b.HasDiscriminator().HasValue("IdentityRoleStr");
                });

            modelBuilder.Entity("Domain.Identity.IdentityRoleClaimStr", b =>
                {
                    b.HasBaseType("Domain.Identity.IdentityRoleClaim<string>");


                    b.ToTable("IdentityRoleClaimStr");

                    b.HasDiscriminator().HasValue("IdentityRoleClaimStr");
                });

            modelBuilder.Entity("Domain.Identity.IdentityUserStr", b =>
                {
                    b.HasBaseType("Domain.Identity.IdentityUser<string>");


                    b.ToTable("IdentityUserStr");

                    b.HasDiscriminator().HasValue("IdentityUserStr");
                });

            modelBuilder.Entity("Domain.Identity.IdentityUserClaimStr", b =>
                {
                    b.HasBaseType("Domain.Identity.IdentityUserClaim<string>");


                    b.ToTable("IdentityUserClaimStr");

                    b.HasDiscriminator().HasValue("IdentityUserClaimStr");
                });

            modelBuilder.Entity("Domain.Identity.IdentityUserLoginStr", b =>
                {
                    b.HasBaseType("Domain.Identity.IdentityUserLogin<string>");


                    b.ToTable("IdentityUserLoginStr");

                    b.HasDiscriminator().HasValue("IdentityUserLoginStr");
                });

            modelBuilder.Entity("Domain.Identity.IdentityUserRoleStr", b =>
                {
                    b.HasBaseType("Domain.Identity.IdentityUserRole<string>");


                    b.ToTable("IdentityUserRoleStr");

                    b.HasDiscriminator().HasValue("IdentityUserRoleStr");
                });

            modelBuilder.Entity("Domain.Identity.IdentityUserTokenStr", b =>
                {
                    b.HasBaseType("Domain.Identity.IdentityUserToken<string>");


                    b.ToTable("IdentityUserTokenStr");

                    b.HasDiscriminator().HasValue("IdentityUserTokenStr");
                });

            modelBuilder.Entity("Domain.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Domain.Identity.IdentityRole<string>", "IdentityRole")
                        .WithMany("IdentityRoleClaims")
                        .HasForeignKey("IdentityRoleId");
                });

            modelBuilder.Entity("Domain.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.Identity.IdentityUser<string>", "IdentityUser")
                        .WithMany("Claims")
                        .HasForeignKey("IdentityUserId");
                });

            modelBuilder.Entity("Domain.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.Identity.IdentityUser<string>", "IdentityUser")
                        .WithMany("Logins")
                        .HasForeignKey("IdentityUserId");
                });

            modelBuilder.Entity("Domain.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Domain.Identity.IdentityRole<string>", "IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("IdentityRoleId");

                    b.HasOne("Domain.Identity.IdentityUser<string>", "IdentityUser")
                        .WithMany("Roles")
                        .HasForeignKey("IdentityUserId");
                });

            modelBuilder.Entity("Domain.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.Identity.IdentityUser<string>", "IdentityUser")
                        .WithMany("Tokens")
                        .HasForeignKey("IdentityUserId");
                });
#pragma warning restore 612, 618
        }
    }
}