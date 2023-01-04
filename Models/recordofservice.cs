using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class recordofservice
    {
        [Display(Name = "Date Entry Made")]
        [Required(ErrorMessage = "Date of Entry Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime DateOfEntery  { get; set; }
        [Display(Name = "Details")]
        [Required(ErrorMessage = "Details Required")]
        [DataType(DataType.MultilineText)]
        public string Detail   { get; set; }
        [Display(Name = "Signature")]
        [Required(ErrorMessage = "Signature Required")]
        public string Signature  { get; set; }
        [Display(Name = "Checked By And Stamp")]
        
        public string CheckedByAndStamp  { get; set; }
          
            
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
