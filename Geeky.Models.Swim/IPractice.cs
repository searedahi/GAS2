using System.Collections.Generic;

namespace Geeky.Models.Swim
{
    public interface IPractice
    {
        string Description { get; set; }
        string Begins { get; set; }
        string Ends { get; set; }
        IEnumerable<ICoach> Coaches { get; set; }
        IEnumerable<ISwimmer> Swimmers { get; set; }

        int MaxParticipants { get; set; }
    }
}
