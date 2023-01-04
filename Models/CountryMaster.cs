using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class CountryMaster
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Contry Name")]
        [Required(ErrorMessage = "Contry Name Required")]
        public string Natinality { get; set; }
        [Display(Name = "Contry Code")]
        [Required(ErrorMessage = "Contry Code Required")]
        public string CountryCode { get; set; }
    }
}
