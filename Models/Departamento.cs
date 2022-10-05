using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmpresaNavidadORM.Models
{
    [Table("Departamento")]
    public class Departamento
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(200)]
        public string NombreDepartamento { get; set; }

        public ICollection<Municipio> municipios { get; set; }
    }
}