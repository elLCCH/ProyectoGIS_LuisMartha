using ProyectoGIS_LuisMartha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProyectoGIS_LuisMartha.Services
{
    public class UsuarioRepository
    {
        public List<Usuario> ObtenerTodos()
        {
            //return _db.Usuario.ToList();
            using (var db = new GeneralContext())
            {
                return db.Usuarios.ToList();
            }
        }
        public List<Usuario> ListarPorID(int id)
        {
            using (var _db = new GeneralContext())
            {
                return _db.Usuarios.Where(x => x.Id == id).ToList();
                
                //var reg =;
                //return reg;
            }
        }

        internal void Crear(Usuario model)
        {
            using (var db = new GeneralContext())
            {
                db.Usuarios.Add(model);
                db.SaveChanges();
            }
        }
        internal void Eliminar(int id)
        {
            using (var _db = new GeneralContext())
            {
                var reg = _db.Usuarios.Where(x => x.Id == id).FirstOrDefault();
                _db.Usuarios.Remove(reg);
                _db.SaveChanges();
            }
        }

        internal void Modificar(Usuario model)
        {
            using (var _db = new GeneralContext())
            {
                _db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }
    }
}