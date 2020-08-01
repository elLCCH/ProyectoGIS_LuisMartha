using ProyectoGIS_LuisMartha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoGIS_LuisMartha.Services
{
    public class LayoutMapRepository
    {
        public List<LayoutMap> ObtenerTodos()
        {
            //return _db.LayoutMap.ToList();
            using (var db = new GeneralContext())
            {
                return db.LayoutMaps.ToList();
            }
        }
        public List<LayoutMap> ListarPorID(int id)
        {
            using (var _db = new GeneralContext())
            {
                return _db.LayoutMaps.Where(x => x.Id == id).ToList();

                //var reg =;
                //return reg;
            }
        }

        internal void Crear(LayoutMap model)
        {
            using (var db = new GeneralContext())
            {
                db.LayoutMaps.Add(model);
                db.SaveChanges();
            }
        }
        internal void Eliminar(int id)
        {
            using (var _db = new GeneralContext())
            {
                var reg = _db.LayoutMaps.Where(x => x.Id == id).FirstOrDefault();
                _db.LayoutMaps.Remove(reg);
                _db.SaveChanges();
            }
        }

        internal void Modificar(LayoutMap model)
        {
            using (var _db = new GeneralContext())
            {
                _db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }
    }
}