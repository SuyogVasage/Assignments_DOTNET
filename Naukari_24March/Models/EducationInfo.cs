using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Naukari_24March.Models
{
    public partial class EducationInfo
    {
        public int EduId { get; set; }
        public int CandidateId { get; set; }
        public int SscpassYear { get; set; }
        [Required]
        [IsPercentage]
        public double Sscpercentage { get; set; }
        public int? HscpassYear { get; set; }
        public double? Hscpercentage { get; set; }
        public int? DiplomaPassYear { get; set; }
        public double? DiplomaPercentage { get; set; }
        public int DegreePassYear { get; set; }
        [Required]
        [IsPercentage]
        public double DegreePercentage { get; set; }
        [Required]
        public string DegreeName { get; set; }
        public int? MastersPassYear { get; set; }
        public double? MastersPercentage { get; set; }
        public string MastersName { get; set; }

        public virtual PersonalInfo Candidate { get; set; }
    }
}
