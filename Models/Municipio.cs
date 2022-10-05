using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmpresaNavidadORM.Models
{
    [Table("Municipio")]
    public class Municipio
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(200)]
        public string NombreMunicipio { get; set; }

        public Departamento departamentos { get; set; }
        public ICollection<Sucursal> TablaSucursal { get; set; }
    }
}