using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmpresaNavidadORM.Models
{
    public class DB_Context:DbContext
    {
        public DB_Context() : base ("EmpresanNavidadORM")
        {

        }
        public DbSet<Encargado> Encargados { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
    }
}