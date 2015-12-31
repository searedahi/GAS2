using System.Collections.Generic;
using Geeky.Models.Base;
using Geeky.Models.Base.Enums;
using Geeky.Models.Bud.Enums;
using Geeky.Models.Bud.Interfaces;

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
