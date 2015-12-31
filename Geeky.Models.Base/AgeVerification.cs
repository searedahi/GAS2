using System;

namespace Geeky.Models.Base
{
    public class AgeVerification
    {
        public Guid Id { get; set; }
        public string IpAddress { get; set; }
        public DateTime Created { get; set; }

        //[NotMapped]
        public string RedirectUrl { get; set; }
    }
}