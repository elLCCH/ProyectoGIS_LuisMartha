using ProyectoGIS_LuisMartha.Models;
using ProyectoGIS_LuisMartha.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoGIS_LuisMartha.Controllers
{
    public class infCOVIDsController : Controller
    {
        private infCOVIDRepository _repo;
        
        public infCOVIDsController()
        {
            _repo = new infCOVIDRepository();
        }

        // GET: infCOVIDs
        public ActionResult Index()
        {
            var model = _repo.ObtenerTodos();
            
            return View(model);

        }
        
        

        // GET: infCOVIDs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: infCOVIDs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: infCOVIDs/Create
        [HttpPost]
        public ActionResult Create(infCOVID model)
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

        // GET: infCOVIDs/Edit/5
        public ActionResult Edit(int id)
        {
            infCOVID model = new infCOVID();
            using (var db = new GeneralContext())
            {
                var oTabla = db.infCOVIDs.Find(id);
                model.DatoDecesos = oTabla.DatoDecesos;
                model.DatoNuevosCasos = oTabla.DatoNuevosCasos;
                model.DatoRecuperados = oTabla.DatoRecuperados;
                model.LayoutMapId = oTabla.LayoutMapId;
            }
            return View(model);
        }

        // POST: infCOVIDs/Edit/5
        [HttpPost]
        public ActionResult Edit(infCOVID model, FormCollection collection)
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

        // GET: infCOVIDs/Delete/5
        public ActionResult Delete(int id)
        {
            infCOVID model = new infCOVID();
            using (var db = new GeneralContext())
            {
                var oTabla = db.infCOVIDs.Find(id);
                model.DatoDecesos = oTabla.DatoDecesos;
                model.DatoNuevosCasos = oTabla.DatoNuevosCasos;
                model.DatoRecuperados = oTabla.DatoRecuperados;
                model.LayoutMapId = oTabla.LayoutMapId;


            }
            return View(model);
        }

        // POST: infCOVIDs/Delete/5
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
