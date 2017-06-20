using CMACT.SAD.Aplicacion.DTOs.Shared;
using CMACT.SAD.Dominio.Entidades.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMACT.SAD.Dominio.Entidades.SAD
{
    public class ceDcTipoDocumento : BaseEntidad
    {
        public int CodigoTipoDocumento { get; set; }
        public string DescripcionTipoDocumento { get; set; }

        public ceDcTipoDocumento()
        {

        }

        public ceDcTipoDocumento(
            string asDescripcionTipoDocumento,
            PistaAuditoria aoPistaAuditoria
        )
        {
            DescripcionTipoDocumento = asDescripcionTipoDocumento;
            IndicadorEstado = EstadoEntidad.Activo;
            RegistrarAuditoria(EstadoObjeto.Nuevo, aoPistaAuditoria);
        }

        public void Editar(
            string asDescripcion
            , PistaAuditoria aoPistaAuditoria)
        {
            DescripcionTipoDocumento = asDescripcion;
            RegistrarAuditoria(EstadoObjeto.Modificado, aoPistaAuditoria);
        }
    }
}
