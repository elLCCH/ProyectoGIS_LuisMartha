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
    public class LayoutMapsController : Controller
    {
        private LayoutMapRepository _repo;
        GeneralContext db = new GeneralContext();
        public LayoutMapsController()
        {
            _repo = new LayoutMapRepository();
        }
        // GET: LayoutMaps
        public ActionResult Index()
        {
            var model = _repo.ObtenerTodos();
            return View(model);

        }
        
       

        // GET: LayoutMaps/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LayoutMaps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LayoutMaps/Create
        [HttpPost]
        public ActionResult Create(LayoutMap model)
        {
            
            try
            {
                HttpPostedFileBase fileBase = Request.Files[0];
                WebImage image = new WebImage(fileBase.InputStream);
                model.Mapa = image.GetBytes();
                // TODO: Add insert logic here
                _repo.Crear(model); //queremos crear  y mandamos los datos o modelo

                return RedirectToAction("Index");

            }
            catch
            {
                //return View();
            }
            return View(model);
        }

        // GET: LayoutMaps/Edit/5
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
            }
            return View(model);
        }

        // POST: LayoutMaps/Edit/5
        [HttpPost]
        public ActionResult Edit(LayoutMap model, FormCollection collection)
        {
            //desde aca
            byte[] imagenActual = null;

            HttpPostedFileBase FileBase = Request.Files[0];
            if(FileBase == null)
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
                    return RedirectToAction("Index");
                //}
                //return RedirectToAction("Index");
            }
            catch
            {
                //return View();
            }
            return RedirectToAction("Index");
        }

        // GET: LayoutMaps/Delete/5
        public ActionResult Delete(int id)
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
            }
            return View(model);
        }

        // POST: LayoutMaps/Delete/5
        [HttpPost]
        public ActionResult Delete(LayoutMap model, FormCollection collection)
        {
            //byte[] imagenActual = null;

            //HttpPostedFileBase FileBase = Request.Files[0];
            //if (FileBase == null)
            //{
            //    imagenActual = db.LayoutMaps.SingleOrDefault(t => t.Id == model.Id).Mapa;
            //}
            //else
            //{
            //    WebImage image = new WebImage(FileBase.InputStream);
            //    model.Mapa = image.GetBytes();
            //}
            //hasta aca es sobre la imagen enBD

            try
            {
                // TODO: Add update logic here
                //if (ModelState.IsValid)
                //{
                //el metodo crear lo generamos y este se genero en el Reposytory
                _repo.Eliminar(model.Id); //queremos crear  y mandamos los datos o modelo
                return RedirectToAction("Index");
                //}
                //return RedirectToAction("Index");
            }
            catch
            {
                //return View();
            }
            return RedirectToAction("Index");
        }
        public  ActionResult getImagee(int id)
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
