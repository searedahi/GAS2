using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Geeky.Master.Models;

namespace Geeky.Master.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20151231042000_geekyUserUpdates")]
    partial class geekyUserUpdates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Geeky.Master.Models.GeekyRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Geeky.Master.Models.GeekyUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime?>("DOB");

                    b.Property<string>("DriversLicense");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<bool>("HasCaregiver");

                    b.Property<bool>("IsSeniorCitizen");

                    b.Property<bool>("IsVeteran");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("MiddleName");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int?>("Prefix");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Suffix");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("Geeky.Models.Base.GeekyUser", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<Guid?>("ActiveCreditCardId");

                    b.Property<Guid?>("ApplicationUserId");

                    b.Property<string>("GoogleLookup");

                    b.Property<int>("Status");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Geeky.Models.Base.GImage", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Created");

                    b.Property<string>("DataUrl");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("Disabled");

                    b.Property<bool>("IsBadge");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name");

                    b.Property<string>("ThumbnailUrl");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Geeky.Models.Base.PhoneNumber", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GeekyUserId");

                    b.Property<string>("Name");

                    b.Property<int>("NumberType");

                    b.Property<Guid?>("UserProfileId");

                    b.Property<string>("Value");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Geeky.Models.Base.PhysicalAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("County");

                    b.Property<string>("GeekyUserId");

                    b.Property<string>("RawStreetAddress");

                    b.Property<string>("RawStreetAddress2");

                    b.Property<string>("State");

                    b.Property<string>("Street2");

                    b.Property<string>("StreetDirection");

                    b.Property<string>("StreetName");

                    b.Property<string>("StreetNumber");

                    b.Property<string>("StreetType");

                    b.Property<int>("Type");

                    b.Property<string>("Unit");

                    b.Property<string>("UnparsedAddress");

                    b.Property<Guid?>("UserProfileId");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Geeky.Models.Base.UserProfile", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DOB");

                    b.Property<string>("DriversLicense");

                    b.Property<Guid?>("DriversLicenseImageId");

                    b.Property<string>("FirstName");

                    b.Property<string>("FullName");

                    b.Property<string>("GeekyUserId");

                    b.Property<bool>("IsSeniorCitizen");

                    b.Property<bool>("IsValid");

                    b.Property<bool>("IsVeteran");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<int?>("Prefix");

                    b.Property<Guid?>("ProfileImageId");

                    b.Property<string>("Suffix");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("Geeky.Models.Base.GeekyUser", b =>
                {
                    b.HasOne("Geeky.Models.Base.UserProfile")
                        .WithOne()
                        .HasForeignKey("Geeky.Models.Base.GeekyUser", "Id");
                });

            modelBuilder.Entity("Geeky.Models.Base.PhoneNumber", b =>
                {
                    b.HasOne("Geeky.Master.Models.GeekyUser")
                        .WithMany()
                        .HasForeignKey("GeekyUserId");

                    b.HasOne("Geeky.Models.Base.UserProfile")
                        .WithMany()
                        .HasForeignKey("UserProfileId");
                });

            modelBuilder.Entity("Geeky.Models.Base.PhysicalAddress", b =>
                {
                    b.HasOne("Geeky.Master.Models.GeekyUser")
                        .WithMany()
                        .HasForeignKey("GeekyUserId");

                    b.HasOne("Geeky.Models.Base.UserProfile")
                        .WithMany()
                        .HasForeignKey("UserProfileId");
                });

            modelBuilder.Entity("Geeky.Models.Base.UserProfile", b =>
                {
                    b.HasOne("Geeky.Models.Base.GImage")
                        .WithMany()
                        .HasForeignKey("DriversLicenseImageId");

                    b.HasOne("Geeky.Master.Models.GeekyUser")
                        .WithMany()
                        .HasForeignKey("GeekyUserId");

                    b.HasOne("Geeky.Models.Base.GImage")
                        .WithMany()
                        .HasForeignKey("ProfileImageId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Geeky.Master.Models.GeekyRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Geeky.Master.Models.GeekyUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Geeky.Master.Models.GeekyUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Geeky.Master.Models.GeekyRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("Geeky.Master.Models.GeekyUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
