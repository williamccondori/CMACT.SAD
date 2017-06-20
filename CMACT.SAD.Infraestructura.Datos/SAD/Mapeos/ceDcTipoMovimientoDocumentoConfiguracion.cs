using CMACT.SAD.Dominio.Entidades.SAD;
using CMACT.SAD.Infraestructura.Datos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMACT.SAD.Infraestructura.Datos.SAD.Mapeos
{
    public class ceDcTipoMovimientoDocumentoConfiguracion : BaseConfiguracion<ceDcTipoMovimientoDocumento>
    {
        public ceDcTipoMovimientoDocumentoConfiguracion()
        {
            ToTable("DC_TIPO_MOVIMIENTO_DOCUMENTO", "DC");
            HasKey(m => new { m.CodigoTipoMovimientoDocumento });

            Property(m => m.CodigoTipoMovimientoDocumento).HasColumnName("COD_TIPO_MOVIMIENTO_DOCUMENTO");
            Property(m => m.DescripcionTipoMovimientoDocumento).HasColumnName("DES_TIPO_MOVIMIENTO_DOCUMENTO");
        }
    }
}
