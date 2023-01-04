using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class TrainingAndStudy
    {
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Sprp No")]
        [Column(TypeName = "varchar(50)")]
        public string SprpNo { get; set; }

        public biodata bio { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        public string Dates { get; set; }
        [Display(Name = "Time")]
        public string Time { get; set; }
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime SDate { get; set; }
        public string SDates { get; set; }
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EDate { get; set; }
        public string EDates { get; set; }
        public string NoOfDays { get; set; }
        public string UserID { get; set; }
        public string Status { get; set; }
        [Display(Name = "Qualification In View")]
        public string QualificationInView { get; set; }
        [Key]
        public int Id { get; set; }
        public string ReceiverID { get; set; }
        public string ReceiverID1 { get; set; }
        public string ReceiverID2 { get; set; }
        public string ReceiverID3 { get; set; }
        public string ReceiverID4 { get; set; }
        public string ConId { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Training Description")]
        public string TrainingDescription { get; set; }
        public string Yr { get; set; }
        public string Mnt { get; set; }
        public string Day { get; set; }
        [Display(Name = "Station")]
        public string StationName { get; set; }
        public string Department { get; set; }
        public string GradeLevel { get; set; }
        public string Step { get; set; }
        [Display(Name = "Highest Qualification")]
        public string HighestQualification { get; set; }
        public string Body { get; set; }
        [Display(Name = "Ref No")]
        public string RefNo { get; set; }
        public string Authorise { get; set; }
        public string Authorisedby { get; set; }
        public string SignFor { get; set; }
        public string Address { get; set; }
        public string Recipient { get; set; }
        public string LStatus { get; set; }
        public string Title { get; set; }
    }
}

