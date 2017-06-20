using CMACT.SAD.Dominio.Entidades.SAD;
using CMACT.SAD.Infraestructura.Datos.SAD.Mapeos;
using CMACT.SAD.Infraestructura.Datos.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMACT.SAD.Infraestructura.Datos.SAD.Contextos
{
    public class SadContext : BaseContext
    {
        public SadContext()
               : base("name=SADConnection")
        {

        }

        public DbSet<ceDcTipoDocumento> TipoDocumento { get; set; }
        public DbSet<ceDcDocumento> Documento { get; set; }
        public DbSet<ceDcEstadoDerivacion> EstadoDerivacion { get; set; }
        public DbSet<ceDcDerivacionDocumento> DerivacionDocumento { get; set; }

        protected override void OnModelCreating(DbModelBuilder aoModelbuilder)
        {
            aoModelbuilder.Configurations.Add(new ceDcTipoDocumentoConfiguracion());
            aoModelbuilder.Configurations.Add(new ceDcDocumentoConfiguracion());
            aoModelbuilder.Configurations.Add(new ceDcEstadoDerivacionConfiguracion());
            aoModelbuilder.Configurations.Add(new ceDcDerivacionDocumentoConfiguracion());

            base.OnModelCreating(aoModelbuilder);
        }

        public void GuardarCambios()
        {
            ApplyChanges();
        }
    }
}
