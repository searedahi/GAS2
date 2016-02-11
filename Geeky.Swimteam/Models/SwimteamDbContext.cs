﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geeky.Models.Swim;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Geeky.Swimteam.Models;

namespace Geeky.Swimteam.Models
{
    public class SwimteamDbContext : IdentityDbContext<SwimteamUser, SwimteamRole, string>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

        }

        public DbSet<Practice> Practices { get; set; }
    }
}
