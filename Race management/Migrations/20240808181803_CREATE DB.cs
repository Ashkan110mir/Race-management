using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Race_management.Migrations
{
    /// <inheritdoc />
    public partial class CREATEDB : Migration
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
                    { "14d4435e-96ac-4e25-9a4a-97656e9d0c96", null, "Coach", "COACH" },
                    { "6805597b-6688-4c7f-98d1-46ef376a1500", null, "Player", "PLAYER" },
                    { "aa366280-f7a2-417f-bfa2-c19c2f054bff", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LastName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerTeamTeamId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2dc3e4e8-5b7e-446e-909e-dbcb6f6e35b7", 0, "79e79c83-9b86-4362-9545-cd6e6d784a3d", "aliMohammadi@yahoo.com", true, "Mohammadi", false, null, "Ali", "ALIMOHAMMADI@YAHOO.COM", "ALIZM", "AQAAAAIAAYagAAAAEBCkcNp0M7HnXB4HjDQxv7vAFK4Iu3WEpltKgWUBHPudcitv0sGpx3wPyyal03MeSg==", "09139875623", true, null, "f6b2fb98-bf7e-41d7-bddd-268e8f44fddf", false, "AliZM" },
                    { "b9923e70-ef65-48de-a15b-9c62db600c31", 0, "3a4556a4-3dfa-4cdb-960b-d9c7ea412725", "AhmadiReza@outlook.com", true, "Ahmadi", false, null, "Reza", "AHMADIREZA@OUTLOOK.COM", "REZAAHMADI", "AQAAAAIAAYagAAAAEODJ3bdlMuwCkUfoXTw8sAmB+UKdu9m0fjRFYz4IqyhsWG8I2SJOqrirTWI1idsIJg==", "09139958123", true, null, "87fb9dfe-14be-4bd8-970e-d179252a462b", false, "RezaAhmadi" },
                    { "ea5a2610-86f1-4776-be5f-8bb96d8f74b7", 0, "d15deb8c-0e61-4f3c-a8f5-282d1fe45580", "Rahimi@yahoo.com", true, "Rahimi", false, null, "Amir", "RAHIMI@YAHOO.COM", "RAHIMIA", "AQAAAAIAAYagAAAAEFeQZETXXfexAeLGNMRmlZi87KF0ZgwrX0yRqq9Poj3VgJT2xRkwPvrUyAieU9NAjA==", "09139874571", true, null, "c3f8280e-9674-4046-b606-1ee892d8c7c9", false, "RahimiA" },
                    { "f6e4a437-5d44-410e-8471-3e35112faa58", 0, "0cc9eb85-f56d-4640-bcbb-08d9e8b1f1ef", "ashkan110mir@gmail.com", true, "Mirdamadi", false, null, "Ashkan", "ASHKAN110MIR@GMAIL.COM", "ASHKANMIR", "AQAAAAIAAYagAAAAEE60dtlpHXeP9rkP8OKur8MD0MXh9FaNEFGdA8Yvkc0CvcMWUagcV8KwgMmkftxsCw==", "09908752252", true, null, "791502dc-04c4-4639-8441-ce039ebba0c3", false, "Ashkanmir" },
                    { "fef1d6fa-147a-4842-a95d-68efdeafef25", 0, "d6b257e4-46cb-4557-9122-c337fb17ef5b", "Akbari@outlook.com", true, "Akbari", false, null, "Fatemeh", "AKBARI@OUTLOOK.COM", "FATEMEHAK", "AQAAAAIAAYagAAAAEAqRajVBEnyqduKfSoEcqvaxdPyqjJX7sQEMKwBKnxtspx+c2Xok2YQG2/O8/W6+Og==", "09137456723", true, null, "3b60b7d1-5e55-4bc8-9504-213dec653c6f", false, "FatemehAk" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "14d4435e-96ac-4e25-9a4a-97656e9d0c96", "2dc3e4e8-5b7e-446e-909e-dbcb6f6e35b7" },
                    { "14d4435e-96ac-4e25-9a4a-97656e9d0c96", "b9923e70-ef65-48de-a15b-9c62db600c31" },
                    { "6805597b-6688-4c7f-98d1-46ef376a1500", "ea5a2610-86f1-4776-be5f-8bb96d8f74b7" },
                    { "aa366280-f7a2-417f-bfa2-c19c2f054bff", "f6e4a437-5d44-410e-8471-3e35112faa58" },
                    { "6805597b-6688-4c7f-98d1-46ef376a1500", "fef1d6fa-147a-4842-a95d-68efdeafef25" }
                });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "ShowId", "AverageScore", "Isactive", "ShowDate", "ShowTitle", "ShowplayerId" },
                values: new object[,]
                {
                    { 1, -1, true, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "اجرا 1", "fef1d6fa-147a-4842-a95d-68efdeafef25" },
                    { 2, -1, true, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "اجرا 2", "ea5a2610-86f1-4776-be5f-8bb96d8f74b7" }
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
