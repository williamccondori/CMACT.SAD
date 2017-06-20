using CMACT.SAD.Aplicacion.DTOs.SAD.Derivacion;
using CMACT.SAD.Aplicacion.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMACT.SAD.Dominio.Logica.SAD
{
    public interface IDocumentoRepository
    {
        dtoDocumento ObtenerXCodigo(int aiCodigo);
        IList<dtoDocumento> ObtenerTodo();
        IList<dtoDocumento> BuscarXFecha(dtoBusquedaDocumento aoDto);
        bool Guardar(dtoDocumento aoDto);
        bool Eliminar(int aiCodigo);
    }
}
