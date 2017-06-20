using CMACT.SAD.Aplicacion.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMACT.SAD.Aplicacion.DTOs.SAD.Derivacion
{
    public class dtoTipoDocumento : BaseDto
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
    }

    public enum TipoDocumentoOperacion
    {
        Todos
    }
}
