using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class TopMenus
    {
        public string menuName { get; set; }
        [Key]
        public int menuId { get; set; }
    }
}
