using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class schoolcertificatehelds
    {
        [Display(Name = "School Certificate Held")]
        [Required(ErrorMessage = "School Certificate Held Required")]
        public string schoolcertificateheld { get; set; }
       [Display(Name = "Checked By")]
      
        public string CheckedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        public string Dates { get; set; }
        public string Status { get; set; }
        [Display(Name = "SPRP No")]

        [Column(TypeName = "varchar(50)")]
        public string SprpNo { get; set; }

        public biodata bio { get; set; }
        [Key]
        public int Id { get; set; }
        [Display(Name = "ED Note")]

        [DataType(DataType.MultilineText)]
        public string EdNote { get; set; }

        [Display(Name = "Hod Note")]

        [DataType(DataType.MultilineText)]
        public string HodNote { get; set; }
        [Display(Name = "Unit Head Note")]
        [DataType(DataType.MultilineText)]
        public string UnitNote { get; set; }
    }
}
