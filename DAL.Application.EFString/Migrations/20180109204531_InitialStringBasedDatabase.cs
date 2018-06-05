using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DAL.Application.EFString.Migrations
{
    public partial class InitialStringBasedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blahs",
                columns: table => new
                {
                    BlahId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlahValue = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blahs", x => x.BlahId);
                });

            migrationBuilder.CreateTable(
                name: "FooBars",
                columns: table => new
                {
                    FooBarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FooBarValue = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooBars", x => x.FooBarId);
                });

            migrationBuilder.CreateTable(
                name: "IdentityRole<string>",
                columns: table => new
                {
                    IdentityRoleId = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(maxLength: 255, nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole<string>", x => x.IdentityRoleId);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUser<string>",
                columns: table => new
                {
                    IdentityUserId = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(maxLength: 255, nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 255, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 255, nullable: true),
                    PasswordHash = table.Column<string>(maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 255, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(maxLength: 255, nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser<string>", x => x.IdentityUserId);
                });

            migrationBuilder.CreateTable(
                name: "IdentityRoleClaim<string>",
                columns: table => new
                {
                    IdentityRoleClaimId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    IdentityRoleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRoleClaim<string>", x => x.IdentityRoleClaimId);
                    table.ForeignKey(
                        name: "FK_IdentityRoleClaim<string>_IdentityRole<string>_IdentityRoleId",
                        column: x => x.IdentityRoleId,
                        principalTable: "IdentityRole<string>",
                        principalColumn: "IdentityRoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserClaim<string>",
                columns: table => new
                {
                    IdentityUserClaimId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserClaim<string>", x => x.IdentityUserClaimId);
                    table.ForeignKey(
                        name: "FK_IdentityUserClaim<string>_IdentityUser<string>_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "IdentityUser<string>",
                        principalColumn: "IdentityUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserLogin<string>",
                columns: table => new
                {
                    IdentityUserLoginId = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: true),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserLogin<string>", x => x.IdentityUserLoginId);
                    table.ForeignKey(
                        name: "FK_IdentityUserLogin<string>_IdentityUser<string>_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "IdentityUser<string>",
                        principalColumn: "IdentityUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserRole<string>",
                columns: table => new
                {
                    IdentityUserRoleId = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    IdentityRoleId = table.Column<string>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole<string>", x => x.IdentityUserRoleId);
                    table.ForeignKey(
                        name: "FK_IdentityUserRole<string>_IdentityRole<string>_IdentityRoleId",
                        column: x => x.IdentityRoleId,
                        principalTable: "IdentityRole<string>",
                        principalColumn: "IdentityRoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IdentityUserRole<string>_IdentityUser<string>_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "IdentityUser<string>",
                        principalColumn: "IdentityUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserToken<string>",
                columns: table => new
                {
                    IdentityUserTokenId = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: true),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserToken<string>", x => x.IdentityUserTokenId);
                    table.ForeignKey(
                        name: "FK_IdentityUserToken<string>_IdentityUser<string>_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "IdentityUser<string>",
                        principalColumn: "IdentityUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdentityRoleClaim<string>_IdentityRoleId",
                table: "IdentityRoleClaim<string>",
                column: "IdentityRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserClaim<string>_IdentityUserId",
                table: "IdentityUserClaim<string>",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserLogin<string>_IdentityUserId",
                table: "IdentityUserLogin<string>",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserRole<string>_IdentityRoleId",
                table: "IdentityUserRole<string>",
                column: "IdentityRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserRole<string>_IdentityUserId",
                table: "IdentityUserRole<string>",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserToken<string>_IdentityUserId",
                table: "IdentityUserToken<string>",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blahs");

            migrationBuilder.DropTable(
                name: "FooBars");

            migrationBuilder.DropTable(
                name: "IdentityRoleClaim<string>");

            migrationBuilder.DropTable(
                name: "IdentityUserClaim<string>");

            migrationBuilder.DropTable(
                name: "IdentityUserLogin<string>");

            migrationBuilder.DropTable(
                name: "IdentityUserRole<string>");

            migrationBuilder.DropTable(
                name: "IdentityUserToken<string>");

            migrationBuilder.DropTable(
                name: "IdentityRole<string>");

            migrationBuilder.DropTable(
                name: "IdentityUser<string>");
        }
    }
}
