using ProyectoGIS_LuisMartha.Models;
using ProyectoGIS_LuisMartha.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoGIS_LuisMartha.Controllers
{
    public class MunPobsController : Controller
    {
        private MunPobRepository _repo;
        public MunPobsController()
        {
            _repo = new MunPobRepository();
        }
        // GET: MunPob
        public ActionResult Index()
        {
            var model = _repo.ObtenerTodos();
            return View(model);

        }
        

        // GET: MunPobs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MunPobs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MunPobs/Create
        [HttpPost]
        public ActionResult Create(MunPob model)
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

        // GET: MunPobs/Edit/5
        public ActionResult Edit(int id)
        {
            MunPob model = new MunPob();
            using (var db = new GeneralContext())
            {
                var oTabla = db.MunPobs.Find(id);
                model.NomMunicipio = oTabla.NomMunicipio;
                model.Departamento = oTabla.Departamento;
                model.UsuarioId = oTabla.UsuarioId;
                

            }
            return View(model);
        }

        // POST: MunPobs/Edit/5
        [HttpPost]
        public ActionResult Edit(MunPob model, FormCollection collection)
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

        // GET: MunPobs/Delete/5
        public ActionResult Delete(int id)
        {
            MunPob model = new MunPob();
            using (var db = new GeneralContext())
            {
                var oTabla = db.MunPobs.Find(id);
                model.NomMunicipio = oTabla.NomMunicipio;
                model.Departamento = oTabla.Departamento;
                model.UsuarioId = oTabla.UsuarioId;


            }
            return View(model);
        }

        // POST: MunPobs/Delete/5
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
