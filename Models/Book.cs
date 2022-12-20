using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
    public class Book
    {
        [Key]
        [StringLength(10)]
        public int Id { get; set; }
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
        [Display(Name = "Image")]
        public string Picture { get; set; }
        [Required]
        public double Price { get; set; }
        public virtual ICollection<BookCategory> Categories { get; set; }
    }
}
