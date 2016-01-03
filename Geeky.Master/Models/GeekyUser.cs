using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Geeky.Models.Base;
using Geeky.Models.Base.Enums;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Geeky.Master.Models
{
    // Add profile data for application users by adding properties to the GeekyUser class
    public partial class GeekyUser : IdentityUser
    {

        public virtual ICollection<UserProfile> Profiles { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public virtual ICollection<PhysicalAddress> Addresses { get; set; }

        //[Display(Name = "Patient Id")]
        //public string PatientId { get; set; }
        //public GeekyUser Caregiver { get; set; }
        //public ICollection<GeekyUser> Physicians { get; set; }

        public GeekyUser()
        {
            Profiles = new List<UserProfile>();
            Addresses = new List<PhysicalAddress>();
            PhoneNumbers = new List<PhoneNumber>();
        }
    }
}
