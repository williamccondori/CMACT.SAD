using CMACT.SAD.Dominio.Entidades.SAD;
using CMACT.SAD.Infraestructura.Datos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMACT.SAD.Infraestructura.Datos.SAD.Mapeos
{
    public class ceDcTipoDocumentoConfiguracion : BaseConfiguracion<ceDcTipoDocumento>
    {
        public ceDcTipoDocumentoConfiguracion()
        {
            ToTable("DC_TIPO_DOCUMENTO", "DC");
            HasKey(m => new { m.CodigoTipoDocumento });
            Property(m => m.CodigoTipoDocumento).HasColumnName("COD_TIPO_DOCUMENTO");
            Property(m => m.DescripcionTipoDocumento).HasColumnName("DES_TIPO_DOCUMENTO");
        }
    }
}
