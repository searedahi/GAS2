using System.Collections.Generic;
using Geeky.Models.Core;

namespace Geeky.Models.Bud
{
    public class Caregiver : GeekyUser
    {
        //public Guid? Id { get; set; }
        //public UserProfile Profile { get; set; }
        public ICollection<Physician> Physicians { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}
