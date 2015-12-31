using Geeky.Models.Base.Enums;
using Geeky.Models.Base.Interfaces;
using Geeky.Models.Bud.Enums;

namespace Geeky.Models.Bud.Interfaces
{
    public interface IEdible : IProduct
    {
        INutritionFacts NutrtionFacts { get; set; }
        PhysicalState PhysicalState { get; set; }
        ICannabaceuticalFacts CannabaceuticalFacts { get; set; }
        string ServingSize { get; set; }
    }
}
