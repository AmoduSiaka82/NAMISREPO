using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class MinuteRegister
    {
        [Display(Name = "Minute Title")]
        [Required(ErrorMessage = "Minute Title Required")]
        [DataType(DataType.MultilineText)]
        public string MinuteTitle { get; set; }
        [Display(Name = "ATTENDANCE")]
        [Required(ErrorMessage = "Attendance Required")]
        [DataType(DataType.MultilineText)]
        public string Attendance { get; set; }
        [Display(Name = "Serial No")]
        [Required(ErrorMessage = "Serial No Required")]
        public string MinuteNo { get; set; }
        [Key]
        public string Id { get; set; }
        public string Status { get; set; }
        public string UserID { get; set; }
}
}
