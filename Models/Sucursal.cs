using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmpresaNavidadORM.Models
{
    [Table("Sucursal")]
    public class Sucursal
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(200)]
        public string NombreTienda { get; set; }
        [Required]
        public int Telefono { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }

        public Encargado encargados { get; set; }
        public int EncargadoId { get; set; }
        public Municipio municipios { get; set; }
        public int MunicipioId { get; set; }
        public ICollection<SucursalEnvia> sucursalEnvias { get; set; }
        public ICollection<SucursalRecibe> sucursalRecibes { get; set; }
    }
}