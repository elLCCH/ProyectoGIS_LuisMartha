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

        internal void Crear(Usuario model)
        {
            using (var db = new GeneralContext())
            {
                db.Usuarios.Add(model);
                db.SaveChanges();
            }
        }

    }
}