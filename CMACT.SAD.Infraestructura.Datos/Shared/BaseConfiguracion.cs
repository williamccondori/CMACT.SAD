using CMACT.SAD.Dominio.Entidades.Contratos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMACT.SAD.Infraestructura.Datos.Shared
{
    public class BaseConfiguracion<TEntidad> : EntityTypeConfiguration<TEntidad> where TEntidad : class, IEntidad
    {
        public BaseConfiguracion()
        {
            Property(p => p.IndicadorEstado).HasColumnName("IND_ESTADO");
            Property(p => p.CodigoUsuarioRegistro).HasColumnName("USU_REGISTRO");
            Property(p => p.CodigoUsuarioModifico).HasColumnName("USU_MODIFICO");
            Property(p => p.FechaRegistro).HasColumnName("FEC_REGISTRO");
            Property(p => p.FechaModifico).HasColumnName("FEC_MODIFICO");
            Ignore(p => p.EstadoObjeto);
        }
    }
}
