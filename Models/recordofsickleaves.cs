using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class recordofsickleaves
    {
        [Display(Name = "Type Of Leave")]
        [Required(ErrorMessage = "Type Of Leave Required")]
        public string TypeOfLeave { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "From")]
        [Required(ErrorMessage = "From Required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime FrmDate { get; set; }
        [DataType(DataType.Date)]
        
        [Display(Name = "To Date")]
        [Required(ErrorMessage = "To Required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime ToDate { get; set; }
        [Display(Name = "No Of Days")]
        [Required(ErrorMessage = "No Of Days Required")]
        public string NoOfDays
        { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime Date { get; set; }
        [Display(Name = "File Page No")]
        [Required(ErrorMessage = "File Page No Required")]
        public string FilePageNo { get; set; }
    public string Dates { get; set; }
        [Display(Name = "SPRP No")]

        [Column(TypeName = "varchar(50)")]
        public string SprpNo { get; set; }

        public biodata bio { get; set; }
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
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
