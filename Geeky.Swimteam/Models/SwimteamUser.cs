using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Geeky.Swimteam.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class SwimteamUser : IdentityUser
    {
        //[Display(Name = "Patient Id")]
        //public string PatientId { get; set; }
        //public GeekyUser Caregiver { get; set; }
        //public ICollection<GeekyUser> Physicians { get; set; }

        public SwimteamUser()
        {
            Profiles = new List<UserProfile>();
            //Addresses = new List<PhysicalAddress>();
            //PhoneNumbers = new List<PhoneNumber>();
        }

        public virtual ICollection<UserProfile> Profiles { get; set; }
        //public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
        //public virtual ICollection<PhysicalAddress> Addresses { get; set; }
    }
}