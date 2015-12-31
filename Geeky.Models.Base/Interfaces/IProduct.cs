using System.Collections.Generic;

namespace Geeky.Models.Base.Interfaces
{
    public interface IProduct : IGeekyBaseObject
    {
        decimal Price { get; set; }
        string PriceFormatted { get; }
        int? Servings { get; set; }
        double? Dosage { get; set; }
        string DosageUnit { get; set; }
        string ColorCode { get; set; }
        string ImageUrl { get; set; }

        ICollection<GImage> Images { get; set; }
        ICollection<GVideo> Videos { get; set; }
        //ICollection<RBoxItem> RBoxeItems { get; set; }

    }
}
