using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace NAMIS.Models
{
    public class reportupload
    {
        [Display(Name = "File")]
        public string ReportFile { get; set; }
        public string RId { get; set; }
        [Key]
        public int Id { get; set; }
    }
}
