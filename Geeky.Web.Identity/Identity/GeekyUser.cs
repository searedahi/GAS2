using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Geeky.Web.Identity.Identity
{
    public class GeekyUser : IdentityUser<Guid>
    {
        public GeekyUser()
        {
            this.Id = Guid.NewGuid();
        }

        public GeekyUser(string userName)
            : this()
        {
            this.UserName = userName;
        }

        public GeekyUser(string userName, string email)
    : this()
        {
            this.UserName = userName;
            this.Email = email;
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }
    }
}