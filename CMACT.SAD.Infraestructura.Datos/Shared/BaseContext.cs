using CMACT.SAD.Dominio.Entidades.Contratos;
using CMACT.SAD.Infraestructura.Datos.Utilidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMACT.SAD.Infraestructura.Datos.Shared
{
    public class BaseContext : DbContext
    {
        public BaseContext()
        {

        }

        public BaseContext(string asConnectionString = "SAF")
			: base(asConnectionString)
		{
            Database.SetInitializer<BaseContext>(null);
        }

        protected void ApplyChanges()
        {
            AplicarCambios(); 

            base.SaveChanges();
        }

        private void AplicarCambios()
        {
            foreach (var Entidad in ChangeTracker.Entries<IEntidad>().ToList())
            {
                Entidad.State = Helpers.ConvertirAEntityState(Entidad.Entity.EstadoObjeto);

                if (Entidad.State == EntityState.Modified)
                {
                    Entidad.Entity.FechaModifico = Entidad.Entity.FechaModifico ?? DateTime.Now;
                }
                else if (Entidad.State == EntityState.Added)
                {
                    Entidad.Entity.FechaRegistro = Entidad.Entity.FechaRegistro ?? DateTime.Now;
                }
            }

            foreach (var Entidad in ChangeTracker.Entries<IEstadoObjeto>().ToList())
            {
                Entidad.State = Helpers.ConvertirAEntityState(Entidad.Entity.EstadoObjeto);
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
