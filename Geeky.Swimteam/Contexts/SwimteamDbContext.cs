﻿using Geeky.Swimteam.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace Geeky.Swimteam.Contexts
{
    public class SwimteamDbContext : IdentityDbContext<SwimteamUser, SwimteamRole, string>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Models.Swimteam> Swimteams { get; set; }
        public DbSet<Swimmer> Swimmers { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Practice> Practices { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<GImage> Images { get; set; }
        public DbSet<PhysicalAddress> Addresses { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

    }
}