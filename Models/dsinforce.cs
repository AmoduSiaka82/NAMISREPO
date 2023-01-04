using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class dsinforce
    {
      
        [Display(Name = "Arm of Service")]
        [Required(ErrorMessage = "Arm of Service Required")]
        [Column(TypeName = "varchar(250)")]
        public string ArmOfService { get; set; }
        [Display(Name = "Service No")]
        [Required(ErrorMessage = "Service No Required")]
        [Column(TypeName = "varchar(50)")]
        public string ServiceNo { get; set; }
        [Display(Name = "Reason For Leave")]
        [Required(ErrorMessage = "Reason For Leave Required")]
        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(500)")]
        public string ReasonForLeave { get; set; }
        [Display(Name = "Last Unit")]
        [Required(ErrorMessage = "Last Unit Required")]
        [Column(TypeName = "varchar(150)")]
        public string LastUnit { get; set; }
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
        public int ID { get; set; }
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
