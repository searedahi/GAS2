using System;

namespace Geeky.Swimteam.Models.Mappings
{
    public class CoachesSwimmers : IGeekyObj
    {
        public Coach Coach { get; set; }
        public Swimmer Swimmer { get; set; }
        public Guid Id { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}