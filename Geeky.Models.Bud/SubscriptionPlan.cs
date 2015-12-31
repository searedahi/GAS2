using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Geeky.Models.Base;
using Geeky.Models.Base.Interfaces;
using Geeky.Models.Bud.Enums;
using Geeky.Models.Bud.Interfaces;

namespace Geeky.Models.Bud
{
    public class SubscriptionPlan : IProduct
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public string PriceFormatted { get { return Price.ToString("C"); } }
        public int? Servings { get; set; }
        public FrequencyTypeEnum Frequency { get; set; }
        //public List<Product> Products { get; set; }
        public int ProductCount { get; set; }
        public string DosageUnit { get; set; }
        public string ColorCode { get; set; }
        public string ImageUrl { get; set; }
        public double? Dosage { get; set; }
        public virtual ICollection<GImage> Images { get; set; }
        public virtual ICollection<GVideo> Videos { get; set; }
        public virtual ICollection<GTag> BulletPoints { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
        public virtual ICollection<RBoxItem> RBoxeItems { get; set; }

        public SubscriptionPlan()
        {
            Id = Guid.NewGuid();

            Images = new Collection<GImage>();
            Videos = new Collection<GVideo>();
            BulletPoints = new List<GTag>();
        }
        public SubscriptionPlan(string guid)
        {
            Id = Guid.Parse(guid);
        }

    }
}
