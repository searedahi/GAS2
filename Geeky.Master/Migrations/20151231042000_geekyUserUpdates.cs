using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Geeky.Master.Migrations
{
    public partial class geekyUserUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            //migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_GeekyUser_UserId", table: "AspNetUserClaims");
            //migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_GeekyUser_UserId", table: "AspNetUserLogins");
            //migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            //migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_GeekyUser_UserId", table: "AspNetUserRoles");
            //migrationBuilder.DropPrimaryKey(name: "PK_IdentityRole", table: "AspNetRoles");
            migrationBuilder.CreateTable(
                name: "GImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    DataUrl = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Disabled = table.Column<DateTime>(nullable: true),
                    IsBadge = table.Column<bool>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ThumbnailUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GImage", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: true),
                    DriversLicense = table.Column<string>(nullable: true),
                    DriversLicenseImageId = table.Column<Guid>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    GeekyUserId = table.Column<string>(nullable: true),
                    IsSeniorCitizen = table.Column<bool>(nullable: false),
                    IsValid = table.Column<bool>(nullable: false),
                    IsVeteran = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    Prefix = table.Column<int>(nullable: true),
                    ProfileImageId = table.Column<Guid>(nullable: true),
                    Suffix = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfile_GImage_DriversLicenseImageId",
                        column: x => x.DriversLicenseImageId,
                        principalTable: "GImage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfile_GeekyUser_GeekyUserId",
                        column: x => x.GeekyUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfile_GImage_ProfileImageId",
                        column: x => x.ProfileImageId,
                        principalTable: "GImage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "GeekyUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ActiveCreditCardId = table.Column<Guid>(nullable: true),
                    ApplicationUserId = table.Column<Guid>(nullable: true),
                    GoogleLookup = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeekyUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeekyUser_UserProfile_Id",
                        column: x => x.Id,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "PhoneNumber",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GeekyUserId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NumberType = table.Column<int>(nullable: false),
                    UserProfileId = table.Column<Guid>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumber_GeekyUser_GeekyUserId",
                        column: x => x.GeekyUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhoneNumber_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "PhysicalAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    GeekyUserId = table.Column<string>(nullable: true),
                    RawStreetAddress = table.Column<string>(nullable: true),
                    RawStreetAddress2 = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Street2 = table.Column<string>(nullable: true),
                    StreetDirection = table.Column<string>(nullable: true),
                    StreetName = table.Column<string>(nullable: true),
                    StreetNumber = table.Column<string>(nullable: true),
                    StreetType = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Unit = table.Column<string>(nullable: true),
                    UnparsedAddress = table.Column<string>(nullable: true),
                    UserProfileId = table.Column<Guid>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysicalAddress_GeekyUser_GeekyUserId",
                        column: x => x.GeekyUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhysicalAddress_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserLogins",
                nullable: false);
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserClaims",
                nullable: false);
            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                nullable: false);
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
            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_GeekyRole",
            //    table: "AspNetRoles",
            //    column: "Id");
            //migrationBuilder.AddForeignKey(
            //    name: "FK_IdentityRoleClaim<string>_GeekyRole_RoleId",
            //    table: "AspNetRoleClaims",
            //    column: "RoleId",
            //    principalTable: "AspNetRoles",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
            //migrationBuilder.AddForeignKey(
            //    name: "FK_IdentityUserClaim<string>_GeekyUser_UserId",
            //    table: "AspNetUserClaims",
            //    column: "UserId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
            //migrationBuilder.AddForeignKey(
            //    name: "FK_IdentityUserLogin<string>_GeekyUser_UserId",
            //    table: "AspNetUserLogins",
            //    column: "UserId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
            //migrationBuilder.AddForeignKey(
            //    name: "FK_IdentityUserRole<string>_GeekyRole_RoleId",
            //    table: "AspNetUserRoles",
            //    column: "RoleId",
            //    principalTable: "AspNetRoles",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
            //migrationBuilder.AddForeignKey(
            //    name: "FK_IdentityUserRole<string>_GeekyUser_UserId",
            //    table: "AspNetUserRoles",
            //    column: "UserId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_GeekyRole_RoleId", table: "AspNetRoleClaims");
            //migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_GeekyUser_UserId", table: "AspNetUserClaims");
            //migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_GeekyUser_UserId", table: "AspNetUserLogins");
            //migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_GeekyRole_RoleId", table: "AspNetUserRoles");
            //migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_GeekyUser_UserId", table: "AspNetUserRoles");
            //migrationBuilder.DropPrimaryKey(name: "PK_GeekyRole", table: "AspNetRoles");
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
            migrationBuilder.DropTable("GeekyUser");
            migrationBuilder.DropTable("PhoneNumber");
            migrationBuilder.DropTable("PhysicalAddress");
            migrationBuilder.DropTable("UserProfile");
            migrationBuilder.DropTable("GImage");
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserLogins",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserClaims",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                nullable: true);
            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_IdentityRole",
            //    table: "AspNetRoles",
            //    column: "Id");
            //migrationBuilder.AddForeignKey(
            //    name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
            //    table: "AspNetRoleClaims",
            //    column: "RoleId",
            //    principalTable: "AspNetRoles",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
            //migrationBuilder.AddForeignKey(
            //    name: "FK_IdentityUserClaim<string>_GeekyUser_UserId",
            //    table: "AspNetUserClaims",
            //    column: "UserId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
            //migrationBuilder.AddForeignKey(
            //    name: "FK_IdentityUserLogin<string>_GeekyUser_UserId",
            //    table: "AspNetUserLogins",
            //    column: "UserId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
            //migrationBuilder.AddForeignKey(
            //    name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
            //    table: "AspNetUserRoles",
            //    column: "RoleId",
            //    principalTable: "AspNetRoles",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
            //migrationBuilder.AddForeignKey(
            //    name: "FK_IdentityUserRole<string>_GeekyUser_UserId",
            //    table: "AspNetUserRoles",
            //    column: "UserId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
