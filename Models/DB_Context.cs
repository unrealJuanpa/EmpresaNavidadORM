using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmpresaNavidadORM.Models
{
    public class DB_Context:DbContext
    {
        public DB_Context() : base ("DefaultConnection")
        {

        }
        public DbSet<Encargado> Encargados { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<SucursalEnvia> SucursalEnvias { get; set; }
        public DbSet<SucursalRecibe> SucursalRecibes { get; set; }
        public DbSet<Envia> Envias { get; set; }
        public DbSet<Recibe> Recibes { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}