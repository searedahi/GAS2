using System.Collections.Generic;
using Geeky.Models.Bud.Interfaces;
using Geeky.Models.Core;

namespace Geeky.Models.Bud
{
    public class Extract : Product
    {
        public virtual ICollection<Flower> Flowers { get; set; }
        public ICannabaceuticalFacts CannabaceuticalFacts { get; set; }
    }
}
