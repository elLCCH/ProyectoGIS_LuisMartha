using ProyectoGIS_LuisMartha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoGIS_LuisMartha.Services
{
    public class MunPobRepository
    {
        public List<MunPob> ObtenerTodos()
        {
            //return _db.MunPob.ToList();
            using (var db = new GeneralContext())
            {
                return db.MunPobs.ToList();
            }
        }
        public List<MunPob> ListarPorID(int id)
        {
            using (var _db = new GeneralContext())
            {
                return _db.MunPobs.Where(x => x.Id == id).ToList();

                //var reg =;
                //return reg;
            }
        }

        internal void Crear(MunPob model)
        {
            using (var db = new GeneralContext())
            {
                db.MunPobs.Add(model);
                db.SaveChanges();
            }
        }
        internal void Eliminar(int id)
        {
            using (var _db = new GeneralContext())
            {
                var reg = _db.MunPobs.Where(x => x.Id == id).FirstOrDefault();
                _db.MunPobs.Remove(reg);
                _db.SaveChanges();
            }
        }

        internal void Modificar(MunPob model)
        {
            using (var _db = new GeneralContext())
            {
                _db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }
    }
}