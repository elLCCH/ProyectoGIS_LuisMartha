using ProyectoGIS_LuisMartha.Models;
using ProyectoGIS_LuisMartha.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace ProyectoGIS_LuisMartha.Controllers
{
    public class UsuariosController : Controller
    {
        private UsuarioRepository _repo;
        public UsuariosController()
        {
            _repo = new UsuarioRepository();
        }
        // GET: Usuarios
        public ActionResult Index()
        {
            var model = _repo.ObtenerTodos();
            return View(model);

        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(Usuario model)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    //el metodo crear lo generamos y este se genero en el Reposytory
                    _repo.Crear(model); //queremos crear  y mandamos los datos o modelo
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                //return View();
            }
            return View(model);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            Usuario model = new Usuario();
            using (var db = new GeneralContext())
            {
                var oTabla = db.Usuarios.Find(id);
                model.Nombre = oTabla.Nombre;
                model.Apellido = oTabla.Apellido;
                model.ci = oTabla.ci;
                model.Contrasenia = oTabla.Contrasenia;
                model.Direccion = oTabla.Direccion;
                model.Cuenta = oTabla.Cuenta;
                model.Telf = oTabla.Telf;

            }
            return View(model);

            //var model = _repo.ListarPorID(id);
            //model = model.ToList();
            //return View(model);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(Usuario model, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    //el metodo crear lo generamos y este se genero en el Reposytory
                    _repo.Modificar(model); //queremos crear  y mandamos los datos o modelo
                    return RedirectToAction("Index");
                }
                //return RedirectToAction("Index");
            }
            catch
            {
                //return View();
            }
            return RedirectToAction("Index");
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            Usuario model = new Usuario();
            using (var db = new GeneralContext())
            {
                var oTabla = db.Usuarios.Find(id);
                model.Nombre = oTabla.Nombre;
                model.Apellido = oTabla.Apellido;
                model.ci = oTabla.ci;
                model.Contrasenia = oTabla.Contrasenia;
                model.Direccion = oTabla.Direccion;
                model.Cuenta = oTabla.Cuenta;
                model.Telf = oTabla.Telf;
                
            }
            return View(model);
            //var model = _repo.ListarPorID(id);

            
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    //el metodo crear lo generamos y este se genero en el Reposytory
                    _repo.Eliminar(id); //queremos crear  y mandamos los datos o modelo
                    return RedirectToAction("Index");
                }
                //return RedirectToAction("Index");
            }
            catch
            {
                //return View();
            }
            return RedirectToAction("Index");
        }
    }
}
