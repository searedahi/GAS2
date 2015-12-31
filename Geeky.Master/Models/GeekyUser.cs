using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Geeky.Models.Base;
using Geeky.Models.Base.Enums;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Geeky.Master.Models
{
    // Add profile data for application users by adding properties to the GeekyUser class
    public class GeekyUser : IdentityUser
    {
        public PrefixEnumType? Prefix { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Suffix")]
        public string Suffix { get; set; }
        [Display(Name = "Birthday")]
        public DateTime? DOB { get; set; }
        [Display(Name = "Veteran")]
        public bool IsVeteran { get; set; }
        [Display(Name = "Senior")]
        public bool IsSeniorCitizen { get; set; }
        [Display(Name = "Drivers License")]
        public string DriversLicense { get; set; }
        [Display(Name = "Patient Id")]
        public string PatientId { get; set; }
        public bool HasCaregiver { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public virtual ICollection<PhysicalAddress> Addresses { get; set; }
        public GeekyUser Caregiver { get; set; }
        public ICollection<GeekyUser> Physicians { get; set; }

        public GeekyUser()
        {
            Addresses = new List<PhysicalAddress>();
            PhoneNumbers = new List<PhoneNumber>();
        }
    }
}
