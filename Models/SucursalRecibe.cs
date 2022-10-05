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

        public Sucursal sucursales { get; set; }
    }
}