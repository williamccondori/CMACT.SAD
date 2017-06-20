using CMACT.SAD.Aplicacion.DTOs.Shared;
using CMACT.SAD.Dominio.Entidades.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMACT.SAD.Dominio.Entidades.SAD
{
    public class ceDcDocumento : BaseEntidad
    {
        public int CodigoDocumento { get; set; }
        public int CodigoTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string DescripcionOrganoEmisor { get; set; }
        public string NombreDocumento { get; set; }
        public byte[]  DescripcionContenido { get; set; }
        public string DescripcionAsunto { get; set; }

        public ceDcTipoDocumento TipoDocumentoX { get; set; }
        public ICollection<ceDcDerivacionDocumento> DerivacionDocumentoS { get; set; }

        public ceDcDocumento()
        {

        }

        public ceDcDocumento(
            int aiCodigoTipoDocumento
            , string asNumeroDocumento
            , string asDescripcionOrganoEmisor
            , string asNombreDocumento
            , byte[] abtDescripcionContenido
            , string asDescripcionAsunto
            , ICollection<ceDcDerivacionDocumento> aoDerivacionDocumento
            , PistaAuditoria aoPistaAuditoria
            )
        {
            CodigoTipoDocumento = aiCodigoTipoDocumento;
            NumeroDocumento = asNumeroDocumento;
            DescripcionOrganoEmisor = asDescripcionOrganoEmisor;
            NombreDocumento = asNombreDocumento;
            DescripcionContenido = abtDescripcionContenido;
            DescripcionAsunto = asDescripcionAsunto;
            DerivacionDocumentoS = aoDerivacionDocumento;
            IndicadorEstado = EstadoEntidad.Activo;
            RegistrarAuditoria(EstadoObjeto.Nuevo, aoPistaAuditoria);
        }

        public void Editar(
            int aiCodigoTipo
            , string asNumero
            , string asOrganoEmisor
            , string asNombreArchivo
            , byte[] aoContenidoArchivo
            , string asAsunto
            , PistaAuditoria aoPistaAuditoria)
        {
            CodigoTipoDocumento = aiCodigoTipo;
            NumeroDocumento = asNumero;
            DescripcionOrganoEmisor = asOrganoEmisor;
            NombreDocumento = asNombreArchivo;
            DescripcionContenido = aoContenidoArchivo;
            DescripcionAsunto = asAsunto;
            RegistrarAuditoria(EstadoObjeto.Modificado, aoPistaAuditoria);
        }
    }
}
