using System;
using System.Collections.Generic;

#nullable disable

namespace SuperMarket_23March.Models
{
    public partial class Product
    {
        public Product()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
