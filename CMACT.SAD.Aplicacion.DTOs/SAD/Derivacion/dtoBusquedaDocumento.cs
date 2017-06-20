using CMACT.SAD.Aplicacion.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMACT.SAD.Aplicacion.DTOs.SAD.Derivacion
{
    public class dtoBusquedaDocumento : BaseDto
    {
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        public dtoBusquedaDocumento()
        {

        }
    }
}
