using System;
using System.Collections.Generic;
using Geeky.Models.Base;
using Geeky.Models.Bud.Enums;
using Geeky.Models.Bud.Interfaces;

namespace Geeky.Models.Bud
{
    public class Strain : IStrain
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public virtual ICollection<Strain> Strains { get; set; }
        public string TypeName { get; set; }
        public string TypeId { get; set; }
        public StrainTypeEnum StrainTypeEnum { get; set; }
        public double GenpotypePercentage { get; set; }
        public string ColorCode { get; set; }
        //[ForeignKey("Badge")]
        public Guid? BadgeId { get; set; }
        public virtual RImage Badge { get; set; }
        //[ForeignKey("MainImage")]
        //public Guid? MainImageId { get; set; }
        //public virtual RImage MainImage { get; set; }

    }
}
