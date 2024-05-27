﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Shared
{
    public class Readers
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ReaderId { get; set; }

        [Required]
        [RegularExpression(@".*\S.*")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@".*\S.*")]
        public string Address { get; set; }

        [Required]
        [Range(typeof(DateTime), "1900-01-01", "2024-05-28")]
        public DateTime BirthDate { get; set; }

    }
}
