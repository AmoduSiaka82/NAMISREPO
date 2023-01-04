using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class itstudent
    {
        [Required(ErrorMessage = "Surname Required")]
        [Display(Name = "Surname")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Surname Must Start with Upper Case")]
        public string Surname { get; set; }
        
        [Display(Name = "Middle Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Middle Name Must Start with Upper Case")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "First Name Required")]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "First Name Must Start with Upper Case")]
        public string FirstName { get; set; }
        [Display(Name = "Matric No")]
        [Required(ErrorMessage = "Matric No Required")]
        public string SprpNo { get; set; }
        public DateTime Date { get; set; }
        public string Dates { get; set; }
        [Display(Name = "Time")]
        public string Time { get; set; }
        [Required(ErrorMessage = "Start Date Required")]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime SDate { get; set; }
        public string SDates { get; set; }
        [Display(Name = "Date Of Completion")]
        [Required(ErrorMessage = "Completion Date Required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime EDate { get; set; }
        public string EDates { get; set; }
        public string NoOfDays { get; set; }
        public string UserID { get; set; }
        public string Status { get; set; }
        [Display(Name = "Qualification In View")]
        [Required(ErrorMessage = "Qualification In View Required")]
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
        [Required(ErrorMessage = "Training Description Required")]
        public string TrainingDescription { get; set; }
        public string Yr { get; set; }
        public string Mnt { get; set; }
        public string Day { get; set; }
        [Display(Name = "Email ID")]
        [Required(ErrorMessage = "Email ID Required")]
        public string EmailID { get; set; }
        [Required(ErrorMessage = "Phone No Required")]
        [Display(Name = "Phone No")]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage = "School Required")]
        [Display(Name = "School")]
        public string School { get; set; }
        [Display(Name = "Contact Address")]
        [Required(ErrorMessage = "Contact Address Required")]
        public string Contact { get; set; }
        public string HighestQualification { get; set; }
        [Display(Name = "Body")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
        [Required(ErrorMessage = "Department Required")]
        public string Department { get; set; }
        [Display(Name = "Station")]
        [Required(ErrorMessage = "Station Required")]
        public string StationName { get; set; }
        [Display(Name = "Ref No")]
        public string RefNo { get; set; }
        public string Authorise { get; set; }
        public string Authorisedby { get; set; }
        public string SignFor { get; set; }
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        public string Recipient { get; set; }
        public string LStatus { get; set; }
        public string Title { get; set; }

    }
}

