using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMACT.SAD.Aplicacion.DTOs.Shared
{
    public class PistaAuditoria
    {
        public string CodigoUsuario { get; private set; }
        public DateTime FechaActualSistema { get; private set; }
        public PistaAuditoria(
            string asCodigoUsuario
            , DateTime adtFechaActualSistema
            )
        {
            CodigoUsuario = asCodigoUsuario;
            FechaActualSistema = adtFechaActualSistema;
        }
    }
}
