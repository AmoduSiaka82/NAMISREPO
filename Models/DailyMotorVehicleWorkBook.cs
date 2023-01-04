using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NAMIS.Models
{
    public class DailyMotorVehicleWorkBook
    {
      [Display(Name = "Vehicle Plate No")]
        [Required(ErrorMessage = "Vehicle Plate No Required")]
        [Column(TypeName = "varchar(50)")]
        public string VehicleNo { get; set; }
        [Key]
        public int Id { get; set; }
        [Display(Name = "Tank Capacity")]
        [Required(ErrorMessage = "Tank Capacity Required")]
        [Column(TypeName = "varchar(150)")]
        public string TankCapacity { get; set; }
        [Display(Name = "Make")]
        [Required(ErrorMessage = "Make Required")]
        [Column(TypeName = "varchar(150)")]
        public string Make { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime Date { get; set; }
        [Display(Name = "Dates")]
        [Column(TypeName = "varchar(50)")]
        public string Dates { get; set; }
        [Display(Name = "Time In")]
        [Required(ErrorMessage = "Time In Required")]
        [DataType(DataType.Time)]
        [Column(TypeName = "varchar(50)")]
        public string TimeIn { get; set; }
        [Display(Name = "Time Out")]
        [Required(ErrorMessage = "Time Out Required")]
        [DataType(DataType.Time)]
        [Column(TypeName = "varchar(50)")]
        public string TimeOut { get; set; }
        [Display(Name = "Speedometer Out")]
        [Required(ErrorMessage = "Speedometer Out Required")]
        [Column(TypeName = "varchar(50)")]
        public string SpeedometerOut { get; set; }
        [Display(Name = "From")]
        [Required(ErrorMessage = "From Required")]
        [Column(TypeName = "varchar(50)")]
        public string Frm { get; set; }
        [Display(Name = "To")]
        [Required(ErrorMessage = "To Required")]
        [Column(TypeName = "varchar(50)")]
        public string Tos { get; set; }
        [Display(Name = "Speedometer Reads In")]
        [Required(ErrorMessage = "Speedometer Read In Required")]
        [Column(TypeName = "varchar(50)")]
        public string SpeedometerReadsIn { get; set; }
        [Display(Name = "Total Miles/Km Run")]
        [Required(ErrorMessage = "Total Miles/Km Run Required")]
        [Column(TypeName = "varchar(50)")]
        public string TotalMilesKmRun { get; set; }
        [Display(Name = "Petrol/Oil Received")]
        [Required(ErrorMessage = "Petrol/Oil Received Required")]
        [Column(TypeName = "varchar(50)")]
        public string PetrolOilReceived { get; set; }
        [Display(Name = "Authority for Journey")]
        [Required(ErrorMessage = "Authority for Journey Required")]
        [Column(TypeName = "varchar(550)")]
        public string AuthorityforJourney { get; set; }
        [Display(Name = "User Sign")]
        [Required(ErrorMessage = "User Sign Required")]
        [Column(TypeName = "varchar(250)")]
        public string UserSign { get; set; }
        [Display(Name = "Driver Name")]
        [Required(ErrorMessage = "Driver Name Required")]
        [Column(TypeName = "varchar(300)")]
        public string DriverName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string UserID { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string StationName { get; set; }
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
        public string DailyID { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Status { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Yr  { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Mnt  { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Day  { get; set; }
    }
}
