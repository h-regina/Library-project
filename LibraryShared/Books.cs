using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Shared
{
    public class Books
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid InventoryNumber { get; set; }

        [Required]
        [RegularExpression(@".*\S.*")]
        public string BookTitle { get; set; }

        [Required]
        [RegularExpression(@".*\S.*")]
        public string Author { get; set; }

        [Required]
        [RegularExpression(@".*\S.*")]
        public string Publisher { get; set; }

        [Required]
        [Range(0, 2024)]
        public int PublicationYear { get; set; }
    }
}
