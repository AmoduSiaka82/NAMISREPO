using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class bytransfers
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date of Transfer")]
        public DateTime DateOfTransfer { get; set; }
        [Display(Name = "Pension or Contract")]
        public string PensionOrContarct { get; set; }
        [Display(Name = "Aggregate Service In Nigeria Years")]
        [Range(0, 1000000000)]

        [Column(TypeName = "decimal(18, 2)")]
        public decimal AggregateServiceInNigeriaYrs { get; set; }
        [Display(Name = "Aggregate Service In Nigeria Months")]
        [Range(0, 1000000000)]

        [Column(TypeName = "decimal(18, 2)")]
        public decimal AggregateServiceInNigeriaMos { get; set; }
        [Display(Name = "Aggregate Service In Nigeria Days")]
        [Range(0, 1000000000)]

        [Column(TypeName = "decimal(18, 2)")]
        public decimal AggregateServiceInNigeriaDays { get; set; }
        [Display(Name = "Aggregate Salary In Nigeria")]
        
        [Range(1, 1000000000)]

        [Column(TypeName = "decimal(18, 2)")]
        public decimal AggregateSalaryInNigeria  { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Status { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime Date   { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Dates { get; set; }
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
