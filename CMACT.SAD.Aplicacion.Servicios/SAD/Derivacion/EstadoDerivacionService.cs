using CMACT.SAD.Aplicacion.DTOs.SAD.Derivacion;
using CMACT.SAD.Aplicacion.DTOs.Shared;
using CMACT.SAD.Aplicacion.Servicios.Shared;
using CMACT.SAD.Dominio.Logica.SAD;
using CMACT.SAD.Infraestructura.Datos.SAD.Repositorios.Derivacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMACT.SAD.Aplicacion.Servicios.SAD.Derivacion
{
    public class EstadoDerivacionService : BaseService
    {
        IEstadoDerivacionRepository loRepositorioEstadoDerivacion;

        public EstadoDerivacionService(string asUsuario)
        {
            Usuario = asUsuario;
            loRepositorioEstadoDerivacion = new EstadoDerivacionRepository(Usuario);
        }

        public IList<dtoEstadoDerivacion> ObtenerTodos()
        {
            return loRepositorioEstadoDerivacion.ObtenerTodo();
        }
    }
}
