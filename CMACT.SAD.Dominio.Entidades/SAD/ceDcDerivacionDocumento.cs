using CMACT.SAD.Aplicacion.DTOs.Shared;
using CMACT.SAD.Dominio.Entidades.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMACT.SAD.Dominio.Entidades.SAD
{
    public class ceDcDerivacionDocumento : BaseEntidad
    {
        public int CodigoDerivacionDocumento { get; set; }
        public int CodigoDocumento { get; set; }
        public int CodigoEstadoDerivacion { get; set; }
        public string NumeroUnidadOrganica { get; set; }
        public string NombreUnidadOrganica { get; set; }
        public string CodigoUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string DescripcionJustificacion { get; set; }
        public bool IndicadorVisualizar { get; set; }
        public bool IndicadorDescargar { get; set; }
        public ceDcDocumento DocumentoX { get; set; }

        public ceDcEstadoDerivacion EstadoDerivacionX { get; set; }

        public ceDcDerivacionDocumento()
        {

        }
        public ceDcDerivacionDocumento(
            int aiCodigoEstadoDocumento
            , string asNumeroUnidadOrganica
            , string asNombreUnidadOrganica
            , string asCodigoUsuario
            , string asNombreUsuario
            , string asDescripcionJustificacion
            , bool abIndicadorVisualizar
            , bool abIndicadorDescargar
            , PistaAuditoria aoPistaAuditoria
            )
        {
            CodigoEstadoDerivacion = aiCodigoEstadoDocumento;
            NumeroUnidadOrganica = asNumeroUnidadOrganica;
            NombreUnidadOrganica = asNombreUnidadOrganica;
            CodigoUsuario = asCodigoUsuario;
            NombreUsuario = asNombreUsuario;
            DescripcionJustificacion = asDescripcionJustificacion;
            IndicadorVisualizar = abIndicadorVisualizar;
            IndicadorDescargar = abIndicadorDescargar;
            IndicadorEstado = "A";
            RegistrarAuditoria(EstadoObjeto.Nuevo, aoPistaAuditoria);
        }

        public void Editar(int aiCodigoEstadoDerivacion, string asDescripcionJustificacion, PistaAuditoria aoPistaAuditoria)
        {
            this.CodigoEstadoDerivacion = aiCodigoEstadoDerivacion;
            this.DescripcionJustificacion = asDescripcionJustificacion;
            RegistrarAuditoria(EstadoObjeto.Modificado, aoPistaAuditoria);
        }

        public void Editar(
            int aiCodigoDocumento
            , int aiCodigoEstadoDerivacion
            , string asNumeroUnidadOrganica
            , string asNombreUnidadOrganica
            , string asCodigoUsuario
            , string asNombreUsuario
            , string asDescripcionJustificacion
            , bool abIndicadorVisualizar
            , bool abIndicadorDescargar
            , PistaAuditoria aoPistaAuditoria
            )
        {
            this.CodigoDocumento = aiCodigoDocumento;
            this.CodigoEstadoDerivacion = aiCodigoEstadoDerivacion;
            this.NumeroUnidadOrganica = asNumeroUnidadOrganica;
            this.NombreUnidadOrganica = asNombreUnidadOrganica;
            this.CodigoUsuario = asCodigoUsuario;
            this.NombreUsuario = asNombreUsuario;
            this.DescripcionJustificacion = asDescripcionJustificacion;
            this.IndicadorVisualizar = abIndicadorVisualizar;
            this.IndicadorDescargar = abIndicadorDescargar;
            RegistrarAuditoria(EstadoObjeto.Modificado, aoPistaAuditoria);
        }
    }
}
