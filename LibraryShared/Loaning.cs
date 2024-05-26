using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryShared
{
    public class Loaning
    {
        [ForeignKey("Readers")]
        [Required]
        public Guid ReaderId { get; set; }

        [ForeignKey("Books")]
        [Required]
        public Guid InventoryNumber { get; set; }

        [Key]
        [Required]
        [LoaningDateValidation]
        public DateTime LoaningDate { get; set; }

        [Required]
        [LoaningDateValidation]
        public DateTime ReturnDate { get; set; }
    }
}
