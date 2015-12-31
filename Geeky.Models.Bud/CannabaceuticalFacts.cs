using System;
using Geeky.Models.Bud.Interfaces;

namespace Geeky.Models.Bud
{
    public class CannabaceuticalFacts : ICannabaceuticalFacts
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public double ThcPercentage { get; set; }
        public double ThcAPercentage { get; set; }
        public double ThcVPercentage { get; set; }
        public double CbdPercentage { get; set; }
        public double CbdAPercentage { get; set; }
        public double CbnPercentage { get; set; }
        public double CbgPercentage { get; set; }
        public double CbcPercentage { get; set; }
        public double WeightLossOnDryingPercent { get; set; }
    }
}
