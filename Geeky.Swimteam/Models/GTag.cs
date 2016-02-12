using System;
using System.ComponentModel.DataAnnotations;

namespace Geeky.Swimteam.Models
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
