using System;
using System.Collections.Generic;
using System.Linq;
using Geeky.Models.Base;

namespace Geeky.Models.Bud
{
    public class RBox
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public string PriceFormatted { get { return Price.ToString("C"); } }

        public decimal Balance
        {
            get
            {
                decimal currentBalance = 0;

                if (Items.Any())
                {
                    currentBalance = Items.Sum(f => f.Product.Price * f.Quantity);
                }

                return currentBalance;
            }
        }

        public string BalanceFormatted { get { return Balance.ToString("C"); } }


        public string ColorCode { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<RImage> Images { get; set; }
        public virtual ICollection<RVideo> Videos { get; set; }
        //[ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
        //[ForeignKey("SubscriptionId")]
        //public virtual Subscription Subscription { get; set; }
        public Guid? PatientId { get; set; }
        //public Guid? SubscriptionId { get; set; }
        public virtual ICollection<RBoxItem> Items { get; set; }

        //public virtual ICollection<Flower> Flowers { get; set; }

        public bool? IsLocked { get; set; }

        public RBox()
        {
            Items = new List<RBoxItem>();
            //Products = new List<IProduct>();
        }


    }
}
