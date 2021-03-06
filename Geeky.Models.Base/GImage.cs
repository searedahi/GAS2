﻿using System;
using System.Collections.Generic;
using Geeky.Models.Base.Interfaces;

namespace Geeky.Models.Base
{
    public class GImage : IGImage
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
        public bool IsBadge { get; set; }

        //Navigation Properties
        public virtual ICollection<Product> Products { get; set; }
        //public virtual ICollection<Subscription> Subscriptions { get; set; }
        //public virtual ICollection<ROrder> ROrders{ get; set; }
        //public virtual ICollection<RBox> RBoxes { get; set; }
    }
}
