using System;
using System.Collections.Generic;
using Geeky.Swimteam.Models.Mappings;

namespace Geeky.Swimteam.Models
{
    public class Practice : IPractice
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime Begins { get; set; }
        public DateTime Ends { get; set; }
        public ICollection<CoachesPractices> Coaches { get; set; }
        public ICollection<SwimmersPractices> Swimmers { get; set; }
        public int MaxParticipants { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}