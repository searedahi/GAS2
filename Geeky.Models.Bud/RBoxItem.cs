using System;
using Geeky.Models.Core;

namespace Geeky.Models.Bud
{
    public class RBoxItem
    {
        public Guid? Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public RBox RBox { get; set; }
    }
}
