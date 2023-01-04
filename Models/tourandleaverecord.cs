using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class tourandleaverecord
    {
        [DataType(DataType.Date)]
        [Display(Name = "Date Started")]
        [Required(ErrorMessage = "Date Started Required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateStarted { get; set; }
        
        [Display(Name = "Gazette Notice No")]
        [Required(ErrorMessage = "Gazette Notice No Required")]
        public string GazetteNoticeNo { get; set; }
        [Display(Name = "Length Of Tour For Age")]
        [Required(ErrorMessage = "Length Of Tour For Age Required")]
        public string  LengthOfTourForAge { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Due For Leave")]
        [Required(ErrorMessage = "Date Due For Leave Required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateDueForLeave { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Departed On Leave")]
        [Required(ErrorMessage = "Date Departed On Leave Required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateDepartedOnLeave { get; set; }
        [Display(Name = "Gazette Notice Number")]
        [Required(ErrorMessage = "Gazette Notice Number Required")]
        public string GazetteNoticeNumber  { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date  Extension Granted")]
        [Required(ErrorMessage = "Date Extension Granted Required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateExtentionGranted { get; set; }
        [Display(Name = "Salary Rule For Extension")]
        [Required(ErrorMessage = "Salary Rule For Extention Required")]
        public string SalaryRuleForExtention { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Resume Duty")]
        [Required(ErrorMessage = "Date Resume Duty Required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateResumedDuty { get; set; }
        [Display(Name = "Passage By Sea Or Air To Uk")]
        [Required(ErrorMessage = "Passage By Sea Or Air To Uk Required")]
        public string PassageBySeaOrAirToUk { get; set; }
        [Display(Name = "Passage By Sea Or Air From Uk")]
        [Required(ErrorMessage = "Passage By Sea Or Air From Uk Required")]
        public string PassageBySeaOrAirFrmUk { get; set; }
        [Display(Name = "Resident Months")]
        [Required(ErrorMessage = "Resident Months Required")]
        public string ResidentMonths  { get; set; }
        [Display(Name = "Resident Days")]
        [Required(ErrorMessage = "Resident Days Required")]
        public string ResidentDays { get; set; }
        [Display(Name = "Leave Months")]
        [Required(ErrorMessage = "Leave Months Required")]
        public string LeaveMonths { get; set; }
        [Display(Name = "Leave Days")]
        [Required(ErrorMessage = "Leave Days Required")]
        public string LeaveDays { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        public string Dates { get; set; }
        [Display(Name = "SPRP No")]

        [Column(TypeName = "varchar(50)")]
        public string SprpNo { get; set; }

        public biodata bio { get; set; }

        public string Status { get; set; }
        [Key]
        public int Id { get; set; }
        [Display(Name = "Remark")]

        [DataType(DataType.MultilineText)]
        public string EdNote { get; set; }

        [Display(Name = "Remark")]

        [DataType(DataType.MultilineText)]
        public string HodNote { get; set; }
        [Display(Name = "Remark")]
        [DataType(DataType.MultilineText)]
        public string UnitNote { get; set; }
    }
}
