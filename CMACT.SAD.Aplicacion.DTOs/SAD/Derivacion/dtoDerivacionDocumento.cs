using CMACT.SAD.Aplicacion.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMACT.SAD.Aplicacion.DTOs.SAD.Derivacion
{
    public class dtoDerivacionDocumento : BaseDto
    {
        public int CodigoDerivacion { get; set; }
        public int CodigoDocumento { get; set; }
        public int CodigoEstado { get; set; }
        public dtoEstadoDerivacion ObjetoEstadoDerivacion { get; set; }
        public string NumeroUnidadOrganica { get; set; }
        public string NombreUnidadOrganica { get; set; }
        public string CodigoUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public bool IndicadorVisualizar { get; set; }
        public bool IndicadorDescargar { get; set; }
        public string Justificacion { get; set; }
        public DateTime FechaDerivacion { get; set; }
        public DateTime FechaAtencion { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public bool Eliminado { get; set; }

        public dtoDerivacionDocumento()
        {
            ObjetoEstadoDerivacion = new dtoEstadoDerivacion();
        }
    }
}
