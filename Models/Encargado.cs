using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmpresaNavidadORM.Models
{
    [Table("Encargado")]
    public class Encargado
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Nombre { get; set; }
        [Required]
        public int Telefono { get; set; }
        [MaxLength(200)]
        public string Direccion { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }

        public ICollection<Sucursal> TablaSucursal { get; set; }
    }
}