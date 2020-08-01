using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoGIS_LuisMartha.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(30)]
        public string Apellido { get; set; }


        [Required]
        [StringLength(20)]
        public string ci{ get; set; }


        [Required]
        [StringLength(50)]
        public string Direccion{ get; set; }



        [Required]
        public int Telf{ get; set; }


        [Required]
        [StringLength(30)]
        public string Cuenta { get; set; }


        [Required]
        [StringLength(50)]
        public string Contrasenia{ get; set; }

        

        

    }
}