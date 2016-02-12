using System;
using System.Collections.Generic;
using Geeky.Swimteam.Models.Interfaces;

namespace Geeky.Swimteam.Models
{
    public class GVideo : IGVideo
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }
        public string DataUrl { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Disabled { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        //public virtual ICollection<Flower> Flowers { get; set; }
        //public virtual ICollection<Extract> Extracts { get; set; }
        //public virtual ICollection<Edible> Edibles { get; set; }
        //public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
