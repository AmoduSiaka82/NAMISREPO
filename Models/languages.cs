using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class languages
    {
        [Display(Name = "Language")]
        [Required(ErrorMessage = "Language Required")]
        [Column(TypeName = "varchar(150)")]
        public string Language { get; set; }
        [Display(Name = "Spoken")]
        [Required(ErrorMessage = "Spoken Required")]
        [Column(TypeName = "varchar(150)")]
        public string Spoken { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Written { get; set; }
        [Display(Name = "Exam Qaulified")]
        [Required(ErrorMessage = "Exam Qaulified Required")]
        [Column(TypeName = "varchar(150)")]
        public string ExamQualified { get; set; }
        [Display(Name = "Checked By")]
        [Column(TypeName = "varchar(300)")]
        public string CheckedBy  { get; set; }
      public string Dates { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime Date { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Status { get; set; }



        [Key]
        public int ID { get; set; }
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
