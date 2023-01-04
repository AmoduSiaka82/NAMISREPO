using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class VariationAdvice
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(500)")]
        [Display(Name = "Surname")]
        [Required]
        public string Surname { get; set; }
        
        [Column(TypeName = "varchar(500)")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
       
        [Required]
        [Display(Name = "First Name")]
        [Column(TypeName = "varchar(500)")]
        public string FirstName { get; set; }
        [Display(Name = "SPRP No")]
        [Required] 
        [Column(TypeName = "varchar(50)")]
        public string SprpNo { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        [Display(Name = "Rank")]
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Rank { get; set; }
        [Display(Name = "Step")]
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Step { get; set; }
        [Display(Name = "Old Sal")]
        [Required]
        [Range(1, 1000000000)]

        [Column(TypeName = "decimal(18, 2)")]
        public decimal OldSal { get; set; }
        [Display(Name = "New Sal")]
        [Required]
        [Range(1, 1000000000)]

        [Column(TypeName = "decimal(18, 2)")]
        public decimal NewSal { get; set; }
        [Display(Name = "Amt of Variation")]
        [Required]
        [Range(1, 1000000000)]

        [Column(TypeName = "decimal(18, 2)")]
        public decimal AmtOfVariation { get; set; }
        [Display(Name = "Reasons")]
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Reasons { get; set; }
        [Display(Name = "Effective")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EffDate { get; set; }
        [Display(Name = "Remark")]
        [Required]
        [Column(TypeName = "varchar(2000)")]
        public string Remark { get; set; }
        [Display(Name = "Current Appointment")]
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string CurrentAppointment { get; set; }
        [Display(Name = "Authority")]
        [Required]
        [Column(TypeName = "varchar(2000)")]
        public string Authority { get; set; }
        [Display(Name = "Station Name")]

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string StationName { get; set; }
    }
}
