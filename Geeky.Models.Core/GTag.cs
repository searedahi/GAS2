using System;
using System.ComponentModel.DataAnnotations;


namespace Geeky.Models.Core
{
    public class GTag
    {
        [Key]
        public Guid? Id { get; set; }

        public string Value { get; set; }



        //Navigation properties
        //public virtual ICollection<SubscriptionPlan> SubscriptionPlans { get; set; }




    }
}
