using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpresaNavidadORM.Models
{
    [Table("Envia")]
    public class Envia
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(200)]
        public string NombreEnvio { get; set; }

        public int CantidadEnvia { get; set; }

        public DateTime Fecha { get; set; }


        // Indica que se recibe la llave de la tabla Producto a la actual
        public Producto producto { get; set; }
        public int ProductoId { get; set; }
        public SucursalEnvia sucursalEnvia { get; set; }
        public int SucursalEnviaId { get; set; }
        public SucursalRecibe sucursalRecibe { get; set; }
        public int SucursalRecibeId { get; set; }

        // Indica que la llave migra a la tabla Recibe
        public ICollection<Recibe> recibe { get; set; }
    }
}