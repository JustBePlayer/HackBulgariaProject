using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolWeb.Models
{
    public class EnterModel
    {
        [Required]
        [StringLength(10, ErrorMessage = "The EGN must be {0} characters long", MinimumLength = 10)]
        [Display(Name = "EGN")]
        public string Egn { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The school name must be at least {0} characters long", MinimumLength = 5)]
        [Display(Name = "School name")]
        public string SchoolName { get; set; }

        [Required]
        [Display(Name = "Class (level)")]
        public int ClassNumber { get; set; }

        [Required]
        [StringLength(1, ErrorMessage = "The class letter name must be {0} characters long", MinimumLength = 1)]
        [Display(Name = "Class Letter")]
        public string ClassLetter { get; set; }
    }
}