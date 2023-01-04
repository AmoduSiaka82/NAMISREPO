using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class totalpreviousservice
    {
        [Display(Name = "Year")]
        [Required(ErrorMessage = "Year Required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Year Must Be Number")]
        public string Yrs  { get; set; }
        [Display(Name = "Month")]
        [Required(ErrorMessage = "Month Required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Month Must Be Number")]
        public string Mos  { get; set; }
        [Display(Name = "Day")]
        [Required(ErrorMessage = "Day Required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Day Must Be Number")]
        public string Days  { get; set; }
        [Display(Name = "Total Amount Pay")]
        [Required(ErrorMessage = "Total Amount Pay Required")]
        
        [Range(1, 1000000000)]

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmountPay  { get; set; } 
        [Display(Name = "SPRP No")]

        [Column(TypeName = "varchar(50)")]
        public string SprpNo { get; set; }

        public biodata bio { get; set; }
        public string Dates { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        public string Status { get; set; }
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
