using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class recordofemolument
    {
        [DataType(DataType.Date)]
        [Display(Name = "Date Entry Made")]
        [Required(ErrorMessage = "Date Of Entry Required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime DateOfEntery { get; set; }
        [Display(Name = "Salary Scale")]
        [Required(ErrorMessage = "Salary Scale Required")]
        public string SalaryScale { get; set; }
        
        [Range(1, 1000000000)]

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Basic Salary Per Annum")]
        [Required(ErrorMessage = "Basic Salary PA Required")]
        public decimal BasicSalaryPA { get; set; }
     
        [Range(1, 1000000000)]

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Inducement Pay Per Annum")]
        [Required(ErrorMessage = "Inducement Pay PA Requried")]
       
        public decimal InducementPayPA { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Paid From")]
        [Required(ErrorMessage = "Date Paid From")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime DatePaidFrm { get; set; }
        [Required]
        [Display(Name = "Increment Month")]
        public string IncriminisDateM { get; set; }
        [Required]
        [Display(Name = "Increment Year")]
        public string IncriminisDateYr  { get; set; }
        [Required]
        public string Authority   { get; set; }
        [Required]
        public string Signature { get; set; }
        [Required]
        [Display(Name = "Name And Stamp")]
        public string NameAndStamp { get; set; }
    public string Dates { get; set; }
        public string Status { get; set; }
        [Display(Name = "SPRP No")]

        [Column(TypeName = "varchar(50)")]
        public string SprpNo { get; set; }

        public biodata bio { get; set; }


        [Key]
        public int ID { get; set; }
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
