using System.Collections.Generic;
using Geeky.Swimteam.Models.Mappings;

namespace Geeky.Swimteam.Models
{
    public interface IPractice : IGeekyObj
    {
        string Description { get; set; }
        string Begins { get; set; }
        string Ends { get; set; }
        ICollection<CoachesPractices> Coaches { get; set; }
        ICollection<SwimmersPractices> Swimmers { get; set; }

        int MaxParticipants { get; set; }
    }
}