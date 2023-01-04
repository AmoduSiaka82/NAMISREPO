using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.Models
{
   
    public class useraccount : IdentityUser
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name Required")]
        [Column(TypeName = "varchar(250)")]
        public string FirstName {get; set; }
        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Surname Required")]
        [Column(TypeName = "varchar(250)")]
        public string LastName   {get; set; }
        
        [Display(Name = "Station")]
        [Required(ErrorMessage = "Station Required")]
        [Column(TypeName = "varchar(250)")]
        public string StationName {get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime RegisteredDate {get; set; }
        [Display(Name = "Department")]
        [Required(ErrorMessage = "Department Required")]
        [Column(TypeName = "varchar(150)")]
        public string Department {get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Status  {get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime LastUpdate {get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Unit   {get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime LastLogin {get; set; }

       
        [Display(Name = "Middle Name")]
        [Column(TypeName = "varchar(250)")]
        public string MiddleName { get; set; }

        [Column(TypeName = "varchar(700)")]
        public string StaffName { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title Required")]
        [Column(TypeName = "varchar(20)")]
        public string Title { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string UserID { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string RoleID { get; set; }
        public string mda { get; set; }
    }
}
