using System.Collections.Generic;
using Geeky.Models.Base;

namespace Geeky.Models.Bud
{
    public class Physician : GeekyUser
    {
        public string LicenseNumber { get; set; }
        public string VerificationUrl { get; set; }
        public string RawName { get; set; }



        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<MedicalRecommendation> MedicalRecommendations { get; set; }
        //public virtual ICollection<Caregiver> Caregivers { get; set; }


        //public Physician()
        //{
        //    Patients = new List<Patient>();
        //    MedicalRecommendations = new List<MedicalRecommendation>();
        //    Caregivers = new List<Caregiver>();
        //}
    }
}
