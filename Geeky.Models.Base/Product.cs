using System;
using System.Collections.Generic;
using Geeky.Models.Base.Interfaces;

namespace Geeky.Models.Base
{
    public abstract class Product : IProduct
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public string PriceFormatted
        {
            get { return Price.ToString("C"); }
        }

        public int? Servings { get; set; }
        public double? Dosage { get; set; }
        public string DosageUnit { get; set; }
        public string ColorCode { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<RImage> Images { get; set; }
        public virtual ICollection<RVideo> Videos { get; set; }
        //public virtual ICollection<RBoxItem> RBoxeItems { get; set; }
    }
}
