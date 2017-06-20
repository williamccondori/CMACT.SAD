using CMACT.SAD.Aplicacion.DTOs.SAD.Derivacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMACT.SAD.Dominio.Logica.SAD
{
    public interface IDerivacionDocumentoRepository
    {
        bool CambiarEstado(dtoDerivacionDocumento aoDto);
    }
}
