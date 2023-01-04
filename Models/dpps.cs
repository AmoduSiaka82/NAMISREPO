using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class dpps
    {
        [Display(Name = "Previous Employer")]
        [Required(ErrorMessage = "Previous Employer Required")]
        [Column(TypeName = "varchar(250)")]
        public string Psemployer { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "From")]
        [Required(ErrorMessage = "From Required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime FrmDate { get; set; }
        [Required(ErrorMessage = "To Required")]
        [DataType(DataType.Date)]
        [Display(Name = "To")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime ToDate { get; set; }
        [Display(Name = "SPRP No")]
        
        [Column(TypeName = "varchar(50)")]
        public string SprpNo { get; set; }

        public biodata bio { get; set; }
        [Key]
        public int Id { get; set; }
        [Display(Name = "File Page Ref")]
        [Required(ErrorMessage = "File Page Ref Required")]
        [Column(TypeName = "varchar(150)")]
        public string FilePageRef { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string Checkedby { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Status { get; set; }
        [Display(Name = "Remark")]

        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(500)")]
        public string EdNote { get; set; }
        [Column(TypeName = "varchar(500)")]

        [Display(Name = "Remark")]
        [DataType(DataType.MultilineText)]

        public string HodNote { get; set; }
        [Display(Name = "Remark")]
        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(500)")]
        public string UnitNote { get; set; }
    }
}
