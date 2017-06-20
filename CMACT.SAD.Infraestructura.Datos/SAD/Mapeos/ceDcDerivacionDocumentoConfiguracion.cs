using CMACT.SAD.Dominio.Entidades.SAD;
using CMACT.SAD.Infraestructura.Datos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMACT.SAD.Infraestructura.Datos.SAD.Mapeos
{
    public class ceDcDerivacionDocumentoConfiguracion : BaseConfiguracion<ceDcDerivacionDocumento>
    {
        public ceDcDerivacionDocumentoConfiguracion()
        {

            ToTable("DC_DERIVACION_DOCUMENTO", "DC");
            HasKey(m => new { m.CodigoDerivacionDocumento });

            Property(m => m.CodigoDerivacionDocumento).HasColumnName("COD_DERIVACION_DOCUMENTO");
            Property(m => m.CodigoDocumento).HasColumnName("COD_DOCUMENTO");
            Property(m => m.CodigoEstadoDerivacion).HasColumnName("COD_ESTADO_DERIVACION");
            Property(m => m.NumeroUnidadOrganica).HasColumnName("NUM_UNIDAD_ORGANICA");
            Property(m => m.NombreUnidadOrganica).HasColumnName("NOM_UNIDAD_ORGANICA");
            Property(m => m.CodigoUsuario).HasColumnName("COD_USUARIO");
            Property(m => m.NombreUsuario).HasColumnName("NOM_USUARIO");
            Property(m => m.DescripcionJustificacion).HasColumnName("DES_JUSTIFICACION");
            Property(m => m.IndicadorVisualizar).HasColumnName("IND_VISUALIZAR");
            Property(m => m.IndicadorDescargar).HasColumnName("IND_DESCARGAR");

            HasRequired(g => g.DocumentoX).WithMany().HasForeignKey(g => g.CodigoDocumento);
            HasRequired(g => g.EstadoDerivacionX).WithMany().HasForeignKey(g => g.CodigoEstadoDerivacion);
        }
    }
}
