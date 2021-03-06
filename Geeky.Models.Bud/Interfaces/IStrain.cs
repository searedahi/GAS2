﻿using System.Collections.Generic;
using Geeky.Models.Base.Interfaces;
using Geeky.Models.Bud.Enums;

namespace Geeky.Models.Bud.Interfaces
{
    public interface IStrain : IGeekyBaseObject
    {
        ICollection<Strain> Strains { get; set; }
        string TypeName { get; set; } // Sativa / indica
        string TypeId { get; set; } //Sativa = 1, Indica = 2
        StrainTypeEnum StrainTypeEnum { get; set; }
        double GenpotypePercentage { get; set; }
        string ColorCode { get; set; }

    }
}
