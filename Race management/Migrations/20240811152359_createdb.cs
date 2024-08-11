using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Race_management.Migrations
{
    /// <inheritdoc />
    public partial class createdb : Migration
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
                    TeamID = table.Column<int>(type: "int", nullable: true),
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
                    ShowplayerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Isactive = table.Column<bool>(type: "bit", nullable: false)
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
                    { "1976493a-ba4e-4124-937a-e6ea3d7b3dc9", null, "Admin", "ADMIN" },
                    { "80f28635-805f-4b55-9152-fd5f254aef77", null, "Player", "PLAYER" },
                    { "eb31047f-de5b-452a-8ab6-cfd14dbb764e", null, "Coach", "COACH" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LastName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TeamID", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "33398e3f-0ec9-4ecb-9b89-329c598d6a1a", 0, "a6f26d62-1eec-44d2-9bd6-6426384b74a1", "AhmadiReza@outlook.com", true, "Ahmadi", false, null, "Reza", "AHMADIREZA@OUTLOOK.COM", "REZAAHMADI", "AQAAAAIAAYagAAAAEKkTtLA3COmprUT9xq0MwB2LCz+RrwapJF+AGDP9samCdcIvjqoYVG5xYOYvudA/yA==", "09139958123", true, "b3a3523e-d3d8-45a4-bda1-172be6fbd981", null, false, "RezaAhmadi" },
                    { "6ab41ce2-3ca3-4ed8-b934-f8021cb83192", 0, "17426546-656d-4a0f-8811-0aa8fa18762a", "ashkan110mir@gmail.com", true, "Mirdamadi", false, null, "Ashkan", "ASHKAN110MIR@GMAIL.COM", "ASHKANMIR", "AQAAAAIAAYagAAAAEGoyoSD1SkBdXZ0767n5UFce2M9eVy0fmndF2B5donKkZqIGsmeK7l+3syF8ZSL6tA==", "09908752252", true, "8dbae194-cbe3-42d1-8617-13436930d3ef", null, false, "Ashkanmir" },
                    { "bff2e72e-d9f3-4ffd-b8a4-37522ec82753", 0, "50e1156c-8f36-4903-b241-f4a930e5d509", "Akbari@outlook.com", true, "Akbari", false, null, "Fatemeh", "AKBARI@OUTLOOK.COM", "FATEMEHAK", "AQAAAAIAAYagAAAAELBypGliQfrTC+UbPE9cBs6tAsDsevaD3GxpFLs44RwJ4jgDVbd3j2VTsI0lwgKayw==", "09137456723", true, "8bb82703-7ff3-4e14-b9e2-e8759c4b4517", null, false, "FatemehAk" },
                    { "fcb244d1-8028-4881-a49b-4dd593fb3466", 0, "4de18573-f4f6-4fb1-8def-29fa28561590", "Rahimi@yahoo.com", true, "Rahimi", false, null, "Amir", "RAHIMI@YAHOO.COM", "RAHIMIA", "AQAAAAIAAYagAAAAEKmXyu0C/E0b04fUd1iSolvK5fNmof/LLtecvhSJMRH7miL8N3guEiTilUtVFIkBbw==", "09139874571", true, "1d6825db-a296-4890-bf48-61d45683d8ac", null, false, "RahimiA" },
                    { "fd33dd2a-2455-4bc0-be05-c18011fbac49", 0, "dcfd4c37-5e6d-4571-b1b7-3f1f42da2104", "aliMohammadi@yahoo.com", true, "Mohammadi", false, null, "Ali", "ALIMOHAMMADI@YAHOO.COM", "ALIZM", "AQAAAAIAAYagAAAAEC6A4ME3rhNiASsGvZ7NEAQpIRtMl4BFQxHXV3oe8Mq3AetfzJrQlvYtQ6g6oPfdgw==", "09139875623", true, "1ae6defd-5d03-471b-8032-635328f18ae5", null, false, "AliZM" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "eb31047f-de5b-452a-8ab6-cfd14dbb764e", "33398e3f-0ec9-4ecb-9b89-329c598d6a1a" },
                    { "1976493a-ba4e-4124-937a-e6ea3d7b3dc9", "6ab41ce2-3ca3-4ed8-b934-f8021cb83192" },
                    { "80f28635-805f-4b55-9152-fd5f254aef77", "bff2e72e-d9f3-4ffd-b8a4-37522ec82753" },
                    { "80f28635-805f-4b55-9152-fd5f254aef77", "fcb244d1-8028-4881-a49b-4dd593fb3466" },
                    { "eb31047f-de5b-452a-8ab6-cfd14dbb764e", "fd33dd2a-2455-4bc0-be05-c18011fbac49" }
                });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "ShowId", "AverageScore", "Isactive", "ShowDate", "ShowTitle", "ShowplayerId" },
                values: new object[,]
                {
                    { 1, -1, true, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "اجرا 1", "bff2e72e-d9f3-4ffd-b8a4-37522ec82753" },
                    { 2, -1, true, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "اجرا 2", "fcb244d1-8028-4881-a49b-4dd593fb3466" }
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
                name: "IX_AspNetUsers_TeamID",
                table: "AspNetUsers",
                column: "TeamID");

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
                name: "FK_AspNetUsers_Teams_TeamID",
                table: "AspNetUsers",
                column: "TeamID",
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
