using CMACT.SAD.Aplicacion.DTOs.Shared;
using CMACT.SAD.Dominio.Entidades.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMACT.SAD.Dominio.Entidades.SAD
{
    public class ceDcMovimientoDocumento : BaseEntidad
    {
        public int CodigoMovimientoDocumento { get; set; }
        public int CodigoTipoMovimientoDocumento { get; set; }
        public int CodigoDocumento { get; set; }
        public string DescripcionObservacion { get; set; }

        public ceDcMovimientoDocumento()
        {

        }

        public ceDcMovimientoDocumento(
            int aiTipoMovimiento
            , int aiCodigoDocumento
            , string asObservacion
            , PistaAuditoria aoPistaAuditoria
            )
        {
            CodigoTipoMovimientoDocumento = aiTipoMovimiento;
            CodigoDocumento = aiCodigoDocumento;
            DescripcionObservacion = DescripcionObservacion;
            RegistrarAuditoria(EstadoObjeto.Nuevo, aoPistaAuditoria);
        } 
    }
}
