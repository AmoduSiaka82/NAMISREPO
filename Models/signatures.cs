using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class signatures
    {
        [Required(ErrorMessage = "Signature File Required")]
        [Display(Name = "Signature File")]
        
        public string SignFile { get; set; }
        [Key]
        public int Id { get; set; }
        public string UserID { get; set; }
}
}
