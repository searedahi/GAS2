using System.Collections.Generic;
using Geeky.Models.Core;

namespace Geeky.Models.Swim
{
    public class Coach : GeekyUser
    {
        public SwimTeam Team { get; set; }
        public List<Swimmer> Swimmers { get; set; }
    }
}
