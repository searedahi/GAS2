using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Geeky.Models.Bud.Interfaces;
using Geeky.Models.Core;
using Geeky.Models.Core.Enums;

namespace Geeky.Models.Bud
{
    public class Subscription : ISubscription
    {
        [Key]
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public decimal Balance { get; set; }
        [Display(Name = "Balance")]
        public string BalanceFormatted
        {
            get { return Balance.ToString("C"); }
        }   
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
        public DateTime? StartDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public RiseStatusEnumType Status { get; set; }

        public Guid? ActivePlanId { get; set; }
        public virtual SubscriptionPlan ActivePlan { get; set; }

        public virtual Patient Patient { get; set; }
        //public virtual RBox RBox { get; set; }
        //public virtual ROrder ROrder { get; set; }
        //public virtual ICollection<RBox> RBoxes { get; set; }
        //public virtual ICollection<ROrder> ROrders { get; set; }

        //public virtual ICollection<SubscriptionPlan> SubscriptionPlans { get; set; }
        //Navigation Properties
        //public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<GImage> Images { get; set; }
        public virtual ICollection<GVideo> Videos { get; set; }
        //public Guid? PatientId { get; set; }
        //public Guid? RBoxId { get; set; }
        //public Guid? ROrderId { get; set; }
        public virtual ICollection<RBoxItem> RBoxeItems { get; set; }

    }
}