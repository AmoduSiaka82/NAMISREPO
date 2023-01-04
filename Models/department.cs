using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class department
    {
        [Key]      
        public int DeptID { get; set; }
        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "Department Name Required")]
        [Column(TypeName = "varchar(150)")]
        public string Department { get; set; }
       
    }
}
