using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class Box
    {
        [Display(Name = "Subject")]
        [Column(TypeName = "varchar(200)")]
        public string  Subject { get; set; }
        [Display(Name = "Description")]
        [Column(TypeName = "varchar(500)")]
        public string  Description { get; set; }
        [Display(Name = "Controller")]
        [Column(TypeName = "varchar(150)")]
        public string  Controllers { get; set; }
        [Display(Name = "Actions")]
        [Column(TypeName = "varchar(150)")]
        public string Actions { get; set; }
        [Display(Name = "ID")]
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Status { get; set; }
        public string Dates { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime Date { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Dy { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Mnt { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Yr { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string ReceiverID { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Attachement { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string ReceiverID1 { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string ReceiverID2 { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string ReceiverID3 { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string ReceiverID4 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Status1 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Status2 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Status3 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Status4 { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string IdNo { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string UserID { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string UAction { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string UController { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string UserStatus { get; set; }
    }
}
