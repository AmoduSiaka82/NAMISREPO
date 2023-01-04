using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class rofgpm
    {
        [Display(Name = "Date Of Payment")]
        [Required(ErrorMessage = "Date Of Payment Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfPayment { get; set; }
        [Display(Name = "From")]
        [Required(ErrorMessage = "From  Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FrmDate { get; set; }
        [Display(Name = "To")]
        [Required(ErrorMessage = "To Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ToDate { get; set; }
        [Display(Name = "Year")]
        [Required(ErrorMessage = "Year Required")]
        
        public string Yrs { get; set; }
        [Display(Name = "Month")]
        [Required(ErrorMessage = "Month Required")]
        public string Mos { get; set; }
        [Display(Name = "Days")]
        [Required(ErrorMessage = "Days Required")]
        public string Days  { get; set; }
        [Display(Name = "Rate Of Gratuity P A")]
        [Required(ErrorMessage = "Rate Of Gratuity P A Required")]
        [Range(1, 1000000000)]

        [Column(TypeName = "decimal(18, 2)")]
        
        public decimal RatePerAnum { get; set; }
        [Display(Name = "Amount Paid")]
        [Required(ErrorMessage = "Amount Paid Required")]
        [Range(1, 1000000000)]
        
        [Column(TypeName = "decimal(18, 2)")]
        
        public decimal AmountPaid { get; set; }
        [Display(Name = "File Page Ref")]
        [Required(ErrorMessage = "File Page Ref Required")]
        public string FilePageRef { get; set; }
          

             [Display(Name = "Checked By")]
      
        public string CheckedBy { get; set; }
        public string Status { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        public string Dates { get; set; }
        [Display(Name = "SPRP No")]


        [Column(TypeName = "varchar(50)")]
        public string SprpNo { get; set; }

        public biodata bio { get; set; }


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
