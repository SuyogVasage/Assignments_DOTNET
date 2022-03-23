using System;
using System.Collections.Generic;

#nullable disable

namespace SuperMarket_23March.Models
{
    public partial class BillDetail
    {
        public int BillItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int RowPrice { get; set; }
        public int BillNo { get; set; }

        public virtual BillMaster BillNoNavigation { get; set; }
        public virtual Product Product { get; set; }
    }
}
