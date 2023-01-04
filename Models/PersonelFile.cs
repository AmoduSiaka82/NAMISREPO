using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class PersonelFile
    {
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "First Name")]
        public string FistName { get; set; }
        [Display(Name = "Sprp No")]
        [Column(TypeName = "varchar(50)")]
        public string SprpNo { get; set; }

        public biodata bio { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime Date { get; set; }
        public string Dates { get; set; }
        [Display(Name = "Time")]
        public string Time { get; set; }
        [Display(Name = "EXpected Date Of Return")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime ExpDate { get; set; }
        public string ExpDates { get; set; }
        public string UserID { get; set; }
        public string Status { get; set; }
        [Display(Name = "File Destination")]
        public string DestinationName { get; set; }
        [Key]
        public int ID { get; set; }
        public string ReceiverID { get; set; }
        public string ReceiverID1 { get; set; }
        public string ReceiverID2 { get; set; }
        public string ReceiverID3 { get; set; }
        public string ReceiverID4 { get; set; }
        public string ConId { get; set; }
        [DataType(DataType.MultilineText)]
        public string Remark { get; set; }
        public string Yr { get; set; }
        public string Mnt { get; set; }
        public string Day { get; set; }
        [Display(Name = "Station")]
        public string StationName { get; set; }
        public string Department { get; set; }
        [Display(Name = "Officer Name")]
        [Column(TypeName = "varchar(1000)")]
        public string YourName { get; set; }
    }
}
