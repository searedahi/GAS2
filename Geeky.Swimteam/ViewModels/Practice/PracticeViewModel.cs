using System;
using System.Collections.Generic;
using Geeky.Swimteam.Models;
using Geeky.Swimteam.Models.Mappings;

namespace Geeky.Swimteam.ViewModels.Practice
{
    public class PracticeViewModel : IGeekyObj
    {
        public Guid Id { get; set; }
        public string ConcurrencyStamp { get; set; }

        public string Description { get; set; }
        public string PracticeDate { get; set; }
        public string Begins { get; set; }
        public string Ends { get; set; }
        public ICollection<CoachesPractices> Coaches { get; set; }
        public ICollection<SwimmersPractices> Swimmers { get; set; }
        public int MaxParticipants { get; set; }
    }
}