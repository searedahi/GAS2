using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Geeky.Swimteam.Contexts;

namespace Geeky.Swimteam.Migrations
{
    [DbContext(typeof(SwimteamDbContext))]
    [Migration("20160222230311_atHomeSomethingChanged")]
    partial class atHomeSomethingChanged
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Geeky.Swimteam.Models.GImage", b =>
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

            modelBuilder.Entity("Geeky.Swimteam.Models.Mappings.CoachesPractices", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CoachId");

                    b.Property<string>("CoachId1");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<Guid>("PracticeId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Geeky.Swimteam.Models.Mappings.CoachesSwimmers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CoachId");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("SwimmerId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Geeky.Swimteam.Models.Mappings.SwimmersPractices", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<Guid>("PracticeId");

                    b.Property<Guid>("SwimmerId");

                    b.Property<string>("SwimmerId1");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Geeky.Swimteam.Models.Mappings.SwimteamCoaches", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CoachId");

                    b.Property<string>("CoachId1");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<Guid>("SwimteamId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Geeky.Swimteam.Models.Mappings.SwimteamSwimmers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<Guid>("SwimmerId");

                    b.Property<string>("SwimmerId1");

                    b.Property<Guid>("SwimteamId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Geeky.Swimteam.Models.PhoneNumber", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("NumberType");

                    b.Property<string>("Value");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Geeky.Swimteam.Models.PhysicalAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("County");

                    b.Property<string>("RawStreetAddress");

                    b.Property<string>("RawStreetAddress2");

                    b.Property<string>("State");

                    b.Property<string>("Street2");

                    b.Property<string>("StreetDirection");

                    b.Property<string>("StreetName");

                    b.Property<string>("StreetNumber");

                    b.Property<string>("StreetType");

                    b.Property<Guid>("SwimteamUserGuid");

                    b.Property<string>("SwimteamUserId");

                    b.Property<int>("Type");

                    b.Property<string>("Unit");

                    b.Property<string>("UnparsedAddress");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Geeky.Swimteam.Models.Practice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Begins");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Description");

                    b.Property<DateTime>("Ends");

                    b.Property<int>("MaxParticipants");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Geeky.Swimteam.Models.Swimteam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Geeky.Swimteam.Models.SwimteamRole", b =>
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

            modelBuilder.Entity("Geeky.Swimteam.Models.SwimteamUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:DiscriminatorProperty", "Discriminator");

                    b.HasAnnotation("Relational:DiscriminatorValue", "SwimteamUser");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("Geeky.Swimteam.Models.UserProfile", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BaseUserId");

                    b.Property<DateTime?>("DOB");

                    b.Property<string>("DriversLicense");

                    b.Property<Guid?>("DriversLicenseImageId");

                    b.Property<string>("FirstName");

                    b.Property<string>("FullName");

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

            modelBuilder.Entity("Geeky.Swimteam.Models.Coach", b =>
                {
                    b.HasBaseType("Geeky.Swimteam.Models.SwimteamUser");

                    b.Property<Guid?>("TeamId");

                    b.HasAnnotation("Relational:DiscriminatorValue", "Coach");
                });

            modelBuilder.Entity("Geeky.Swimteam.Models.Swimmer", b =>
                {
                    b.HasBaseType("Geeky.Swimteam.Models.SwimteamUser");


                    b.HasAnnotation("Relational:DiscriminatorValue", "Swimmer");
                });

            modelBuilder.Entity("Geeky.Swimteam.Models.Mappings.CoachesPractices", b =>
                {
                    b.HasOne("Geeky.Swimteam.Models.Coach")
                        .WithMany()
                        .HasForeignKey("CoachId1");

                    b.HasOne("Geeky.Swimteam.Models.Practice")
                        .WithMany()
                        .HasForeignKey("PracticeId");
                });

            modelBuilder.Entity("Geeky.Swimteam.Models.Mappings.CoachesSwimmers", b =>
                {
                    b.HasOne("Geeky.Swimteam.Models.Coach")
                        .WithMany()
                        .HasForeignKey("CoachId");

                    b.HasOne("Geeky.Swimteam.Models.Swimmer")
                        .WithMany()
                        .HasForeignKey("SwimmerId");
                });

            modelBuilder.Entity("Geeky.Swimteam.Models.Mappings.SwimmersPractices", b =>
                {
                    b.HasOne("Geeky.Swimteam.Models.Practice")
                        .WithMany()
                        .HasForeignKey("PracticeId");

                    b.HasOne("Geeky.Swimteam.Models.Swimmer")
                        .WithMany()
                        .HasForeignKey("SwimmerId1");
                });

            modelBuilder.Entity("Geeky.Swimteam.Models.Mappings.SwimteamCoaches", b =>
                {
                    b.HasOne("Geeky.Swimteam.Models.Coach")
                        .WithMany()
                        .HasForeignKey("CoachId1");

                    b.HasOne("Geeky.Swimteam.Models.Swimteam")
                        .WithMany()
                        .HasForeignKey("SwimteamId");
                });

            modelBuilder.Entity("Geeky.Swimteam.Models.Mappings.SwimteamSwimmers", b =>
                {
                    b.HasOne("Geeky.Swimteam.Models.Swimmer")
                        .WithMany()
                        .HasForeignKey("SwimmerId1");

                    b.HasOne("Geeky.Swimteam.Models.Swimteam")
                        .WithMany()
                        .HasForeignKey("SwimteamId");
                });

            modelBuilder.Entity("Geeky.Swimteam.Models.PhysicalAddress", b =>
                {
                    b.HasOne("Geeky.Swimteam.Models.SwimteamUser")
                        .WithMany()
                        .HasForeignKey("SwimteamUserId");
                });

            modelBuilder.Entity("Geeky.Swimteam.Models.UserProfile", b =>
                {
                    b.HasOne("Geeky.Swimteam.Models.SwimteamUser")
                        .WithMany()
                        .HasForeignKey("BaseUserId");

                    b.HasOne("Geeky.Swimteam.Models.GImage")
                        .WithMany()
                        .HasForeignKey("DriversLicenseImageId");

                    b.HasOne("Geeky.Swimteam.Models.GImage")
                        .WithMany()
                        .HasForeignKey("ProfileImageId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Geeky.Swimteam.Models.SwimteamRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Geeky.Swimteam.Models.SwimteamUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Geeky.Swimteam.Models.SwimteamUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Geeky.Swimteam.Models.SwimteamRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("Geeky.Swimteam.Models.SwimteamUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Geeky.Swimteam.Models.Coach", b =>
                {
                    b.HasOne("Geeky.Swimteam.Models.Swimteam")
                        .WithMany()
                        .HasForeignKey("TeamId");
                });
        }
    }
}
