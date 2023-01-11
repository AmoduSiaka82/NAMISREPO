using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class ManPower
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        [Display(Name = "Cadre")]
        [Column(TypeName = "varchar(200)")]
        public string Cadre { get; set; }
        [Display(Name = "Grade Level")]
        [Column(TypeName = "varchar(50)")]
        public string GradeLevel { get; set; }
        [Display(Name = "Staff In Post")]
        [Range(0, 1000000000)]

        [Column(TypeName = "decimal(18, 2)")]
        public decimal StaffInPost { get; set; }
        [Display(Name = "No due")]
        [Range(0, 1000000000)]

        [Column(TypeName = "decimal(18, 2)")]
        public decimal NoDue { get; set; }

        [Display(Name = "Approved")]
        [Range(0, 1000000000)]

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Approved { get; set; }
        [Display(Name = "Done By")]
        [Column(TypeName = "varchar(200)")]
        public string DoneBy { get; set; }
        [Display(Name = "Station")]
        [Column(TypeName = "varchar(200)")]
        public string StationName { get; set; }
        [Display(Name = "Status")]
        [Column(TypeName = "varchar(50)")]
        public string Status { get; set; }
        [Display(Name = "Reciever ID")]
        [Column(TypeName = "varchar(150)")]
        public string RecieverId { get; set; }
        [Display(Name = "Box ID")]
        [Column(TypeName = "varchar(150)")]
        public string BoxId { get; set; }
    }
}
