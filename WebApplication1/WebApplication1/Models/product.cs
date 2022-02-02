
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Product
    {
        [Required]
        public int ProductId { get; set; }
        [Required(ErrorMessage ="Product Name is required.")]
        [MinLength(3,ErrorMessage ="Product Name should be 3 or More chars.")]
        [MaxLength(50,ErrorMessage ="Product name can't be greater than 50 chars.")]
        public string ProductName { get; set; }
        [Required(ErrorMessage ="Unit Price is required.")]
        [Range(minimum: 1,maximum:1000,ErrorMessage ="Range should be between 1 and 1000.")]
        public decimal UnitPrice { get; set; }
        [Required(ErrorMessage ="Stock Level is required.")]
        [Range(minimum:0,maximum:1000,ErrorMessage ="Stock should be between 0-1000.")]
        public short UnitInStock { get; set; }
        public bool Discontinued { get; set; }

    }
}
