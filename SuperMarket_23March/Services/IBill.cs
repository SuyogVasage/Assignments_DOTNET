using SuperMarket_23March.Models;

namespace SuperMarket_23March.Services
{
    public interface IBill
    {
        bool GenerateBill(BillMaster bill, BillDetail []details);
    }
}
