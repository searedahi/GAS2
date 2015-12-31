using System.Collections.Generic;
using Geeky.Models.Base;
using Geeky.Models.Bud.Interfaces;

namespace Geeky.Models.Bud
{
    public class Extract : Product
    {
        public virtual ICollection<Flower> Flowers { get; set; }
        public ICannabaceuticalFacts CannabaceuticalFacts { get; set; }
    }
}
