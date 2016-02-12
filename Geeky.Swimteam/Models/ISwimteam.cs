using System.Collections.Generic;
using Geeky.Swimteam.Models.Mappings;

namespace Geeky.Swimteam.Models
{
    public interface ISwimteam : IGeekyObj
    {
        ICollection<SwimteamSwimmers> Swimmers { get; set; }
        ICollection<SwimteamCoaches> Coaches { get; set; }
    }
}