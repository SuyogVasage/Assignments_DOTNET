using System;
using System.Collections.Generic;

namespace Naukari_24March.Models
{
    public partial class PersonalInfo
    {
        public PersonalInfo()
        {
            EducationInfos = new HashSet<EducationInfo>();
            ProfessionalInfos = new HashSet<ProfessionalInfo>();
        }

        public int CandidateId { get; set; }
        public string FullName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ImgPath { get; set; }
        public string ResumePath { get; set; }
        public string Status { get; set; }
        public string UserId { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<EducationInfo> EducationInfos { get; set; }
        public virtual ICollection<ProfessionalInfo> ProfessionalInfos { get; set; }
    }
}
