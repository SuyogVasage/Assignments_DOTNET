namespace WebAPI.Models
{
    public class CatProd
    {
        public int CategoryRowId { get; set; }
        public string? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int BasePrice { get; set; }
        public List<Product>? Products { get; set; }
    }
}
