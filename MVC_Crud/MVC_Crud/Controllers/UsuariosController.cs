using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Crud.Models;
using MVC_Crud.Models.viewModels;

namespace MVC_Crud.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            List<ListTablaViewModels> lst;
            using (agendaEntities bd = new agendaEntities())
            {
                
                lst = (from d in bd.tblUsuarios
                           select new ListTablaViewModels
                           {
                               id = d.id,
                               nombre = d.nombre,
                               apellido = d.apellido,
                               mail = d.mail,
                               clave = d.clave
                           }).ToList();
            }

;           return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (agendaEntities bd = new agendaEntities())
                    {
                        var oUsuario = new tblUsuarios();
                        oUsuario.nombre = model.nombre;
                        oUsuario.apellido = model.apellido;
                        oUsuario.mail = model.mail;
                        oUsuario.clave = model.clave;

                        bd.tblUsuarios.Add(oUsuario);
                        bd.SaveChanges();


                    }
                    return Redirect("Usuarios/Index");
                }
                return View(model);
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public ActionResult Editar(int ID)
        {
            TablaViewModels model = new TablaViewModels();
            using(agendaEntities bd = new agendaEntities())
            {
                var oUsuario = bd.tblUsuarios.Find(ID);
                model.nombre = oUsuario.nombre;
                model.apellido = oUsuario.apellido;
                model.mail = oUsuario.mail;
                model.clave = oUsuario.clave;
                model.id = oUsuario.id;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(TablaViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (agendaEntities bd = new agendaEntities())
                    {
                        var oUsuario = bd.tblUsuarios.Find(model.id);
                        oUsuario.nombre = model.nombre;
                        oUsuario.apellido = model.apellido;
                        oUsuario.mail = model.mail;
                        oUsuario.clave = model.clave;

                        bd.Entry(oUsuario).State = System.Data.Entity.EntityState.Modified;
                        bd.SaveChanges();


                    }
                    return Redirect("~/Usuarios/Index");
                }
                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public ActionResult Eliminar(int ID)
        {
            
            using (agendaEntities bd = new agendaEntities())
            {
                var oUsuario = bd.tblUsuarios.Find(ID);
                bd.tblUsuarios.Remove(oUsuario);
                bd.SaveChanges();
            }
            return Redirect("~/Usuarios/Index");
        }
    }

    
}
