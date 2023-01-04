using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class CareerProgression
    {
        [Display(Name = "Promotion Letter")]
        [Column(TypeName = "varchar(250)")]
        public string AttachFile { get; set; }
        [Display(Name = "SPRP No")]
        [Required(ErrorMessage = "SPRP NO Required")]
        [Column(TypeName = "varchar(50)")]
        public string SprpNo { get; set; }

        public biodata bio { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime Date { get; set; }
        [Display(Name = "Promotion Date")]
       // [Required(ErrorMessage = "Promotion Date Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Column(TypeName = "varchar(50)")]
        public string Dates { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Yr { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Mnt { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string UserID { get; set; }
        [Display(Name = "Station Name")]
        [Column(TypeName = "varchar(150)")]
        public string StationName { get; set; }
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Status { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string CareerId { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string  Surname  { get; set; }
        [Display(Name = "Middle Name")]
        [Column(TypeName = "varchar(250)")]
        public string MiddleName  { get; set; }
        [Display(Name = "First Name")]
        [Column(TypeName = "varchar(250)")]
        public string FirstName  { get; set; }
        [Display(Name = "Date of First Appointment")]
        public DateTime DateOfFirstAppointment  { get; set; }
        [Display(Name = "Current Appointment")]
        public string CurrentAppointment  { get; set; }
        [Display(Name = "Date of Current Appointment")]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime DateofCurrentAppointment  { get; set; }
        [Display(Name = "Grade Level")]
        [Column(TypeName = "varchar(50)")]
        public string GradeLevel  { get; set; }
        [Display(Name = "Step")]
        [Column(TypeName = "varchar(50)")]
        public string Step { get; set; }
        [Display(Name = "Propose Rank")]
        [Column(TypeName = "varchar(50)")]
        public string ProposeRank  { get; set; }
        [Display(Name = "Propose Grade")]
        [Column(TypeName = "varchar(50)")]
        public string ProposeGrade  { get; set; }
        [Display(Name = "Propose Step")]
        [Column(TypeName = "varchar(50)")]
        public string ProposeStep { get; set; }
        
        [Display(Name = "Body")]
        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(5000)")]
        public string Body { get; set; }
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
        
        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(500)")]
        public string Remark { get; set; }
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
        public string Day { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Department { get; set; }


        [Display(Name = "Ref No")]
        [Column(TypeName = "varchar(100)")]
        public string RefNo { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Authorise { get; set; }
        [Display(Name = "Authorised By")]
        [Column(TypeName = "varchar(500)")]
        public string Authorisedby { get; set; }
        [Display(Name = "Sign For")]
        [Column(TypeName = "varchar(500)")]
        public string SignFor { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Address { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Recipient { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string LStatus { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Title { get; set; }

    }
}
