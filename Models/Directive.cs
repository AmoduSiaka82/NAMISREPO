using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class Directive
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        [Display(Name = "Directed By")]       
        [Column(TypeName = "varchar(1000)")]
        public string OfficerName { get; set; }
        [Display(Name = "Responsibility")]
        [Column(TypeName = "varchar(200)")]
        public string Responsibility { get; set; }
        [Display(Name = "Remark")]
        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(5000)")]
        public string Remarks { get; set; }
        [Display(Name = "Ref No")]
        [Column(TypeName = "varchar(200)")]
        public string RefNo { get; set; }
        [Display(Name = "Sprp No")]
        [Column(TypeName = "varchar(50)")]
        public string SprpNo { get; set; }
        [Display(Name = "UserID")]
        [Column(TypeName = "varchar(50)")]
        public string UserID { get; set; }
        [Display(Name = "Action")]
        [Column(TypeName = "varchar(50)")]
        public string Act { get; set; }
        [Display(Name = "Status")]
        [Column(TypeName = "varchar(50)")]
        public string Status { get; set; }
       
    }
}
