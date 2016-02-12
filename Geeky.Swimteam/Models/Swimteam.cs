using System;
using System.Collections.Generic;
using Geeky.Swimteam.Models.Mappings;

namespace Geeky.Swimteam.Models
{
    public class Swimteam : ISwimteam
    {
        public ICollection<SwimteamSwimmers> Swimmers { get; set; }
        public ICollection<SwimteamCoaches> Coaches { get; set; }
        public Guid Id { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}