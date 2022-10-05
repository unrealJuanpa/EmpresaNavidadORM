using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpresaNavidadORM.Models
{
    [Table("Recibe")]
    public class Recibe
    {
        [Required]
        public int Id { get; set; }

        public DateTime Fecha { get; set; }


        // Indica que recibe la llave de la tabla Envia
        public Envia envia { get; set; }
        public int EnviaId { get; set; }
    }
}