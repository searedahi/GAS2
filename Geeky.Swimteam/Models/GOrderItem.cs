using System;

namespace Geeky.Swimteam.Models
{
    public class GOrderItem
    {
        public Guid? Id { get; set; }
        public Product Product { get; set; }
        public int? Quantity { get; set; }
        public GOrder ROrder { get; set; }
    }
}
