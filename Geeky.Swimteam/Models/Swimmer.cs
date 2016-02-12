using System.Collections.Generic;
using Geeky.Swimteam.Models.Mappings;

namespace Geeky.Swimteam.Models
{
    public class Swimmer : SwimteamUser, ISwimmer
    {
        // Navigation properties
        public ICollection<CoachesSwimmers> Coaches { get; set; }
    }
}