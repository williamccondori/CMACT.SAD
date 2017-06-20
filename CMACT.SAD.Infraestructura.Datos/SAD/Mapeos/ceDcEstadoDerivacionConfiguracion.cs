using CMACT.SAD.Dominio.Entidades.SAD;
using CMACT.SAD.Infraestructura.Datos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMACT.SAD.Infraestructura.Datos.SAD.Mapeos
{
    public class ceDcEstadoDerivacionConfiguracion : BaseConfiguracion<ceDcEstadoDerivacion>
    {
        public ceDcEstadoDerivacionConfiguracion()
        {
            ToTable("DC_ESTADO_DERIVACION", "DC");
            HasKey(m => new { m.CodigoEstadoDerivacion });

            Property(m => m.CodigoEstadoDerivacion).HasColumnName("COD_ESTADO_DERIVACION");
            Property(m => m.DescripcionEstadoDerivacion).HasColumnName("DES_ESTADO_DERIVACION");
            Property(m => m.IndicadorEstadoDerivacion).HasColumnName("IND_ESTADO_DERIVACION");
        }
    }
}
