using System;

namespace Geeky.Models.Core
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