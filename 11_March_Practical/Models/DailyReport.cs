using System;
using System.Collections.Generic;

namespace _11_March_Practical.Models
{
    public partial class DailyReport
    {
        public int ReportId { get; set; }
        public int PatientId { get; set; }
        public DateTime? Date { get; set; }
        public double? Fees { get; set; }

        public virtual Patient Patient { get; set; } = null!;
    }
}
