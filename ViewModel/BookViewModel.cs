using BookShop.Models;
using System.ComponentModel.DataAnnotations;

namespace BookShop.ViewModel
{
    public class BookViewModel
    {

        [StringLength(10)]
        [Required]
        public string Title { get; set; }
        [StringLength(50)]
        [Required]
        public string Author { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime PublicDate { get; set; }
        public int CategoryID { get; set; }
        [Required]
        public IFormFile Picture { get; set; }
        [Required]
        public double Price { get; set; }
       

    }
}
