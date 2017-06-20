using CMACT.SAD.Dominio.Logica.SAD;
using CMACT.SAD.Infraestructura.Datos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMACT.SAD.Aplicacion.DTOs.SAD.Derivacion;
using CMACT.SAD.Aplicacion.DTOs.Shared;
using CMACT.SAD.Infraestructura.Datos.SAD.Contextos;
using CMACT.SAD.Dominio.Entidades.SAD;

namespace CMACT.SAD.Infraestructura.Datos.SAD.Repositorios.Derivacion
{
    public class EstadoDerivacionRepository : BaseRepository, IEstadoDerivacionRepository
    {
        SadContext loContexto;

        public EstadoDerivacionRepository(string asUsuario)
        {
            Usuario = asUsuario;
            loContexto = new SadContext();
        }

        public IList<dtoEstadoDerivacion> ObtenerTodo()
        {
            return EjecutarConsulta(() =>
            {
                ICollection<ceDcEstadoDerivacion> loEntidad = loContexto.EstadoDerivacion
                    .Where(p => p.IndicadorEstado == EstadoEntidad.Activo)
                    .ToList();

                return loEntidad.Select(p => new dtoEstadoDerivacion()
                {
                    Codigo = p.CodigoEstadoDerivacion,
                    Descripcion = p.DescripcionEstadoDerivacion,
                    Indicador = p.IndicadorEstadoDerivacion
                }).ToList();
            });
        }
    }
}
