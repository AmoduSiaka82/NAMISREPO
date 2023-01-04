using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class byresignationorinvalidating
    {
        [Display(Name = "Date Terminated")]
        [Required(ErrorMessage = "Date Terminated Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime DateTerminated { get; set; }
        [Display(Name = "Pension or Contract")]
        [Required(ErrorMessage = "Pension Or Contract Required")]
        public string PensionOrContarct { get; set; }
        [Display(Name = "Pension Of")]
       
        [Range(1, 1000000000)]

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PensionOf { get; set; }
        
        [Range(1, 1000000000)]

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Grantuity Of")]
        [Required(ErrorMessage = "Grantuity Of Required")]
        public decimal GrantuityOf { get; set; }
        [Display(Name = "Contract Gratuity")]
        
        [Range(1, 1000000000)]

        [Column(TypeName = "decimal(18, 2)")]
        public decimal ContractGratuity { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime Date { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Dates { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Status { get; set; }
        [Display(Name = "SPRP No")]

        [Column(TypeName = "varchar(50)")]
        public string SprpNo { get; set; }

        public biodata bio { get; set; }
        [Key]
        public int Id { get; set; }
        [Display(Name = "Remark")]

        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(2000)")]
        public string EdNote { get; set; }

        [Display(Name = "Remark")]

        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(2000)")]
        public string HodNote { get; set; }
        [Display(Name = "Remark")]
        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(2000)")]
        public string UnitNote { get; set; }
    }
}
