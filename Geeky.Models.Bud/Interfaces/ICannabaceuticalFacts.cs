using Geeky.Models.Core.Interfaces;

namespace Geeky.Models.Bud.Interfaces
{
    public interface ICannabaceuticalFacts : IGeekyBaseObject
    {
        // Tetrahydrocannabinol
        double ThcPercentage { get; set; }

        //Tetrahydrocannabinolic Acid 
        double ThcAPercentage { get; set; }

        //Tetrahydrocannabivarin
        double ThcVPercentage { get; set; }

        //Cannabidiol 
        double CbdPercentage { get; set; }

        //Cannabidiolic Acid 
        double CbdAPercentage { get; set; }

        //Cannabinol 
        double CbnPercentage { get; set; }

        //Cannabigerol 
        double CbgPercentage { get; set; }

        //Cannabichromene 
        double CbcPercentage { get; set; }

        double WeightLossOnDryingPercent { get; set; }
    }
}
