using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class Memo
    {
        [DataType(DataType.MultilineText)]
        [Display(Name = "Body")]
        [Required(ErrorMessage = "Body Required")]
        [Column(TypeName = "varchar(5000)")]
        public string Body { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Sender")]
        [Required(ErrorMessage = "Sender Required")]
        [Column(TypeName = "varchar(500)")]
        public string Address { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title Required")]
        [Column(TypeName = "varchar(250)")]
        public string ReportTitle { get; set; }

        
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Status { get; set; }
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
        [Display(Name = "Station")]
        [Column(TypeName = "varchar(150)")]
        public string StationName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string UserID { get; set; }
        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(500)")]
        public string Remark { get; set; }

        [Display(Name = "Ref No:")]
        [Column(TypeName = "varchar(50)")]
        public string RefNo { get; set; }
        [Display(Name = "Recipient:")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Recipient Required")]
        [Column(TypeName = "varchar(350)")]
        public string Recipient { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Nspri { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string MemoTitle { get; set; }
        public string Date { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Dates { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string Authorise { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string SignFor { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string Copi { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Authorisedby { get; set; }
    }
}
