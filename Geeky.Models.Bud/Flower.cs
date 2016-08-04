using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Geeky.Models.Bud.Enums;
using Geeky.Models.Core;

namespace Geeky.Models.Bud
{
    public class Flower : Product
    {
        //[Key]
        //public Guid? Id { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public string ShortDescription { get; set; }
        //public decimal Price { get; set; }

        //public string PriceFormatted
        //{
        //    get { return Price.ToString("C"); }
        //}

        //public string ColorCode { get; set; }
        //public string ImageUrl { get; set; }
        public double ThcPercentage { get; set; }
        public double CbdPercentage { get; set; }
        public double ThcAPercentage { get; set; }
        public Guid? StrainId { get; set; }
        //[ForeignKey("StrainId")]
        public virtual Strain Strain { get; set; }
        public bool HasMildew { get; set; }
        public bool HasMold { get; set; }
        public bool HasPesticide { get; set; }
        public bool IsOrganic { get; set; }
        public bool IsTested { get; set; }
        public bool IsOutdoor { get; set; }
        public string GrowTypeName { get; set; }
        public int GrowTypeId { get; set; }
        [Display(Name="Grow Type")]
        public GrowTypeEnum GrowTypeEnum { get; set; }
        public CannabaceuticalFacts CannabaceuticalFacts { get; set; }


        //Navigation Properties
        public virtual ICollection<Extract> Extracts { get; set; }
        public virtual ICollection<Edible> Edibles { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }



    }
}
