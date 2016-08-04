using System.Collections.Generic;
using Geeky.Models.Core.Interfaces;

namespace Geeky.Models.Bud.Interfaces
{
    public interface IExtract : IProduct
    {
        ICollection<Flower> Flowers { get; set; }
        ICannabaceuticalFacts CannabaceuticalFacts { get; set; }
        string ServingSize { get; set; }
    }
}
