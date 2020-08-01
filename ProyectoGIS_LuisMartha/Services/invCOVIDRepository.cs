using ProyectoGIS_LuisMartha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoGIS_LuisMartha.Services
{
    public class infCOVIDRepository
    {
        public List<infCOVID> ObtenerTodos()
        {
            //return _db.infCOVID.ToList();
            using (var db = new GeneralContext())
            {
                return db.infCOVIDs.ToList();
            }
        }
        public List<infCOVID> ListarPorID(int id)
        {
            using (var _db = new GeneralContext())
            {
                return _db.infCOVIDs.Where(x => x.Id == id).ToList();

                //var reg =;
                //return reg;
            }
        }

        internal void Crear(infCOVID model)
        {
            using (var db = new GeneralContext())
            {
                db.infCOVIDs.Add(model);
                db.SaveChanges();
            }
        }
        internal void Eliminar(int id)
        {
            using (var _db = new GeneralContext())
            {
                var reg = _db.infCOVIDs.Where(x => x.Id == id).FirstOrDefault();
                _db.infCOVIDs.Remove(reg);
                _db.SaveChanges();
            }
        }

        internal void Modificar(infCOVID model)
        {
            using (var _db = new GeneralContext())
            {
                _db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }
    }
}