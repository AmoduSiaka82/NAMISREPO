using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class LoadUserPage
    {
        [Display(Name = "Page Name")]
        [Column(TypeName = "varchar(150)")]
        public string PageName { get; set; }
        [Key]
        [Display(Name = "Page ID")]
        public int PageID { get; set; }
       
    }
}
