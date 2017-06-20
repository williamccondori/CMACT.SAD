using CMACT.SAD.Aplicacion.DTOs.SAD.Derivacion;
using CMACT.SAD.Aplicacion.Servicios.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMACT.SAD.Aplicacion.DTOs.Shared;
using CMACT.SAD.Dominio.Logica.SAD;
using CMACT.SAD.Infraestructura.Datos.SAD.Repositorios.Derivacion;

namespace CMACT.SAD.Aplicacion.Servicios.SAD.Derivacion
{
    public class TipoDocumentoService : BaseService
    {
        ITipoDocumentoRepository loRepositorioTipoDocumento;

        public TipoDocumentoService(string asUsuario)
        {
            Usuario = asUsuario;
            loRepositorioTipoDocumento = new TipoDocumentoRepository(Usuario);
        }

        public IList<dtoTipoDocumento> ObtenerTodos()
        {
            return loRepositorioTipoDocumento.ObtenerTodo();
        }

        public bool Guardar(dtoTipoDocumento aoDto)
        {
            return loRepositorioTipoDocumento.Guardar(aoDto);
        }
    }
}
