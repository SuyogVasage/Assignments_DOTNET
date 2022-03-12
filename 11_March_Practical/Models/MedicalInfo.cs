using System;
using System.Collections.Generic;

namespace _11_March_Practical.Models
{
    public partial class MedicalInfo
    {
        public int InfoId { get; set; }
        public int PatientId { get; set; }
        public string Patientname { get; set; } = null!;
        public int Weight { get; set; }
        public double? Bp { get; set; }
        public double? CholestrolHdl { get; set; }
        public double? CholestrolLdl { get; set; }
        public double? SugarFast { get; set; }
        public double? SugarPostFast { get; set; }
        public string? Medicine { get; set; }
        public DateTime? AppointmentDate { get; set; }

        public virtual Patient Patient { get; set; } = null!;
    }
}
