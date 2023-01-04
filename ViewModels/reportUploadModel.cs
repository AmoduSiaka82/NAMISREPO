using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.ViewModels
{
    public class reportUploadModel
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
        [NotMapped]
        [Display(Name = "File")]
        [Required(ErrorMessage = "Report Required")]
        public List<IFormFile> ReportFile { get; set; }
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
        public string ReceiverID { get; set; }
        public string ReceiverID1 { get; set; }
        public string ReceiverID2 { get; set; }
        public string ReceiverID3 { get; set; }
        public string ReceiverID4 { get; set; }
        public string ConId { get; set; }
        [Display(Name = "Ref No:")]
        [Required(ErrorMessage = "Ref No Required")]
        public string RefNo { get; set; }
        [Display(Name = "Recipient:")]
        [Required(ErrorMessage = "Recipient Required")]
        public string Recipient { get; set; }
    }
}
