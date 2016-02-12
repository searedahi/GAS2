using System;
using Geeky.Swimteam.Models.Enums;

namespace Geeky.Swimteam.Models
{
    public class PhysicalAddress
    {
        public Guid Id { get; set; }
        // [DisplayName("Street Number")]
        public string StreetNumber { get; set; }
        // [DisplayName("Street Direction")]
        public string StreetDirection { get; set; }
        //[DisplayName("Street Name")]
        public string StreetName { get; set; }
        //[DisplayName("Street Type")]
        public string StreetType { get; set; }
        //  [DisplayName("Unit")]
        public string Unit { get; set; }
        // [DisplayName("Street 2")]
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        // [DisplayName("Zip Code")]
        public string ZipCode { get; set; }
        public string County { get; set; }
        //  [DisplayName ("Street Address")]
        public string RawStreetAddress { get; set; }
        //    [DisplayName("Street Address 2")]
        public string RawStreetAddress2 { get; set; }
        //public GeoCoordinate Coordinates { get; set; }
        public PhysicalAddressTypeEnum Type { get; set; }

        public string UnparsedAddress { get; set; }


        public PhysicalAddress()
        {
            Id = Guid.NewGuid();
        }


        //Navigation Properties
        public Guid SwimteamUserGuid { get; set; }
        public SwimteamUser SwimteamUser { get; set; }


    }
}
