using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class register
    {
        [Display(Name = "SPRP No")]
        [Column(TypeName = "varchar(50)")]
        public string SprpNo { get; set; }

        public biodata bio { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string UserID { get; set; }
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Surname { get; set; }
        [Display(Name = "Middle Name")]
        [Column(TypeName = "varchar(200)")]
        public string MiddleName{ get; set; }
        [Display(Name = "First Name")]
        [Column(TypeName = "varchar(200)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Status { get; set; }
        
        [Display(Name = "DOB")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DOB { get; set; }
        [Display(Name = "DOFA")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DOFA { get; set; }
        [Display(Name = "DOR")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DOR { get; set; }
    }
}
