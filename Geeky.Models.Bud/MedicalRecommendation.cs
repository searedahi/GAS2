using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Geeky.Models.Base;
using Geeky.Models.Base.Enums;

namespace Geeky.Models.Bud
{
    public class MedicalRecommendation
    {
        [Key]
        public Guid? Id { get; set; }
        public string Description { get; set; }
        public DateTime? IssuedDate { get; set; }
        
        [Display(Name = "Expires")]
        public DateTime? ExpirationDate { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<RImage> Images { get; set; }
        public string PatientIdRaw { get; set; }
        public string PhysicianNameRaw { get; set; }
        [Display(Name="Verification Url")]
        public string VerificationUrlRaw { get; set; }
        public RiseStatusEnumType Status { get; set; }
        [Display(Name = "Verified")]
        public bool IsVerified { get; set; }
        public bool IsActivePatientRecommendation { get; set; }

        public virtual RImage RecommendationImage { get; set; }
        public Guid? RecommendationImageId { get; set; }

        //Navigation Properties
        //[ForeignKey("PatientId")]
        //[Required]
        public virtual Patient Patient { get; set; }
        //public Guid PatientId { get; set; }
        //[ForeignKey("PhysicianId")]
        //[Required]
        public virtual Physician Physician { get; set; }
        //public Guid PhysicianId { get; set; }










        //public MedicalRecommendation()
        //{
        //    Images = new List<RImage>();
        //}

    }
}
