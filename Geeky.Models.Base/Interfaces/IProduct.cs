using System.Collections.Generic;

namespace Geeky.Models.Base.Interfaces
{
    public interface IProduct : IRiseBaseObject
    {
        decimal Price { get; set; }
        string PriceFormatted { get; }
        int? Servings { get; set; }
        double? Dosage { get; set; }
        string DosageUnit { get; set; }
        string ColorCode { get; set; }
        string ImageUrl { get; set; }

        ICollection<RImage> Images { get; set; }
        ICollection<RVideo> Videos { get; set; }
        //ICollection<RBoxItem> RBoxeItems { get; set; }

    }
}
