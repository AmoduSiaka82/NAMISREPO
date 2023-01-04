using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionManagement.MVC.ViewModels
{
    public class ProductsImageModel
    {
        [Column(TypeName = "varchar(200)")]
        public string ProductsId { get; set; }
        [Required]
        [Display(Name = "Description")]
        [Column(TypeName = "varchar(200)")]
        public string Description { get; set; }
        [NotMapped]
        [Display(Name = "Image")]
        [Required(ErrorMessage = "Image Required")]
        public List<IFormFile> ProductImage { get; set; }
    }
}
