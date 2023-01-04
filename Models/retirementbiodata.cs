using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class retirementbiodata
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
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string SprpNo { get; set; }

        public biodata bio { get; set; }
        [Display(Name = "Gender")]

        public string Sex { get; set; }
        [Display(Name = "Decoration")]

        public string Decoration { get; set; }
        [Display(Name = "Nationality")]

        public string Natinality { get; set; }
        [Display(Name = "Date Of First Appointment")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfFirstAppointment { get; set; }
        [Display(Name = "Date Of First Arrival")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfFirstArrival { get; set; }

        [Display(Name = "LGA Of Origin")]

        public string LGAOrigin { get; set; }
        [Display(Name = "Date Of Birth")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Place Of Birth")]

        public string PlaceOfBirth { get; set; }
        [Display(Name = "Checked By")]

        public string CheckBy { get; set; }
        [Display(Name = "Proof")]
        public string Proof { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        public string Dates { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        [Display(Name = "Home Address")]

        public string HomeAddress { get; set; }
        [Display(Name = "Department")]

        public string Department { get; set; }
        [Display(Name = "Geographical Location")]

        public string GeographicalLocation { get; set; }
        [Display(Name = "Substansive Appointment")]

        public string SubstansiveAppointment { get; set; }
        [Display(Name = "Date Of Appointment")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string DateOfAppointment { get; set; }
        [Display(Name = "Term of Engagement")]

        public string TermsOfEngagement { get; set; }
        [Display(Name = "Current Appointment")]


        public string CurrentAppointment { get; set; }
        [Display(Name = "State Of Origin")]

        public string StateOfOrigin { get; set; }
        [Display(Name = "Date of Current Appointment")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfCurrentAppointment { get; set; }

        [Display(Name = "Station Name")]


        public string StationName { get; set; }

        [Display(Name = "Carder")]


        public string Carder { get; set; }
        [Display(Name = "ED Note")]

        [DataType(DataType.MultilineText)]
        public string EdNote { get; set; }

        [Display(Name = "Hod Note")]

        [DataType(DataType.MultilineText)]
        public string HodNote { get; set; }
        [Display(Name = "Unit Head Note")]
        [DataType(DataType.MultilineText)]
        public string UnitNote { get; set; }
        [Display(Name = "Highest Qualification")]
        public string HighestQualification { get; set; }
        [Display(Name = "Grade Level")]
        public string GradeLevel { get; set; }
        [Display(Name = "Step")]
        public string Step { get; set; }
        [Display(Name = "Training Status")]
        public string TrainingStatus { get; set; }
        [Display(Name = "Qualification In View")]
        public string QualificationInView { get; set; }
        [Display(Name = "Promotion Status")]
        public string ProStatus { get; set; }
        [Display(Name = "Retirment Status")]
        public string RStatus { get; set; }
        [Display(Name = "Promotion Year")]
        public string ProYr { get; set; }
        [Display(Name = "Retirment Year")]

        public string RYr { get; set; }
        public string AppointmentStatus { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ConfirmationDate { get; set; }
        public string ConfirmationYr { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfRetirement { get; set; }
        public string IPPISNO { get; set; }
        public DateTime DateOfPromotion { get; set; }
        public string NHISNO { get; set; }
        public string PhoneNo { get; set; }
        public string EmailID { get; set; }
        public string NHFNO { get; set; }
        public string RId { get; set; }
        public int Id { get; set; }
        public string ReceiverID { get; set; }
        public string ReceiverID1 { get; set; }
        public string ReceiverID2 { get; set; }
        public string ReceiverID3 { get; set; }
        public string ReceiverID4 { get; set; }
        public string ConId { get; set; }
        [Display(Name = "Exit Mode")]
        public string RMode { get; set; }
        public string PFA { get; set; }
        [Display(Name = "Pin No")]
        public string PinNo { get; set; }
        [Display(Name = "Ref No")]
        public string RefNo { get; set; }
        public string Authorise { get; set; }
        public string Authorisedby { get; set; }
        public string SignFor { get; set; }
        public string Address { get; set; }
        public string Recipient { get; set; }
        public string LStatus { get; set; }
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
        [DataType(DataType.MultilineText)]
        public string Remark { get; set; }
        
    }
}
