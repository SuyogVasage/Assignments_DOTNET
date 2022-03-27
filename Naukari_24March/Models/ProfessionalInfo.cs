using System;
using System.Collections.Generic;

#nullable disable

namespace Naukari_24March.Models
{
    public partial class ProfessionalInfo
    {
        public int InfoId { get; set; }
        public int CandidateId { get; set; }
        public double? ExpInYears { get; set; }
        public string Companies { get; set; }
        public string Projects { get; set; }

        public virtual PersonalInfo Candidate { get; set; }
    }
}
