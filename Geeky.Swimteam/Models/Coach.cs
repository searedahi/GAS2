using System.Collections.Generic;
using Geeky.Swimteam.Models.Mappings;

namespace Geeky.Swimteam.Models
{
    public class Coach : SwimteamUser, ICoach
    {
        public Swimteam Team { get; set; }
        public ICollection<CoachesSwimmers> Swimmers { get; set; }
    }
}