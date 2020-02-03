using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MVC_Crud.Models.viewModels
{
    public class ListTablaViewModels
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public string clave { get; set; }
    }
}