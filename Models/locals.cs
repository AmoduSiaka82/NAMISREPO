using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class locals
    {
        [Key]
    public int local_id { get; set; }
        [Display(Name = "State Name")]
        [Required(ErrorMessage = "State Name Required")]
        public int state_id { get; set; }
    
        [Display(Name = "City Name")]
        [Required(ErrorMessage = "City Name Required")]
        [Column(TypeName = "varchar(150)")]
        public string LGAOrigin { get; set; }
    }
}
