using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class Visitor
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name Required")]
        public string VisitorName { get; set; }
        [Key]
        public int Id { get; set; }
        [Display(Name = "Phone No")]
        [Required(ErrorMessage = "Phone No Required")]
        public string PhoneNo { get; set; }

        [Display(Name = "Email ID")]
        [Required(ErrorMessage = "Email ID Required")]
        public string EmailID { get; set; }
        [Display(Name = "Purpose Of Visit")]
        [Required(ErrorMessage = "Purpose Of Visit Required")]
        [DataType(DataType.MultilineText)]
        public string PurposeOfVisit { get; set; }

        [Display(Name = "Who to Visit")]
        [Required(ErrorMessage = "Who to Visit Required")]
        public string WhoToVisit { get; set; }
        [Display(Name = "Did (S)he Know your are Coming")]
        [Required(ErrorMessage = "Did (S)he Know your are Coming Required")]
        public string DidKnow { get; set; }
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        [Display(Name = "Date")]
        public string Dates { get; set; }
        [Display(Name = "Time")]
        [Required(ErrorMessage = "Time Required")]
        [DataType(DataType.Time)]
        public string TimeOfVisit { get; set; }
        public string Status { get; set; }
        public string VisitID { get; set; }
        public string StationName { get; set; }
        public string ReceiverID { get; set; }
        public string ReceiverID1 { get; set; }
        public string ReceiverID2 { get; set; }
        public string ReceiverID3 { get; set; }
        public string ReceiverID4 { get; set; }
        public string UserID { get; set; }

}
}
