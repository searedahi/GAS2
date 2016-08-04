using Geeky.Models.Core.Interfaces;

namespace Geeky.Models.Bud.Interfaces
{
    public interface INutritionFacts : IGeekyBaseObject
    {
        double Calories { get; set; }
        double ServingSize { get; set; }
        double ServingsPerContainer { get; set; }
        double CaloriesFromFayt { get; set; }
        double TotalFatMg { get; set; }
        double TotalFatDailyValue { get; set; }
        double TotalSaturatedFatMg { get; set; }
        double TotalSaturatedFatDailyValue { get; set; }
        double TotalTransFatMg { get; set; }
        double TotalTransFatDailyValue { get; set; }
        double CholesterolMg { get; set; }
        double CholesterolDailyValue { get; set; }
        double SodiumMg { get; set; }
        double SodiumDailyValue { get; set; }
        double TotalCarbohydrateMg { get; set; }
        double TotalCarbohydrateDailyValue { get; set; }
        double ProteinMg { get; set; }
        double ProteinDailyValue { get; set; }
        double VitaminAMg { get; set; }
        double VitaminADailyValue { get; set; }
    }
}
