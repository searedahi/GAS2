using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Geeky.Web.Auth.Models
{
    public class GeekyRole : IdentityRole<Guid>
    {
        public GeekyRole()
        {
            this.Id = Guid.NewGuid();
        }

        public GeekyRole(string name)
            : this()
        {
            this.Name = name;
        }

        public GeekyRole(string name, Guid id)
        {
            this.Name = name;
            this.Id = id;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}