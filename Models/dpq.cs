using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class dpq
    {

        [Display(Name = "Degrees & Professional Qaulification")]
        [Required(ErrorMessage = "Degrees & Professional Qaulification Required")]
        [Column(TypeName = "varchar(150)")]
        public string Dpq { get; set; }
        [Display(Name = "Checked By")]
        [Column(TypeName = "varchar(300)")]
        public string CheckedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime Date { get; set; }
          public string Dates { get; set; }
            [Display(Name = "SPRP No")]
       
        public string SprpNo { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Status { get; set; }
             [Key]
public int Id { get; set; }
        [Display(Name = "ED Note")]
        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(500)")]
        public string EdNote { get; set; }

        [Display(Name = "Hod Note")]

        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(500)")]
        public string HodNote { get; set; }
        [Display(Name = "Unit Head Note")]
        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(500)")]
        public string UnitNote { get; set; }
    }
}
