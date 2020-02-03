using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Crud.Models.viewModels
{
    public class TablaViewModels
    {
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Apellido")]
        public string apellido { get; set; }
        [Required]
        [StringLength(70)]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string mail { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Password")]
        public string clave { get; set; }
    }
}