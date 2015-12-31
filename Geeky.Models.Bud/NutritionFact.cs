using System;
using Geeky.Models.Bud.Interfaces;

namespace Geeky.Models.Bud
{
    class NutritionFact:INutritionFacts
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public double Calories { get; set; }
        public double ServingSize { get; set; }
        public double ServingsPerContainer { get; set; }
        public double CaloriesFromFayt { get; set; }
        public double TotalFatMg { get; set; }
        public double TotalFatDailyValue { get; set; }
        public double TotalSaturatedFatMg { get; set; }
        public double TotalSaturatedFatDailyValue { get; set; }
        public double TotalTransFatMg { get; set; }
        public double TotalTransFatDailyValue { get; set; }
        public double CholesterolMg { get; set; }
        public double CholesterolDailyValue { get; set; }
        public double SodiumMg { get; set; }
        public double SodiumDailyValue { get; set; }
        public double TotalCarbohydrateMg { get; set; }
        public double TotalCarbohydrateDailyValue { get; set; }
        public double ProteinMg { get; set; }
        public double ProteinDailyValue { get; set; }
        public double VitaminAMg { get; set; }
        public double VitaminADailyValue { get; set; }
    }
}
