using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class Qualification
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "Qualification")]
        [Column(TypeName = "varchar(200)")]
        public string Qualify { get; set; }
    }
}
