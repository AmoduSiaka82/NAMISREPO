using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class bydeaths
    {
        [Display(Name = "Date of Death")]
        [Required(ErrorMessage = "Date Of Death Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime DateOfDeath { get; set; }
        [Display(Name = "Gratuity Paid to Estate")]
        [Required(ErrorMessage = "Gratuity Paid To Estate Required")]
        
        [Range(1, 1000000000)]

        [Column(TypeName = "decimal(18, 2)")]
        public decimal GratuityPaidToEstate  { get; set; }
        [Display(Name = "Widow Pension Paid")]
        [Required(ErrorMessage = "Widow Pension Paid Required")]
        
        [Range(1, 1000000000)]

        [Column(TypeName = "decimal(18, 2)")]
        public decimal WindowsPensionPaid { get; set; }
        [Display(Name = "Orphans Pension Paid")]
        [Required(ErrorMessage = "Orphans Pension Required")]
        
        [Range(1, 1000000000)]

        [Column(TypeName = "decimal(18, 2)")]
        public decimal OrphansPensionPaid { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime Date { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Dates  { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Status { get; set; }
        
        [Column(TypeName = "varchar(50)")]
        public string SprpNo { get; set; }

        public biodata bio { get; set; }
        [Key]
        public int ID { get; set; }
        [Display(Name = "Remark")]

        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(5000)")]
        public string EdNote { get; set; }

        [Display(Name = "Remark")]

        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(5000)")]
        public string HodNote { get; set; }
        [Display(Name = "Remark")]
        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(5000)")]
        public string UnitNote { get; set; }
    }
}
