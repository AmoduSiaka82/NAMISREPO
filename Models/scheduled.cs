using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class scheduled
    {
        [Display(Name = "Staff Name")]
        [Required(ErrorMessage = "Staff Name Required")]
        public string StaffName { get; set; }
       
        public string Department { get; set; }
        [Display(Name = "Unit")]
        [Required(ErrorMessage = "Unit Required")]
        public string Unit { get; set; }
        [Display(Name = "Schedule")]
        [Required(ErrorMessage = "Schedule Required")]
        public string Schedule { get; set; }
        public string UserID { get; set; }
        [Key]
        public int ID  { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        public string AllocatedBy { get; set; }
        [Display(Name = "Schedule Nature")]
        [Required(ErrorMessage = "Scheduled Nature Required")]
        public string ScheduledType { get; set; }
        [Display(Name = "Schedule Expiration")]
        [Required(ErrorMessage = "Schedule Expiration Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Expire { get; set; }
        public string Status { get; set; }
        
        public string Role { get; set; }
        [Display(Name = "Section Name")]
        public string SectionName { get; set; }

        public string Controllers { get; set; }

        public string Actions { get; set; }
        public string Description { get; set; }
        [Display(Name = "Section Role")]
        public string SectionRole { get; set; }
        public string AllocatedUserID { get; set; }
}
}
