using System;
using Geeky.Models.Base.Interfaces;
using Geeky.Models.Bud.Enums;

namespace Geeky.Models.Bud.Interfaces
{
    public interface IFlower : IProduct
    {
        Guid? StrainId { get; set; }
        Strain Strain { get; set; }
        bool HasMildew{get; set;}
        bool HasMold { get; set; }
        bool HasPesticide { get; set; }
        bool IsOrganic { get; set; }
        bool IsTested { get; set; }
        bool IsOutdoor { get; set; }
        string GrowTypeName{get; set;}
        int GrowTypeId { get; set; }
        GrowTypeEnum GrowTypeEnum { get; set; }
        string ServingSize { get; set; }
    }
}
