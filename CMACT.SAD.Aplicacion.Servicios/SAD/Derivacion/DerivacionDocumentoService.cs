using CMACT.SAD.Aplicacion.Servicios.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMACT.SAD.Aplicacion.DTOs.SAD.Derivacion;
using CMACT.SAD.Infraestructura.Datos.SAD.Repositorios.Derivacion;
using CMACT.SAD.Dominio.Logica.SAD;

namespace CMACT.SAD.Aplicacion.Servicios.SAD.Derivacion
{
    public class DerivacionDocumentoService : BaseService
    {
        IDerivacionDocumentoRepository loRepositorioDerivacionDocumento;
        IEstadoDerivacionRepository loRepositorioEstadoDerivacion;

        public DerivacionDocumentoService()
        {

        }

        public DerivacionDocumentoService(string asUsuario)
        {
            Usuario = asUsuario;
            loRepositorioDerivacionDocumento = new DerivacionDocumentoRepository(Usuario);
            loRepositorioEstadoDerivacion = new EstadoDerivacionRepository(Usuario);
        }

        public bool Leer(dtoDerivacionDocumento aoDto)
        {
            dtoEstadoDerivacion loEstadoActual = loRepositorioEstadoDerivacion.ObtenerTodo()
                            .SingleOrDefault(p => p.Codigo == aoDto.CodigoEstado);

            if (loEstadoActual.Indicador != EstadoDerivacionDocumento.Derivado)
                return true;

            dtoEstadoDerivacion loEstado = loRepositorioEstadoDerivacion.ObtenerTodo()
                            .SingleOrDefault(p => p.Indicador == EstadoDerivacionDocumento.Leido);

            aoDto.CodigoEstado = loEstado.Codigo;
            aoDto.EstadoObjeto = DTOs.Shared.EstadoObjeto.Modificado;
            
            return loRepositorioDerivacionDocumento.CambiarEstado(aoDto);
        }

        public bool Aceptar(dtoDerivacionDocumento aoDto)
        {
            dtoEstadoDerivacion loEstadoActual = loRepositorioEstadoDerivacion.ObtenerTodo()
                           .SingleOrDefault(p => p.Codigo == aoDto.CodigoEstado);

            if (loEstadoActual.Indicador != EstadoDerivacionDocumento.Leido)
                return true;

            dtoEstadoDerivacion loEstado = loRepositorioEstadoDerivacion.ObtenerTodo()
                            .SingleOrDefault(p => p.Indicador == EstadoDerivacionDocumento.Aceptado);

            aoDto.CodigoEstado = loEstado.Codigo;
            aoDto.EstadoObjeto = DTOs.Shared.EstadoObjeto.Modificado;

            return loRepositorioDerivacionDocumento.CambiarEstado(aoDto);
        }

        public bool Devolver(dtoDerivacionDocumento aoDto)
        {
            dtoEstadoDerivacion loEstadoActual = loRepositorioEstadoDerivacion.ObtenerTodo()
                           .SingleOrDefault(p => p.Codigo == aoDto.CodigoEstado);

            if (loEstadoActual.Indicador != EstadoDerivacionDocumento.Leido)
                return true;

            dtoEstadoDerivacion loEstado = loRepositorioEstadoDerivacion.ObtenerTodo()
                .SingleOrDefault(p => p.Indicador == EstadoDerivacionDocumento.Devuelto);

            aoDto.CodigoEstado = loEstado.Codigo;
            aoDto.EstadoObjeto = DTOs.Shared.EstadoObjeto.Modificado;

            return loRepositorioDerivacionDocumento.CambiarEstado(aoDto);
        }
    }
}
