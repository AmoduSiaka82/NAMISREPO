using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace NAMIS.Models
{
    public class VehicleRecord
    {
        [Display(Name = "Vehicle Plate No")]
        [Required(ErrorMessage = "Vehicle Plate No Required")]
        public string VehicleNo { get; set; }
        [Key]
        public int Id { get; set; }
        [Display(Name = "Tank Capacity")]
        [Required(ErrorMessage = "Tank Capacity Required")]
        public string TankCapacity { get; set; }
        [Display(Name = "Make")]
        [Required(ErrorMessage = "Make Required")]
        public string Make { get; set; }
    }
}
