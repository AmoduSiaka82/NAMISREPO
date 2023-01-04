using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class educations
    {
     [Display(Name = "Type Of School")]
     [Required(ErrorMessage = "Type Of School Required")]
        [Column(TypeName = "varchar(250)")]
        public string TypeOfSchool { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "From:")]
        [Required(ErrorMessage = "From Required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime FrmDate  { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "To:")]
        [Required(ErrorMessage = "To Required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime ToDate  { get; set; }
        
        [Display(Name = "Checked By")]
        [Column(TypeName = "varchar(500)")]

        public string CheckedBy { get; set; }
    public string Dates  { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime Date  { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Status  { get; set; }
    [Key]
        public int   Id { get; set; }
        [Display(Name = "SPRP No")]

        [Column(TypeName = "varchar(50)")]
        public string SprpNo { get; set; }

        public biodata bio { get; set; }
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
