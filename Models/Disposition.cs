using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class Disposition
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(500)")]
        [Display(Name = "Surname")]
        [Required]
        public string Surname { get; set; }

        [Column(TypeName = "varchar(500)")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [Column(TypeName = "varchar(500)")]
        public string FirstName { get; set; }
        [Display(Name = "SPRP No")]
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string SprpNo { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        [Display(Name = "Rank")]
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Rank { get; set; }
        [Display(Name = "Old Step")]
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string OStep { get; set; }
        [Display(Name = "New Step")]
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string NStep { get; set; }
        [Display(Name = "Old Sal")]
        [Required]
        [Range(1, 1000000000)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OldSal { get; set; }
        [Display(Name = "New Sal")]
        [Required]
        [Range(1, 1000000000)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal NewSal { get; set; }
        [Display(Name = "State Of Origin")]
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string StateOfOrigin { get; set; }
        [Display(Name = "DOFA")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
        public DateTime DateOfFirstAppointment { get; set; }
        [Display(Name = "DOCA")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfCurrentAppointment { get; set; }

        [Display(Name = "Station Name")]

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string StationName { get; set; }

    }
}
