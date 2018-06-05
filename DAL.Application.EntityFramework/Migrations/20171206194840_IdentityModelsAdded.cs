using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DAL.Application.EntityFramework.Migrations
{
    public partial class IdentityModelsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentityRole<int>",
                columns: table => new
                {
                    IdentityRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole<int>", x => x.IdentityRoleId);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUser<int>",
                columns: table => new
                {
                    IdentityUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser<int>", x => x.IdentityUserId);
                });

            migrationBuilder.CreateTable(
                name: "IdentityRoleClaim<int>",
                columns: table => new
                {
                    IdentityRoleClaimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRoleClaim<int>", x => x.IdentityRoleClaimId);
                    table.ForeignKey(
                        name: "FK_IdentityRoleClaim<int>_IdentityRole<int>_IdentityRoleId",
                        column: x => x.IdentityRoleId,
                        principalTable: "IdentityRole<int>",
                        principalColumn: "IdentityRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserClaim<int>",
                columns: table => new
                {
                    IdentityUserClaimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserClaim<int>", x => x.IdentityUserClaimId);
                    table.ForeignKey(
                        name: "FK_IdentityUserClaim<int>_IdentityUser<int>_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "IdentityUser<int>",
                        principalColumn: "IdentityUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserLogin<int>",
                columns: table => new
                {
                    IdentityUserLoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityUserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserLogin<int>", x => x.IdentityUserLoginId);
                    table.ForeignKey(
                        name: "FK_IdentityUserLogin<int>_IdentityUser<int>_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "IdentityUser<int>",
                        principalColumn: "IdentityUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserRole<int>",
                columns: table => new
                {
                    IdentityUserRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityRoleId = table.Column<int>(type: "int", nullable: false),
                    IdentityUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole<int>", x => x.IdentityUserRoleId);
                    table.ForeignKey(
                        name: "FK_IdentityUserRole<int>_IdentityRole<int>_IdentityRoleId",
                        column: x => x.IdentityRoleId,
                        principalTable: "IdentityRole<int>",
                        principalColumn: "IdentityRoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityUserRole<int>_IdentityUser<int>_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "IdentityUser<int>",
                        principalColumn: "IdentityUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserToken<int>",
                columns: table => new
                {
                    IdentityUserTokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityUserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserToken<int>", x => x.IdentityUserTokenId);
                    table.ForeignKey(
                        name: "FK_IdentityUserToken<int>_IdentityUser<int>_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "IdentityUser<int>",
                        principalColumn: "IdentityUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdentityRoleClaim<int>_IdentityRoleId",
                table: "IdentityRoleClaim<int>",
                column: "IdentityRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserClaim<int>_IdentityUserId",
                table: "IdentityUserClaim<int>",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserLogin<int>_IdentityUserId",
                table: "IdentityUserLogin<int>",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserRole<int>_IdentityRoleId",
                table: "IdentityUserRole<int>",
                column: "IdentityRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserRole<int>_IdentityUserId",
                table: "IdentityUserRole<int>",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserToken<int>_IdentityUserId",
                table: "IdentityUserToken<int>",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityRoleClaim<int>");

            migrationBuilder.DropTable(
                name: "IdentityUserClaim<int>");

            migrationBuilder.DropTable(
                name: "IdentityUserLogin<int>");

            migrationBuilder.DropTable(
                name: "IdentityUserRole<int>");

            migrationBuilder.DropTable(
                name: "IdentityUserToken<int>");

            migrationBuilder.DropTable(
                name: "IdentityRole<int>");

            migrationBuilder.DropTable(
                name: "IdentityUser<int>");
        }
    }
}
