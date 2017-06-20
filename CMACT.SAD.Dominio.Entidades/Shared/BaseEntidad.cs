using CMACT.SAD.Aplicacion.DTOs.Shared;
using CMACT.SAD.Dominio.Entidades.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMACT.SAD.Dominio.Entidades.Shared
{
    public class BaseEntidad : IEntidad
    {
        public string CodigoUsuarioRegistro { get; set; }
        public string CodigoUsuarioModifico { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public EstadoObjeto EstadoObjeto { get; set; }
        public string IndicadorEstado { get; set; }

        public void RegistrarAuditoria(EstadoObjeto aoEstadoObjeto, PistaAuditoria aoPistaAuditoria)
        {
            EstadoObjeto = aoEstadoObjeto;

            if (aoEstadoObjeto == EstadoObjeto.Nuevo)
            {
                CodigoUsuarioRegistro = aoPistaAuditoria.CodigoUsuario;
                FechaRegistro = aoPistaAuditoria.FechaActualSistema;
                IndicadorEstado = "A";
            }
            if (aoEstadoObjeto == EstadoObjeto.Modificado)
            {
                CodigoUsuarioModifico = aoPistaAuditoria.CodigoUsuario;
                FechaModifico = aoPistaAuditoria.FechaActualSistema;
            }
        }

        public void Inhabilitar(
            PistaAuditoria aoPistaAuditoria
            )
        {
            IndicadorEstado = "I";
            RegistrarAuditoria(EstadoObjeto.Modificado, aoPistaAuditoria);
        }
    }
}
