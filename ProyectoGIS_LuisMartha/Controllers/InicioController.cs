using ProyectoGIS_LuisMartha.Models;
using ProyectoGIS_LuisMartha.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ProyectoGIS_LuisMartha.Controllers
{
    public class InicioController : Controller
    {
        private LayoutMapRepository _repo;
        GeneralContext db = new GeneralContext();
        public InicioController()
        {
            _repo = new LayoutMapRepository();
        }
        // GET: Inicio
        public ActionResult Index()
        {
            var model = _repo.ObtenerTodos();
            return View(model);

        }
        public ActionResult Map(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult InfCuidados(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Comparacion(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var model = _repo.ObtenerTodos();
                return View(model);
                
            }
            catch
            {
                return View();
            }
        }
        // GET: Inicio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inicio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inicio/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inicio/Edit/5
        public ActionResult Edit(int id)
        {
            LayoutMap model = new LayoutMap();
            using (var db = new GeneralContext())
            {
                var oTabla = db.LayoutMaps.Find(id);
                model.Id = oTabla.Id;
                model.Mapa = oTabla.Mapa;
                model.Titulo = oTabla.Titulo;
                model.Descripcion = oTabla.Descripcion;
                model.FechPublicacion = oTabla.FechPublicacion;
                model.UsuarioId = oTabla.UsuarioId;
                if (Convert.ToString(Session["Map1"]) == "")
                {
                    Session["Map1"] = model.Id;
                    return RedirectToAction("Comparacion");
                }
                else
                {
                    //Session["Map2"] = model.Id;
                    return View(model);
                }
            }
            //return View(model);
        }

        // POST: Inicio/Edit/5
        [HttpPost]
        public ActionResult Edit(LayoutMap model, FormCollection collection)
        {
            //desde aca
            byte[] imagenActual = null;

            HttpPostedFileBase FileBase = Request.Files[0];
            if (FileBase == null)
            {
                imagenActual = db.LayoutMaps.SingleOrDefault(t => t.Id == model.Id).Mapa;
            }
            else
            {
                WebImage image = new WebImage(FileBase.InputStream);
                model.Mapa = image.GetBytes();
            }
            //hasta aca es sobre la imagen enBD

            try
            {
                // TODO: Add update logic here
                //if (ModelState.IsValid)
                //{
                //el metodo crear lo generamos y este se genero en el Reposytory
                _repo.Modificar(model); //queremos crear  y mandamos los datos o modelo




                Session["Map1"] = "";
                Session["Map2"] = "";
                return RedirectToAction("#");
                //}
                //return RedirectToAction("Index");
            }
            catch
            {
                //return View();
            }

            Session["Map1"] = "";
            Session["Map2"] = "";
            return RedirectToAction("#");

        }

        // GET: Inicio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inicio/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult getImagee(int id)
        {
            LayoutMap mapasK = db.LayoutMaps.Find(id);
            byte[] byteImage = mapasK.Mapa;

            MemoryStream memoryStream = new MemoryStream(byteImage);
            Image image = Image.FromStream(memoryStream);

            memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            memoryStream.Position = 0;
            return File(memoryStream, "image/jpg");
        }
    }
}
