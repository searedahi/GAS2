using System;
using System.Collections.Generic;

namespace Geeky.Models.Core.Interfaces
{
    public interface IMedia
    {
        Guid? Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string ThumbnailUrl { get; set; }
        string DataUrl { get; set; }
        DateTime? Created { get; set; }
        DateTime? Disabled { get; set; }
        double Latitude { get; set; }
        double Longitude { get; set; }
        ICollection<Product> Products { get; set; }
    }
}
