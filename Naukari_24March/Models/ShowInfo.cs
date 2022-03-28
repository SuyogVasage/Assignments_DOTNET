using System.ComponentModel.DataAnnotations;

namespace Naukari_24March.Models
{
    public class ShowInfo
    {
        [Key]
        public int CandidateId { get; set; }
        public string FullName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Highest_Qualification { get; set; }
        public string ImgPath { get; set; }
    }
}
