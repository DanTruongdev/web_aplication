using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
    public class BookCategory
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
