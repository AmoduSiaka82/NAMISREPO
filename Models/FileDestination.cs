using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class FileDestination
    {
        [Column(TypeName = "varchar(250)")]
        public string DestinationName { get; set; }
        [Key]
        public int ID { get; set; }
    }
}
