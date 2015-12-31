using System;
using System.Collections.Generic;
using Geeky.Models.Base;

namespace Geeky.Models.Bud
{
    public class Patient : GeekyUser
    {
        public virtual Subscription Subscription { get; set; }
        public virtual MedicalRecommendation ActiveRecommendation { get; set; }
        public virtual RBox ActiveBox { get; set; }
        public virtual ICollection<ROrder> Orders { get; set; }
        public virtual ICollection<Physician> Physicians { get; set; }
        //public virtual ICollection<Caregiver> Caregivers { get; set; }
        public virtual ICollection<MedicalCondition> MedicalConditions { get; set; }
        public virtual ICollection<MedicalSymptom> MedicalSymptoms { get; set; }
        public virtual ICollection<MedicalRecommendation> MedicalRecommendations { get; set; }
        
        public Guid? ActiveRecommendationId { get; set; }

        //public Patient()
        //{
        //    Physicians = new List<Physician>();
        //    Caregivers = new List<Caregiver>();
        //    MedicalRecommendations= new List<MedicalRecommendation>();
        //    MedicalConditions = new List<MedicalCondition>();
        //    MedicalSymptoms = new List<MedicalSymptom>();
        //}
    }
}