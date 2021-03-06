﻿
using Geeky.Models.Base.Enums;
using Geeky.Models.Base.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Geeky.Models.Base
{
    public class CreditCard : IGeekyBaseObject
    {
        public Guid? Id { get; set; }
        [Display(Name = "Name On Card")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string CardNumber { get; set; }
        
        [Display(Name = "Expiration Date")]
        public MonthTypeEnum MonthType { get; set; }
        public int? Year { get; set; }

        //[NotMapped]
        //public IEnumerable<SelectListItem> YearTypes { get; set; }
        [Display(Name = "Security Code")]
        public string CVV { get; set; }

        // Navigation Properties
        public virtual GeekyUser User { get; set; }
        public Guid? UserId { get; set; }

    }
}
