using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpresaNavidadORM.Models
{
    [Table("Producto")]
    public class Producto
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Nombre { get; set; }

        [MaxLength(4096)]
        public string Descripcion { get; set; }

        // Indica que la llave migra de Producto a Envia
        public ICollection<Envia> envia { get; set; }
    }
}