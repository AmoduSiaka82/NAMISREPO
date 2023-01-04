using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class monthlyreturn
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
        [Display(Name = "Current Appointment")]
        public string CurrentAppointment { get; set; }
        [Display(Name = "Department")]
        public string Department { get; set; }
        [Display(Name = "Date of Current Appoint")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfCurrentAppointment { get; set; }
        [Display(Name = "Date Due For Confirmation")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime DateDue { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime DateF { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime DateD { get; set; }
        [Display(Name = "SPRP No")]

        [RegularExpression("^[0-9]*$", ErrorMessage = "SPRP No must be numeric")]


        [Column(TypeName = "varchar(50)")]
        public string SprpNo { get; set; }

        public biodata bio { get; set; }
        [Display(Name = "Grade Level")]
        public string GradeLevel { get; set; }
        [Display(Name = "Sation Name")]
        public string StationName { get; set; }
        [DataType(DataType.MultilineText)]
        public string Remark { get; set; }
        public string Dates { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime Date { get; set; }
        public string Status { get; set; }
        [Key]

        public int Id { get; set; }
        public string Yr { get; set; }
        public string Mnt { get; set; }
        public string Day { get; set; }
        public string YrC { get; set; }
        [Display(Name = "Gender")]

        public string Sex { get; set; }

        public string ReceiverID { get; set; }
        public string ReceiverID1 { get; set; }
        public string ReceiverID2 { get; set; }
        public string ReceiverID3 { get; set; }
        public string ReceiverID4 { get; set; }
        public string ConId { get; set; }

        [DataType(DataType.MultilineText)]
        public string Remark1 { get; set; }
        [DataType(DataType.MultilineText)]
        public string Remark2 { get; set; }
        [DataType(DataType.MultilineText)]
        public string Remark3 { get; set; }
        [DataType(DataType.MultilineText)]
        public string Remark4 { get; set; }
        public string UserID { get; set; }
        [Display(Name = "Propose Department")]
        public string PDepartment { get; set; }
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
        [Display(Name = "Highest Qualification")]
        public string HighestQualification { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime RDate { get; set; }
    }
}
