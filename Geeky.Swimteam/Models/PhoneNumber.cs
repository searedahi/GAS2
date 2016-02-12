using System;
using Geeky.Swimteam.Models.Enums;

namespace Geeky.Swimteam.Models
{
    public class PhoneNumber
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public PhoneNumberTypeEnum NumberType  { get; set; }

        //Navigation Properties
        //public SwimteamUser SwimteamUser { get; set; }
    }
}
