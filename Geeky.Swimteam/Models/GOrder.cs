using System;
using System.Collections.Generic;
using System.Linq;
using Geeky.Swimteam.Models.Enums;

namespace Geeky.Swimteam.Models
{
    public class GOrder
    {
        public Guid? Id { get; set; }
        //public virtual Patient Patient { get; set; }
        public RiseStatusEnumType Status { get; set; }
        //public virtual RBox RiseBox { get; set; }
        //public virtual Subscription Subscription { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public decimal SubTotal {
            get
            {
                if (OrderItems != null && OrderItems.Any())
                {
                    var total = OrderItems.Sum(i => i.Quantity * i.Product.Price);
                    return Convert.ToDecimal(total);
                }
                return 0;
            }
        }
        public string SubTotalFormatted {
            get { return SubTotal.ToString("C"); }
        }
        public decimal Total
        {
            get
            {
                var tax = 0;
                return Convert.ToDecimal(SubTotal + tax);
            }
        }

        public string TotalFormatted
        {
            get { return Total.ToString("C"); }
        }

        public string ColorCode { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<GOrderItem> OrderItems { get; set; }
        public virtual ICollection<GImage> Images { get; set; }
        public virtual ICollection<GVideo> Videos { get; set; }
        //public Guid? PatientId { get; set; }
        //public Guid? RiseBoxId { get; set; }
        //public Guid? SubscriptionId { get; set; }
    }
}
