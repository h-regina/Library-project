using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Shared
{
    public class Loaning

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LoaningId { get; set; }

        [ForeignKey("Readers")]
        [Required]
        public Guid ReaderId { get; set; }

        [ForeignKey("Books")]
        [Required]
        public Guid InventoryNumber { get; set; }

        [Required]
        [LoaningDateValidation]
        public DateTime LoaningDate { get; set; }

        [Required]
        [ReturnDateValidation]
        public DateTime ReturnDate { get; set; }
    }
}
