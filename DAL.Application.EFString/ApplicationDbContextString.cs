using DAL.Interfaces;
using Domain.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.Application.EFString
{
    public class ApplicationDbContextString : DbContext, IDataContext
    {
        public DbSet<Domain.FooBar> FooBars { get; set; }
        public DbSet<Domain.Blah> Blahs { get; set; }

        public DbSet<Domain.Identity.IdentityRoleStr> IdentityRoles { get; set; }
        public DbSet<IdentityRoleClaimStr> IdentityRoleClaims { get; set; }
        public DbSet<Domain.Identity.IdentityUserStr> ApplicationUsers { get; set; }
        public DbSet<IdentityUserClaimStr> IdentityUserClaims { get; set; }
        public DbSet<IdentityUserLoginStr> IdentityUserLogins { get; set; }
        public DbSet<Domain.Identity.IdentityUserRoleStr> IdentityUserRoles { get; set; }
        public DbSet<IdentityUserTokenStr> IdentityUserTokens { get; set; }

        public ApplicationDbContextString(DbContextOptions<ApplicationDbContextString> options) : base(options)
        {

        }
    }
}
