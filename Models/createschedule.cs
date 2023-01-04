using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class createschedule
    {
        [Display(Name = "Schedule Name")]
        [Required(ErrorMessage = "Schedule Name Required")]
        [Column(TypeName = "varchar(200)")]
        public string ScheduledName { get; set; }
        [Key]
        public int Id { get; set; }
        [Display(Name = "Department")]
        [Required(ErrorMessage = "Department Required")]
        [Column(TypeName = "varchar(150)")]
        public string Department { get; set; }
        [Display(Name = "Unit")]
        [Required(ErrorMessage = "Unit Required")]
        [Column(TypeName = "varchar(150)")]
        public string Unit { get; set; }
        [Display(Name = "For Who")]
        [Column(TypeName = "varchar(500)")]
        public string ForWho { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Controllers { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Actions { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Description { get; set; }
}
}
