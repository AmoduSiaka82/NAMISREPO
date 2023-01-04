using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.ViewModels
{
    public class signaturesModel
    {
        [Required(ErrorMessage = "Signature File Required")]
        [Display(Name = "Signature File")]
        [NotMapped]
        public List<IFormFile> SignFile { get; set; }
        [Key]
        public int Id { get; set; }
        public string UserID { get; set; }
    }
}
