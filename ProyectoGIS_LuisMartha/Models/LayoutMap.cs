using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;

namespace ProyectoGIS_LuisMartha.Models
{
    public class LayoutMap
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Titulo { get; set; }
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
        
        [Required]
        public byte[] Mapa { get; set; }
        public DateTime FechPublicacion{ get; set; }

        
        public int UsuarioId { get; set; } //obtener la id de la otra tabla
        [ForeignKey("UsuarioId")]
        public Usuario Usuario{ get; set; }

    }
}