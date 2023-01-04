using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class states
    {
        [Key]
        public int state_id { get; set; }
        [Display(Name = "State Name")]
        [Required(ErrorMessage = "State Name Required")]
        public string StateOfOrigin { get; set; }
        [Display(Name = "Country Name")]
        [Required(ErrorMessage = "Country Name Required")]
        public int CountryId { get; set; }
    }
}
