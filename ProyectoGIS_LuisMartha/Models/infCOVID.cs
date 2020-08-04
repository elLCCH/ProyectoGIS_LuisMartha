using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoGIS_LuisMartha.Models
{
    public class infCOVID
    {
        public int Id { get; set; }

        [Required]
        public int DatoDecesos { get; set; }
        [Required]
        public int DatoRecuperados { get; set; }
        [Required]
        public int DatoNuevosCasos { get; set; }
       

        public int LayoutMapId { get; set; } //obtener la id de la otra tabla
        [ForeignKey("LayoutMapId")]
        public LayoutMap LayoutMap { get; set; }
    }
}