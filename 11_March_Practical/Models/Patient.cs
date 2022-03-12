using System;
using System.Collections.Generic;

namespace _11_March_Practical.Models
{
    public partial class Patient
    {
        public Patient()
        {
            DailyReports = new HashSet<DailyReport>();
            MedicalInfos = new HashSet<MedicalInfo>();
        }

        public int PatientId { get; set; }
        public string PatientName { get; set; } = null!;
        public string MobileNo { get; set; } = null!;
        public int Age { get; set; }

        public virtual ICollection<DailyReport> DailyReports { get; set; }
        public virtual ICollection<MedicalInfo> MedicalInfos { get; set; }
    }
}
