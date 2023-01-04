using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class StationViewModel
    {
        [Display(Name = "Station Name")]
        [Required(ErrorMessage = "Station Name Required")]
        public string StationName { get; set; }
        [Key]
        public int StationID { get; set; }
    }
}
