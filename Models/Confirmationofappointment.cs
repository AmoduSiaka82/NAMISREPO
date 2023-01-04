using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class Confirmationofappointment
    {
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Surname Must Start with Upper Case")]

        [Display(Name = "Surname")]
        [Column(TypeName = "varchar(200)")]
        public string Surname { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Middle Name Must Start with Upper Case")]

        [Display(Name = "Middle Name")]
        [Column(TypeName = "varchar(200)")]
        public string MiddleName { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "First Name Must Start with Upper Case")]

        [Display(Name = "First Name")]
        [Column(TypeName = "varchar(200)")]
        public string FirstName { get; set; }
        [Display(Name = "Current Appointment")]
        [Column(TypeName = "varchar(250)")]
        public string CurrentAppointment { get; set; }
    [Display(Name = "Department")]
        [Column(TypeName = "varchar(150)")]
        public string Department { get; set; }
        [Display(Name = "Date of First Appoint")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime DateOfFirstAppointment { get; set; }
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
        [Column(TypeName = "varchar(100)")]
        public string GradeLevel { get; set; }
        [Display(Name = "Station Name")]
        [Column(TypeName = "varchar(150)")]
        public string StationName { get; set; }
        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(500)")]
        public string Remark { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Dates { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime Date { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Status { get; set; }
            [Key]

        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Yr { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Mnt { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Day { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string YrC { get; set; }
        [Display(Name = "Gender")]
        [Column(TypeName = "varchar(20)")]
        public string Sex { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string ReceiverID { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string ReceiverID1 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string ReceiverID2 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string ReceiverID3 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string ReceiverID4 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string ConId { get; set; }
     
        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(500)")]
        public string Remark1 { get; set; }
        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(500)")]
        public string Remark2 { get; set; }
        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(500)")]
        public string Remark3 { get; set; }
        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(500)")]
        public string Remark4 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string UserID { get; set; }
        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(5000)")]
        public string Body { get; set; }
        [Display(Name = "Ref No")]
        [Column(TypeName = "varchar(50)")]
        public string RefNo { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Authorise { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Authorisedby { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string SignFor { get; set; }
        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(500)")]
        public string Address { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Recipient { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string LStatus { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Title { get; set; }
    }
}
