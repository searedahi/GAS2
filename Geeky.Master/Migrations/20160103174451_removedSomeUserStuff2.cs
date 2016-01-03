using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Geeky.Master.Migrations
{
    public partial class removedSomeUserStuff2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_GeekyUser_UserProfile_Id", table: "GeekyUser");
            migrationBuilder.DropForeignKey(name: "FK_PhoneNumber_UserProfile_UserProfileId", table: "PhoneNumber");
            migrationBuilder.DropForeignKey(name: "FK_PhysicalAddress_UserProfile_UserProfileId", table: "PhysicalAddress");
            //migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_GeekyRole_RoleId", table: "AspNetRoleClaims");
            //migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_GeekyUser_UserId", table: "AspNetUserClaims");
            //migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_GeekyUser_UserId", table: "AspNetUserLogins");
            //migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_GeekyRole_RoleId", table: "AspNetUserRoles");
            //migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_GeekyUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropColumn(name: "UserProfileId", table: "PhysicalAddress");
            migrationBuilder.DropColumn(name: "UserProfileId", table: "PhoneNumber");
            migrationBuilder.DropColumn(name: "DOB", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "DriversLicense", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "FirstName", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "HasCaregiver", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "IsSeniorCitizen", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "IsVeteran", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "LastName", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "MiddleName", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "Prefix", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "Suffix", table: "AspNetUsers");
            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_GeekyUser_Id",
                table: "UserProfile",
                column: "Id",
                principalTable: "GeekyUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_GeekyRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_GeekyUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_GeekyUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_GeekyRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_GeekyUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_UserProfile_GeekyUser_Id", table: "UserProfile");
            //migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_GeekyRole_RoleId", table: "AspNetRoleClaims");
            //migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_GeekyUser_UserId", table: "AspNetUserClaims");
            //migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_GeekyUser_UserId", table: "AspNetUserLogins");
            //migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_GeekyRole_RoleId", table: "AspNetUserRoles");
            //migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_GeekyUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.AddColumn<Guid>(
                name: "UserProfileId",
                table: "PhysicalAddress",
                nullable: true);
            migrationBuilder.AddColumn<Guid>(
                name: "UserProfileId",
                table: "PhoneNumber",
                nullable: true);
            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "AspNetUsers",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "DriversLicense",
                table: "AspNetUsers",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);
            migrationBuilder.AddColumn<bool>(
                name: "HasCaregiver",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<bool>(
                name: "IsSeniorCitizen",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<bool>(
                name: "IsVeteran",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "AspNetUsers",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "Prefix",
                table: "AspNetUsers",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "Suffix",
                table: "AspNetUsers",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_GeekyUser_UserProfile_Id",
                table: "GeekyUser",
                column: "Id",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumber_UserProfile_UserProfileId",
                table: "PhoneNumber",
                column: "UserProfileId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_PhysicalAddress_UserProfile_UserProfileId",
                table: "PhysicalAddress",
                column: "UserProfileId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_GeekyRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_GeekyUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_GeekyUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_GeekyRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_GeekyUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
