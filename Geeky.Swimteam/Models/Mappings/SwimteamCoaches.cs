using System;

namespace Geeky.Swimteam.Models.Mappings
{
    public class SwimteamCoaches : IGeekyObj
    {
        public Guid CoachId { get; set; }
        public Guid SwimteamId { get; set; }
        public Coach Coach { get; set; }
        public Swimteam Swimteam { get; set; }
        public Guid Id { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}