using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Geeky.Swimteam.Migrations
{
    public partial class redoTryNumber3 : Migration
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
