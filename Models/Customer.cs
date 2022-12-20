using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public class Customer
    {
        [Key]
        public int CusId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [StringLength(10)]
        public string Gender { get; set; }
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Image")]
        public string Picture { get; set; }

        public virtual Account Account { get; set; }
    }
}
