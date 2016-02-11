using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geeky.Models.Swim
{
    public class Practice : IPractice
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Begins { get; set; }
        public string Ends { get; set; }
        public IEnumerable<ICoach> Coaches { get; set; }
        public IEnumerable<ISwimmer> Swimmers { get; set; }
        public int MaxParticipants { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}
