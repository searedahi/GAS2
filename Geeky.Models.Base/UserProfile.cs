using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Geeky.Models.Base.Enums;

namespace Geeky.Models.Base
{
    public class UserProfile
    {
        public Guid? Id { get; set; }
        public PrefixEnumType? Prefix { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        //[NotMapped]
        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }

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
        public virtual GImage DriversLicenseImage { get; set; }
        public virtual GImage ProfileImage { get; set; }
        public bool IsValid
        {
            get
            {
                if (string.IsNullOrEmpty(FirstName)) { return false; }
                if (string.IsNullOrEmpty(LastName)) { return false; }
                if (DOB == null || DOB.Value.Year < 1900) { return false; }
                if (string.IsNullOrEmpty(DriversLicense)) { return false; }
                return true;
            }
        }

        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public virtual ICollection<PhysicalAddress> Addresses { get; set; }
        //public virtual ICollection<PatientIdModel> PatientIds { get; set; }
        //public PatientIdModel PatientIdModel { get; set; }
        public virtual GeekyUser BaseUser { get; set; }
        public Guid? ProfileImageId { get; set; }
        public Guid? DriversLicenseImageId { get; set; }

        //public UserProfile()
        //{
        //    //Id = Guid.NewGuid();
        //    Addresses = new List<PhysicalAddress>();
        //    PhoneNumbers = new List<PhoneNumber>();
        //}
    }
}
