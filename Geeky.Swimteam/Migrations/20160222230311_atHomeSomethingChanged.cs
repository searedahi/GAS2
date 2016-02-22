using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Geeky.Swimteam.Migrations
{
    public partial class atHomeSomethingChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_CoachesPractices_Practice_PracticeId", table: "CoachesPractices");
            migrationBuilder.DropForeignKey(name: "FK_SwimmersPractices_Practice_PracticeId", table: "SwimmersPractices");
            migrationBuilder.DropForeignKey(name: "FK_SwimteamCoaches_Swimteam_SwimteamId", table: "SwimteamCoaches");
            migrationBuilder.DropForeignKey(name: "FK_SwimteamSwimmers_Swimteam_SwimteamId", table: "SwimteamSwimmers");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_SwimteamRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_SwimteamUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_SwimteamUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_SwimteamRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_SwimteamUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.CreateTable(
                name: "PhoneNumber",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NumberType = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "PhysicalAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    RawStreetAddress = table.Column<string>(nullable: true),
                    RawStreetAddress2 = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Street2 = table.Column<string>(nullable: true),
                    StreetDirection = table.Column<string>(nullable: true),
                    StreetName = table.Column<string>(nullable: true),
                    StreetNumber = table.Column<string>(nullable: true),
                    StreetType = table.Column<string>(nullable: true),
                    SwimteamUserGuid = table.Column<Guid>(nullable: false),
                    SwimteamUserId = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Unit = table.Column<string>(nullable: true),
                    UnparsedAddress = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysicalAddress_SwimteamUser_SwimteamUserId",
                        column: x => x.SwimteamUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.AlterColumn<DateTime>(
                name: "Ends",
                table: "Practice",
                nullable: false);
            migrationBuilder.AlterColumn<DateTime>(
                name: "Begins",
                table: "Practice",
                nullable: false);
            migrationBuilder.AddForeignKey(
                name: "FK_CoachesPractices_Practice_PracticeId",
                table: "CoachesPractices",
                column: "PracticeId",
                principalTable: "Practice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_SwimmersPractices_Practice_PracticeId",
                table: "SwimmersPractices",
                column: "PracticeId",
                principalTable: "Practice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_SwimteamCoaches_Swimteam_SwimteamId",
                table: "SwimteamCoaches",
                column: "SwimteamId",
                principalTable: "Swimteam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_SwimteamSwimmers_Swimteam_SwimteamId",
                table: "SwimteamSwimmers",
                column: "SwimteamId",
                principalTable: "Swimteam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_SwimteamRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_SwimteamUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_SwimteamUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_SwimteamRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_SwimteamUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_CoachesPractices_Practice_PracticeId", table: "CoachesPractices");
            migrationBuilder.DropForeignKey(name: "FK_SwimmersPractices_Practice_PracticeId", table: "SwimmersPractices");
            migrationBuilder.DropForeignKey(name: "FK_SwimteamCoaches_Swimteam_SwimteamId", table: "SwimteamCoaches");
            migrationBuilder.DropForeignKey(name: "FK_SwimteamSwimmers_Swimteam_SwimteamId", table: "SwimteamSwimmers");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_SwimteamRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_SwimteamUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_SwimteamUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_SwimteamRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_SwimteamUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropTable("PhoneNumber");
            migrationBuilder.DropTable("PhysicalAddress");
            migrationBuilder.AlterColumn<string>(
                name: "Ends",
                table: "Practice",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "Begins",
                table: "Practice",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_CoachesPractices_Practice_PracticeId",
                table: "CoachesPractices",
                column: "PracticeId",
                principalTable: "Practice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_SwimmersPractices_Practice_PracticeId",
                table: "SwimmersPractices",
                column: "PracticeId",
                principalTable: "Practice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_SwimteamCoaches_Swimteam_SwimteamId",
                table: "SwimteamCoaches",
                column: "SwimteamId",
                principalTable: "Swimteam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_SwimteamSwimmers_Swimteam_SwimteamId",
                table: "SwimteamSwimmers",
                column: "SwimteamId",
                principalTable: "Swimteam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_SwimteamRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_SwimteamUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_SwimteamUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_SwimteamRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_SwimteamUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
