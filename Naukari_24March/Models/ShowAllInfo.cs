using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Naukari_24March.Models
{
    public class ShowAllInfo
    {
        [Key]
        public int CandidateID { get; set; }
        public string FullName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ImgPath { get; set; }

        public int SscpassYear { get; set; }
        public double Sscpercentage { get; set; }
        public int? HscpassYear { get; set; }
        public double? Hscpercentage { get; set; }
        public int? DiplomaPassYear { get; set; }
        public double? DiplomaPercentage { get; set; }
        public int DegreePassYear { get; set; }
        public double DegreePercentage { get; set; }
        public string DegreeName { get; set; }
        public int? MastersPassYear { get; set; }
        public double? MastersPercentage { get; set; }
        public string MastersName { get; set; }

        public double? ExpInYears { get; set; }
        public string Companies { get; set; }
        public string Projects { get; set; }

        public List<ShowAllInfo> ShowAllInfos { get; set; }

        public PersonalInfo personalInfos { get; set; }
        public EducationInfo eduInfos { get; set; }

        public ProfessionalInfo professionalInfos { get; set; }
    }
}
