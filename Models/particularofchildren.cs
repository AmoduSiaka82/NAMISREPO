using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class particularofchildren
    {
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Surname Must Start with Upper Case")]

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Surname Required")]
        public string Surname { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Middle Name Must Start with Upper Case")]

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "First Name Must Start with Upper Case")]

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name Required")]
        public string FirstName { get; set; }
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender Required")]
        public string Sex { get; set; }
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
       

        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Checked By")]
        
        public string CheckedBy { get; set; }
        [Display(Name = "SPRP No")]

        [Column(TypeName = "varchar(50)")]
        public string SprpNo { get; set; }

        public biodata bio { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Time { get; set; }
        [Key]
        public int Id { get; set; }
        [Display(Name = "Remark")]

        [DataType(DataType.MultilineText)]
        public string EdNote { get; set; }

        [Display(Name = "Remark")]

        [DataType(DataType.MultilineText)]
        public string HodNote { get; set; }
        [Display(Name = "Remark")]
        [DataType(DataType.MultilineText)]
        public string UnitNote { get; set; }
    }
}
