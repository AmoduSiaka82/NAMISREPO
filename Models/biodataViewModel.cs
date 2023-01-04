using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class biodataViewModel
    {
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Surname Must Start with Upper Case")]

        [Display(Name = "Surname")]

        public string Surname { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Middle Name Must Start with Upper Case")]

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "First Name Must Start with Upper Case")]

        [Display(Name = "First Name")]

        public string FirstName { get; set; }
        [Display(Name = "SPRP No")]

        [RegularExpression("^[0-9]*$", ErrorMessage = "SPRP No must be numeric")]
        [Key]
        public string SprpNo { get; set; }
        [Display(Name = "ED Note")]

        [DataType(DataType.MultilineText)]
        public string EdNote { get; set; }
    }
}
