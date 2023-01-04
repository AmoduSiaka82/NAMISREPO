using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class Leaves
    {
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Surname Must Start with Upper Case")]

        [Display(Name = "Surname")]

        public string Surname { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Middle Name Must Start with Upper Case")]

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "First Name Must Start with Upper Case")]

        [Display(Name = "First Name")]

        public string FirstName { get; set; }
        [Display(Name = "SPRP No")]

        [RegularExpression("^[0-9]*$", ErrorMessage = "SPRP No must be numeric")]
        
        public string SprpNo { get; set; }
        [Display(Name = "Gender")]

        public string Sex { get; set; }
        [Display(Name = "Department")]
        public string Department { get; set; }
        [Display(Name = "Leave Type")]
        public string LeaveType { get; set; }
        [Display(Name = "Start Date")]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime EndDate { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }
        [Display(Name = "Date")]
        public string Dates { get; set; }
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime Date { get; set; }
        [Display(Name = "Year")]
        public string Yr { get; set; }
        [Display(Name = "Months")]
        public string Mnt { get; set; }
        [Display(Name = "Day")]
        public string Day { get; set; }
        [Display(Name = "Body")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Title")]
        public string Addresse { get; set; }
        [Display(Name = "Recipient")]
        public string Salutation { get; set; }
        [Display(Name = "Id")]
        [Key]
        public string Id { get; set; }
        [Display(Name = "No Of days")]
        public string NoOfDays { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime EDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime SDate { get; set; }
        public string UserID { get; set; }
        [Display(Name = "Resume Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime ResumeDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime RDate { get; set; }
        [Display(Name = "Grade Level")]
        public string GradeLevel { get; set; }
        public string  Step { get; set; }
        [Display(Name = "Station Name")]
        public string StationName { get; set; }
        public string ReceiverID { get; set; }
        public string ReceiverID1 { get; set; }
        public string ReceiverID2 { get; set; }
        public string ReceiverID3 { get; set; }
        public string ReceiverID4 { get; set; }
        public string BoxId { get; set; }
        [DataType(DataType.MultilineText)]
        public string Remark { get; set; }
        [DataType(DataType.MultilineText)]
        public string Remark1 { get; set; }
        [DataType(DataType.MultilineText)]
        public string Remark2 { get; set; }
        [DataType(DataType.MultilineText)]
        public string Remark3 { get; set; }
        [DataType(DataType.MultilineText)]
        public string Remark4 { get; set; }
        [Display(Name = "Ref No")]
        public string RefNo { get; set; }
        public string Authorise { get; set; }
        [Display(Name = "Authorised By")]
        public string Authorisedby { get; set; }
        [Display(Name = "Sign For")]
        public string SignFor { get; set; }
        public string LStatus { get; set; }
    }
}
