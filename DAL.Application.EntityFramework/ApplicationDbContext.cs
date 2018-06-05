using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces;
using Domain;
using Domain.Identity;

namespace DAL.Application.EntityFramework
{
    public class ApplicationDbContext : DbContext, IDataContext
    {
        public DbSet<Domain.FooBar> FooBars { get; set; }
        public DbSet<Domain.Blah> Blahs { get; set; }

        public DbSet<Domain.Identity.IdentityRole> IdentityRoles { get; set; }
        public DbSet<IdentityRoleClaim> IdentityRoleClaims { get; set; }
        public DbSet<Domain.ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<IdentityUserClaim> IdentityUserClaims { get; set; }
        public DbSet<IdentityUserLogin> IdentityUserLogins { get; set; }
        public DbSet<Domain.Identity.IdentityUserRole> IdentityUserRoles { get; set; }
        public DbSet<IdentityUserToken> IdentityUserTokens { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole>()
                .HasIndex(p => new { p.IdentityUserId, p.IdentityRoleId}).IsUnique();
        }
    }
}
