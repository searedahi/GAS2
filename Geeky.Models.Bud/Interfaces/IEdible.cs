using Geeky.Models.Core.Enums;
using Geeky.Models.Core.Interfaces;

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
