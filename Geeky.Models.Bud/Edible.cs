using System.Collections.Generic;
using Geeky.Models.Bud.Interfaces;
using Geeky.Models.Core;
using Geeky.Models.Core.Enums;

namespace Geeky.Models.Bud
{
    public class Edible : Product
    {

        public INutritionFacts NutrtionFacts { get; set; }
        public PhysicalState PhysicalState { get; set; }
        public ICannabaceuticalFacts CannabaceuticalFacts { get; set; }
        //Navigation Properties
        public virtual ICollection<Flower> Flowers { get; set; }
        //[NotMapped]
        public virtual ICollection<string> SelectedFlowers { get; set; }
    }
}
