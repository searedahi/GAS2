using System;

namespace Geeky.Models.Base
{
    public class ROrderItem
    {
        public Guid? Id { get; set; }
        public Product Product { get; set; }
        public int? Quantity { get; set; }
        public ROrder ROrder { get; set; }
    }
}
