using CMACT.SAD.Dominio.Entidades.SAD;
using CMACT.SAD.Infraestructura.Datos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMACT.SAD.Infraestructura.Datos.SAD.Mapeos
{
    public class ceDcMovimientoDocumentoConfiguracion : BaseConfiguracion<ceDcMovimientoDocumento>
    {
        public ceDcMovimientoDocumentoConfiguracion()
        {
            ToTable("DC_MOVIMIENTO_DOCUMENTO", "DC");
            HasKey(m => new { m.CodigoMovimientoDocumento });

            Property(m => m.CodigoMovimientoDocumento).HasColumnName("COD_MOVIMIENTO_DOCUMENTO");
            Property(m => m.CodigoTipoMovimientoDocumento).HasColumnName("COD_TIPO_MOVIMIENTO_DOCUMENTO");
            Property(m => m.CodigoDocumento).HasColumnName("COD_DOCUMENTO");
            Property(m => m.DescripcionObservacion).HasColumnName("DES_OBSERVACION");
        }
    }
}
