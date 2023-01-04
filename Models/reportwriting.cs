using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class reportwriting
    {
        [DataType(DataType.MultilineText)]
        [Display(Name = "Body")]
        [Required(ErrorMessage = "Body Required")]
        public string Body { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address Required")]
        public string Address { get; set; }
        
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title Required")]
        public string ReportTitle { get; set; }
        
        [Display(Name = "File")]
        [Required(ErrorMessage = "Report File Required")]
        public string ReportFile { get; set; } 
        [Key]
        public string Id { get; set; }
        public string Status { get; set; }
        public string ReceiverID { get; set; }
        public string ReceiverID1 { get; set; }
        public string ReceiverID2 { get; set; }
        public string ReceiverID3 { get; set; }
        public string ReceiverID4 { get; set; }
        public string ConId { get; set; }
        [Display(Name = "Station")]
        public string StationName { get; set; }
        public string UserID { get; set; }
        [DataType(DataType.MultilineText)]
        public string Remark { get; set; }
        [Display(Name = "Ref No:")]
        public string RefNo { get; set; }
        [Display(Name = "Recipient:")]
        [DataType(DataType.MultilineText)]
        public string Recipient { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime Date { get; set; }
        public string Dates { get; set; }
        public string Authorise { get; set; }
        public string SignFor { get; set; }
        public string Copi { get; set; }
        public string Authorisedby { get; set; }

    }
}
