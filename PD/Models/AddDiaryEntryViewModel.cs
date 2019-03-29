using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PD.Models
{
    public class AddDiaryEntryViewModel
    {
        [Required]
        [StringLength(100)]
        [DisplayName("New entry")]
        public string Text { get; set; }
    }
}