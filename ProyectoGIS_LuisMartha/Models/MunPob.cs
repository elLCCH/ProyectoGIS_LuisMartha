using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoGIS_LuisMartha.Models
{
    public class MunPob
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Departamento { get; set; }

        [Required]
        [StringLength(40)]
        public string NomMunicipio { get; set; }

        public int UsuarioId { get; set; } //obtener la id de la otra tabla
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
    }
}