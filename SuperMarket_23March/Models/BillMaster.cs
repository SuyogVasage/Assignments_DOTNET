using System;
using System.Collections.Generic;

#nullable disable

namespace SuperMarket_23March.Models
{
    public partial class BillMaster
    {
        public BillMaster()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        public int BillNo { get; set; }
        public int BillAmount { get; set; }

        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
