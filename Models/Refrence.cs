using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class Refrence
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Ref No")]
        [Column(TypeName = "varchar(200)")]
        public string RefNo { get; set; }
    }
}
