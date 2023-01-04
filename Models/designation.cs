using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class designation
    {
        [Display(Name = "Designation Name")]
        [Required(ErrorMessage = "Designation Name Required")]
        [Column(TypeName = "varchar(150)")]
        public string Decoration { get; set; }
        [Key]
       
        public int DesignationID { get; set; }
        
        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "Department Name Required")]
        [Column(TypeName = "varchar(50)")]
        public string DeptID { get; set; }
        [Display(Name = "Cadre")]
        [Required(ErrorMessage = "Cadre Required")]
        [Column(TypeName = "varchar(50)")]
        public string Cadre { get; set; }
    }
}
