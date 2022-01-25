using System.ComponentModel.DataAnnotations;

namespace CustomerAPI.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
       
        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; }
        
        [Required]
        public int Phone { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string Address { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

    }
}