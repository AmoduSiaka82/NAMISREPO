using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class MinuteOfMeeting
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title Required")]
        
        public string Title { get; set; }
        [Display(Name = "Content")]
        [Required(ErrorMessage = "Content Required")]
        [DataType(DataType.MultilineText)]
        public string Contents { get; set; }
        [Display(Name = "Minute No")]
        [Required(ErrorMessage = "Minute No Required")]
       
        public string MinuteNo { get; set; }
        [Key]
        public int Id { get; set; }
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime Date { get; set; }
        [Display(Name = "Dates")]

        public string Dates { get; set; }
        public string UserID { get; set; }
        public string StationName { get; set; }
        public string ReceiverID { get; set; }
        public string ReceiverID1 { get; set; }
        public string ReceiverID2 { get; set; }
        public string ReceiverID3 { get; set; }
        public string ReceiverID4 { get; set; }
        public string MinuteID { get; set; }
        public string BoxID { get; set; }
        public string Status { get; set; }
        public string Yr { get; set; }
        public string Mnt { get; set; }
        public string Day { get; set; }
        public string MinuteTitle { get; set; }
        [DataType(DataType.MultilineText)]
        public string Remark { get; set; }
    }
}
