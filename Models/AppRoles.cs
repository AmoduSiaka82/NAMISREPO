using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
    public class AppRoles : IdentityRole

    {

        public AppRoles() : base() { }

        public AppRoles(string name) : base(name) { }
        [Column(TypeName = "varchar(500)")]
        public string units { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string sections { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string departments { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string mda { get; set; }
    }
}
