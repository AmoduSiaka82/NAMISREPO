using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class biodata
    {
        // migrationBuilder.Sql("SET default_storage_engine=INNODB");
        //migrationBuilder.Sql("SET default_storage_engine=INNODB");
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Surname Must Start with Upper Case")]
        [Column(TypeName = "varchar(500)")]
        [Display(Name = "Surname")]
        [Required]
        public string Surname { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Middle Name Must Start with Upper Case")]
        [Column(TypeName = "varchar(500)")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "First Name Must Start with Upper Case")]
        [Required]
        [Display(Name = "First Name")]
        [Column(TypeName = "varchar(500)")]
        public string FirstName { get; set; }
        [Display(Name = "SPRP No")]
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "SPRP No must be numeric")]
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string SprpNo { get; set; }
        [Display(Name = "Gender")]
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Sex { get; set; }
        [Display(Name = "Title")]
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Decoration { get; set; }
        [Display(Name = "Nationality")]
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Natinality { get; set; }
        [Display(Name = "DOFA")]
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
        public DateTime DateOfFirstAppointment { get; set; }
        [Display(Name = "DOF Arrival")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfFirstArrival { get; set; }

        [Display(Name = "LGA Of Origin")]
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string LGAOrigin { get; set; }
        [Display(Name = "DOB")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Place Of Birth")]
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string PlaceOfBirth { get; set; }
        [Display(Name = "Checked By")]
        [Column(TypeName = "varchar(500)")]
        public string CheckBy { get; set; }
        [Display(Name = "Proof")]
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Proof { get; set; }
        public DateTime Date { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Dates { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Time { get; set; }
        public string Status { get; set; }
        [Display(Name = "Home Address")]
        [Required]
        [Column(TypeName = "varchar(5000)")]
        public string HomeAddress { get; set; }
        [Display(Name = "Department")]
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Department { get; set; }
        [Display(Name = "Geographical Location")]
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string GeographicalLocation { get; set; }
        [Display(Name = "Substansive Appointment")]
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string SubstansiveAppointment { get; set; }
        [Display(Name = "DOA")]        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string DateOfAppointment { get; set; }
        [Display(Name = "Term of Engagement")]
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string TermsOfEngagement { get; set; }
        [Display(Name = "Current Appointment")]
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string CurrentAppointment { get; set; }
        [Display(Name = "State Of Origin")]
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string StateOfOrigin { get; set; }
        [Display(Name = "DOCA")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfCurrentAppointment { get; set; }

        [Display(Name = "Station Name")]

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string StationName { get; set; }

        [Display(Name = "Cadre")]
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Carder { get; set; }
        [Display(Name = "Remark")]

        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(500)")]
        public string EdNote { get; set; }

        [Display(Name = "Rmark")]

        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(500)")]
        public string HodNote { get; set; }
        [Display(Name = "Remark")]
        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(500)")]
        public string UnitNote{ get; set; }
        [Display(Name = "Highest Qualification")]
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string HighestQualification { get; set; }
        [Display(Name = "Grade Level")]
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string GradeLevel { get; set; }
        [Display(Name = "Step")]
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Step { get; set; }
        [Display(Name = "Training Status")]
        [Column(TypeName = "varchar(50)")]
        public string TrainingStatus { get; set; }
        [Display(Name = "Qualification In View")]
        [Column(TypeName = "varchar(50)")]
        public string QualificationInView { get; set; }
        [Display(Name = "Promotion Status")]
        [Column(TypeName = "varchar(20)")]
        public string ProStatus { get; set; }
        [Display(Name = "Retirment Status")]
        [Column(TypeName = "varchar(20)")]
        public string RStatus { get; set; }
        [Display(Name = "Promotion Year")]
        [Column(TypeName = "varchar(20)")]
        public string ProYr { get; set; }
        [Display(Name = "Retirment Year")]
        [Column(TypeName = "varchar(20)")]
        public string RYr { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string AppointmentStatus { get; set; }
        [Display(Name = "EDOC")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ConfirmationDate { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string ConfirmationYr  { get; set; }
        [Display(Name = "EDOR")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfRetirement { get; set; }
        [Display(Name = "IPPIS No")]
        [Column(TypeName = "varchar(50)")]
        public string IPPISNO { get; set; }
        [Display(Name = "EDOP")]
        public DateTime DateOfPromotion { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string NHISNO { get; set; }
        [Display(Name = "Phone No")]
        [Column(TypeName = "varchar(50)")]
        public string PhoneNo { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string EmailID { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string NHFNO { get; set; }
        [Display(Name = "Exit Mode")]
        [Column(TypeName = "varchar(50)")]
        public string RMode { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string PFA { get; set; }
        [Display(Name = "Pin No")]
        [Column(TypeName = "varchar(150)")]
        public string PinNo { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfResumetion { get; set; }
    }
}
