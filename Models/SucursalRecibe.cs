using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmpresaNavidadORM.Models
{
    [Table("SucursalRecibe")]
    public class SucursalRecibe
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(200)]
        public string NombreAdicional { get; set; }

        public ICollection<Envia> envia { get; set; }
        public Sucursal sucursal { get; set; }
        public int SucursalId { get; set; }
    }
}