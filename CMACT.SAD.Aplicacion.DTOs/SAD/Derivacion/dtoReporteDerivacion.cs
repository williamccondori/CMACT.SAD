using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMACT.SAD.Aplicacion.DTOs.SAD.Derivacion
{
    public class dtoReporteDerivacion : dtoBusquedaDocumento
    {
        public string UsuarioSecretaria { get; set; }
        public string EstadoDocumento { get; set; }
    }
}
