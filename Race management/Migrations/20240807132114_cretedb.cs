using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Race_management.Migrations
{
    /// <inheritdoc />
    public partial class cretedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerTeamTeamId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    ShowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AverageScore = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    ShowplayerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.ShowId);
                    table.ForeignKey(
                        name: "FK_Shows_AspNetUsers_ShowplayerId",
                        column: x => x.ShowplayerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CoachId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Teams_AspNetUsers_CoachId",
                        column: x => x.CoachId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShowToCoache",
                columns: table => new
                {
                    Coachid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShowId = table.Column<int>(type: "int", nullable: false),
                    score = table.Column<int>(type: "int", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowToCoache", x => new { x.ShowId, x.Coachid });
                    table.ForeignKey(
                        name: "FK_ShowToCoache_AspNetUsers_Coachid",
                        column: x => x.Coachid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShowToCoache_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "ShowId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a75a24b-3e07-4fac-8c06-b59a0a32b545", null, "Admin", "ADMIN" },
                    { "3d5693b4-e050-4e1b-8924-12df2aaf662b", null, "Player", "PLAYER" },
                    { "b2c90319-f7a6-479e-96ab-beff294e82f0", null, "Coach", "COACH" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LastName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerTeamTeamId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0fe23c0f-5f62-4cc0-9133-c6adcab2b771", 0, "b11b4da4-309c-401c-8a2e-2ee5915b82d2", "Akbari@outlook.com", true, "Akbari", false, null, "Fatemeh", "AKBARI@OUTLOOK.COM", "FATEMEHAK", "AQAAAAIAAYagAAAAECsaNbT1HeL9eeyh8hsyuVP8kMzu66JhBiXofbHRI5MyEcscDKfdouWk8ST3KocQSg==", "09137456723", true, null, "0e522f48-29cb-4e20-9a8e-56b95e07cf2f", false, "FatemehAk" },
                    { "13b30c74-c408-41cf-bae2-876aad3644e5", 0, "26c3b9b6-91b3-4d03-9847-bf3162d3fc1c", "aliMohammadi@yahoo.com", true, "Mohammadi", false, null, "Ali", "ALIMOHAMMADI@YAHOO.COM", "ALIZM", "AQAAAAIAAYagAAAAEMJV4R3gMveMWcVR4GODxbGlQwQQVikUtSLBTUuHezFJRgEmMl/RDM0fqM8mf0Q2Iw==", "09139875623", true, null, "21209ad3-5458-4c96-8903-732e483cfa03", false, "AliZM" },
                    { "83b4db9d-215b-4346-a144-bef69f19030b", 0, "08149fc9-bba9-4218-b1dd-1e09a227ebbc", "AhmadiReza@outlook.com", true, "Ahmadi", false, null, "Reza", "AHMADIREZA@OUTLOOK.COM", "REZAAHMADI", "AQAAAAIAAYagAAAAEEwNjlOaYEI1ncER55sHp9DyC3Vx0fmhoMl56ycsyYr57TToefeKwnsx6RQyEZp42g==", "09139958123", true, null, "13d26cf8-4625-456f-b964-d7db3d98190f", false, "RezaAhmadi" },
                    { "98f125a4-8c3c-4bd8-bd28-d56134fe40c2", 0, "c7cda33b-6b63-42e1-90fd-9790b17b6038", "Rahimi@yahoo.com", true, "Rahimi", false, null, "Amir", "RAHIMI@YAHOO.COM", "RAHIMIA", "AQAAAAIAAYagAAAAEOtT53C+KbSUhyoSJu/i0/z9ey9gQBae23C+2Vck893VbYZngKlYE/u4lvL4Vpvh4A==", "09139874571", true, null, "6f318ea6-d2ca-4e97-81a9-60a3f4cc7ae5", false, "RahimiA" },
                    { "bf4bac23-04ea-4d0c-8ca6-f15473ff4351", 0, "999aa8e9-49b8-46de-959c-374b8d935e85", "ashkan110mir@gmail.com", true, "Mirdamadi", false, null, "Ashkan", "ASHKAN110MIR@GMAIL.COM", "ASHKANMIR", "AQAAAAIAAYagAAAAEKHU4CNXLZSUGaXGScV3AtyKJ62V3u8RcdsEq0XifQ5JHwM7MudmytVl6aOae6ftFA==", "09908752252", true, null, "cbf4d775-e5b1-49b1-9f6a-0724722de4ed", false, "Ashkanmir" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "3d5693b4-e050-4e1b-8924-12df2aaf662b", "0fe23c0f-5f62-4cc0-9133-c6adcab2b771" },
                    { "b2c90319-f7a6-479e-96ab-beff294e82f0", "13b30c74-c408-41cf-bae2-876aad3644e5" },
                    { "b2c90319-f7a6-479e-96ab-beff294e82f0", "83b4db9d-215b-4346-a144-bef69f19030b" },
                    { "3d5693b4-e050-4e1b-8924-12df2aaf662b", "98f125a4-8c3c-4bd8-bd28-d56134fe40c2" },
                    { "3a75a24b-3e07-4fac-8c06-b59a0a32b545", "bf4bac23-04ea-4d0c-8ca6-f15473ff4351" }
                });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "ShowId", "AverageScore", "ShowDate", "ShowTitle", "ShowplayerId" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "اجرا 1", "0fe23c0f-5f62-4cc0-9133-c6adcab2b771" },
                    { 2, 0, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "اجرا 2", "98f125a4-8c3c-4bd8-bd28-d56134fe40c2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PlayerTeamTeamId",
                table: "AspNetUsers",
                column: "PlayerTeamTeamId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_ShowplayerId",
                table: "Shows",
                column: "ShowplayerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowToCoache_Coachid",
                table: "ShowToCoache",
                column: "Coachid");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CoachId",
                table: "Teams",
                column: "CoachId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Teams_PlayerTeamTeamId",
                table: "AspNetUsers",
                column: "PlayerTeamTeamId",
                principalTable: "Teams",
                principalColumn: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_AspNetUsers_CoachId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ShowToCoache");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
