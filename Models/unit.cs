using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class unit
    {
        [Display(Name = "Unit Name")]
        [Required(ErrorMessage = "Unit Name Required")]
        public string UnitName { get; set; }
        [Display(Name = "Department")]
        [Required(ErrorMessage = "Department Required")]
        public string Department { get; set; }
        [Key]
        public int Id { get; set; }
    }
}
