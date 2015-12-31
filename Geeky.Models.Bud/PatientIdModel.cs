using System;
using System.ComponentModel.DataAnnotations;

namespace Geeky.Models.Bud
{
    public class PatientIdModel
    {
        [Key]//,ForeignKey("Patient")]
        public Guid? Id { get; set; }

        public Patient  Patient { get; set; }

    }
}
