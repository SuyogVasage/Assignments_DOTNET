namespace WebAPI.Models
{
    public class Category
    {
        [Key]
        public int CategoryRowID { get; set; }
        [Required]
        [StringLength(50)]
        public string? CategoryID { get; set; }
        [Required]
        public string? CategoryName { get; set; }
        [Required]
        [NonNegative(ErrorMessage = "Enter Positive Value")]
        public int BasePrice { get; set; }
        public ICollection<Product>? Products { get; set; }
    }

    public class Product
    {
        [Key]
        public int ProductRowID { get; set; }
        [Required]
        public string? ProductID { get; set; }
        [Required]
        [StringLength(200)]
        public string? ProductName { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        [NonNegative(ErrorMessage = "Enter Positive Value")]
        public int? Price { get; set; }
        [Required]
        public int CategoryRowID { get; set; }
        public Category? Category { get; set; }

    }
    public class RequestLog
    {
        [Key]
        public int RequestID { get; set; }
        public string? ControllerName { get; set; }
        public string? RequestMethodType { get; set; }
        public DateTime RequestDateTime { get; set; }

    }

    public class ExceptionLog
    {
        [Key]
        public int RequestID { get; set; }
        public string? ControllerName { get; set; }
        public string? RequestMethodType { get; set; }
        public DateTime RequestDateTime { get; set; }
        public string? ErrorMessage { get; set; }
        public string? StackTrace { get; set; }  
    }
}


