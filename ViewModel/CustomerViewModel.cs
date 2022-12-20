using BookShop.Models;
using System.ComponentModel.DataAnnotations;

namespace BookShop.ViewModel
{
    public class CustomerViewModel
    {
        
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
