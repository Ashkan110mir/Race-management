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
                    { "34065a31-7772-4893-bb6b-29ceb6ca9f33", null, "Admin", "ADMIN" },
                    { "3b5f2d43-4c91-4968-9219-aede3acc619a", null, "Player", "PLAYER" },
                    { "5185b815-b457-4eb1-befd-1ea691188c89", null, "Coach", "COACH" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LastName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerTeamTeamId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2e283abe-712d-4750-87af-34f25ccdaff5", 0, "1ce3c51c-b289-4525-9a05-e5c965c6934a", "ashkan110mir@gmail.com", true, "Mirdamadi", false, null, "Ashkan", "ASHKAN110MIR@GMAIL.COM", "ASHKANMIR", "AQAAAAIAAYagAAAAEDTyMJC6ECMTQqo3oz5UwuPYAbaXTRa+zcRM6Esy5onjO3P6ofaTt6t5pxm3oqNFVw==", "09908752252", true, null, "a6a25421-1efc-46d2-9aff-d8c3ba3c376b", false, "Ashkanmir" },
                    { "4da169fc-dd73-4595-8455-f56ac38f88ec", 0, "a611085a-dea1-4c5b-a231-f4ba9eda4ac4", "aliMohammadi@yahoo.com", true, "Mohammadi", false, null, "Ali", "ALIMOHAMMADI@YAHOO.COM", "ALIZM", "AQAAAAIAAYagAAAAEHUnnFh17bPpHc63BLWXLx98MBrCaoXAh321GhVuXLd5m9CfwuWW7PX2R92hoLHHkA==", "09139875623", true, null, "90cfa873-40da-4c51-a1e2-3604450b5ccb", false, "AliZM" },
                    { "66bc09b3-cbc3-4f72-a572-693be9fb8465", 0, "d8cf0b42-1375-4db2-afc1-000381f92d28", "Akbari@outlook.com", true, "Akbari", false, null, "Fatemeh", "AKBARI@OUTLOOK.COM", "FATEMEHAK", "AQAAAAIAAYagAAAAEF+GvxenKuY7tBfRTUSIyUALYhNeW67cuoSuilg9wIi8is7ctZsN4sUFt0+NHS4rAw==", "09137456723", true, null, "2c93d47d-306e-4fcf-9c70-6814b57670fc", false, "FatemehAk" },
                    { "72909342-5c2f-4667-b294-45265a2b64a7", 0, "7c872c74-9952-4bab-a320-02bac3de39e7", "Rahimi@yahoo.com", true, "Rahimi", false, null, "Amir", "RAHIMI@YAHOO.COM", "RAHIMIA", "AQAAAAIAAYagAAAAEAzB+Q03KVv8w3l2POyw7zdpmYz2VFB42Hj+lWZVyy8qU2gQHmgxVR1TC4RvKDXC0Q==", "09139874571", true, null, "d936f451-6112-4b4f-b3c2-48084a9efbb7", false, "RahimiA" },
                    { "b9cb3c98-ca92-4b85-821d-29fe445058cd", 0, "9e884686-65cf-43e7-9711-67f85d1f78f6", "AhmadiReza@outlook.com", true, "Ahmadi", false, null, "Reza", "AHMADIREZA@OUTLOOK.COM", "REZAAHMADI", "AQAAAAIAAYagAAAAENqefe0s9BbLIoSwCJThuXLMaw3hH07D5thEleKrmNuKQVvxabyuQs3kUxXY1+ZQ/A==", "09139958123", true, null, "e62ce10e-4893-4ad3-a0e6-5128c805753c", false, "RezaAhmadi" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "34065a31-7772-4893-bb6b-29ceb6ca9f33", "2e283abe-712d-4750-87af-34f25ccdaff5" },
                    { "5185b815-b457-4eb1-befd-1ea691188c89", "4da169fc-dd73-4595-8455-f56ac38f88ec" },
                    { "3b5f2d43-4c91-4968-9219-aede3acc619a", "66bc09b3-cbc3-4f72-a572-693be9fb8465" },
                    { "3b5f2d43-4c91-4968-9219-aede3acc619a", "72909342-5c2f-4667-b294-45265a2b64a7" },
                    { "5185b815-b457-4eb1-befd-1ea691188c89", "b9cb3c98-ca92-4b85-821d-29fe445058cd" }
                });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "ShowId", "AverageScore", "Isactive", "ShowDate", "ShowTitle", "ShowplayerId" },
                values: new object[,]
                {
                    { 1, -1, true, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "اجرا 1", "66bc09b3-cbc3-4f72-a572-693be9fb8465" },
                    { 2, -1, true, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "اجرا 2", "72909342-5c2f-4667-b294-45265a2b64a7" }
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
