using System;
using System.Collections.Generic;
using Geeky.Models.Base.Enums;

namespace Geeky.Models.Base.Interfaces
{
    public interface IGeekyUser
    {
        PrefixEnumType? Prefix { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        string Suffix { get; set; }
        DateTime? DOB { get; set; }
        bool IsVeteran { get; set; }
        bool IsSeniorCitizen { get; set; }
        string DriversLicense { get; set; }
        ICollection<PhoneNumber> PhoneNumbers { get; set; }
        ICollection<PhysicalAddress> Addresses { get; set; }
    }
}
