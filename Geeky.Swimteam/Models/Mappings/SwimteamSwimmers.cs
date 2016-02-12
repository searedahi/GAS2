using System;

namespace Geeky.Swimteam.Models.Mappings
{
    public class SwimteamSwimmers : IGeekyObj
    {
        public Guid SwimteamId { get; set; }
        public Guid SwimmerId { get; set; }
        public Swimteam Swimteam { get; set; }
        public Swimmer Swimmer { get; set; }
        public Guid Id { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}