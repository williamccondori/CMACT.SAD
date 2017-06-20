using CMACT.SAD.Dominio.Entidades.SAD;
using CMACT.SAD.Infraestructura.Datos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMACT.SAD.Infraestructura.Datos.SAD.Mapeos
{
    public class ceDcDocumentoConfiguracion : BaseConfiguracion<ceDcDocumento>
    {
        public ceDcDocumentoConfiguracion()
        {
            ToTable("DC_DOCUMENTO", "DC");
            HasKey(m => new { m.CodigoDocumento });

            Property(m => m.CodigoDocumento).HasColumnName("COD_DOCUMENTO");
            Property(m => m.CodigoTipoDocumento).HasColumnName("COD_TIPO_DOCUMENTO");
            Property(m => m.NumeroDocumento).HasColumnName("NUM_DOCUMENTO");
            Property(m => m.DescripcionOrganoEmisor).HasColumnName("DES_ORGANO_EMISOR");
            Property(m => m.NombreDocumento).HasColumnName("NOM_DOCUMENTO");
            Property(m => m.DescripcionContenido).HasColumnName("DES_CONTENIDO");
            Property(m => m.DescripcionAsunto).HasColumnName("DES_ASUNTO");

            HasRequired(g => g.TipoDocumentoX).WithMany().HasForeignKey(g => g.CodigoTipoDocumento);
            HasMany(g => g.DerivacionDocumentoS).WithRequired().HasForeignKey(g => g.CodigoDocumento);
        }
    }
}
