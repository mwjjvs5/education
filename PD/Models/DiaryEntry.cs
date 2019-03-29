using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PD.Models
{
    public class DiaryEntry
    {
        public Guid Id { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [StringLength(100)]
        public string Text { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

    }
}