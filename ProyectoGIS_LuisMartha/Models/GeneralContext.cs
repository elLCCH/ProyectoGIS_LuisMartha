using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoGIS_LuisMartha.Models
{
    public class GeneralContext:DbContext
    {
        public GeneralContext()
           : base("DefaultConnection") //aca esta el nombre de nuestro conexionString
        {

        }
        //en BlogPost blanco es el nombre de la tabla
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<LayoutMap> LayoutMaps{ get; set; }
        public DbSet<MunPob> MunPobs{ get; set; }
        public DbSet<infCOVID> infCOVIDs { get; set; }
    }
}