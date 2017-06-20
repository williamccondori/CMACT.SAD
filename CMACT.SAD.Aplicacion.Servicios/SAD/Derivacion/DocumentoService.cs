using CMACT.SAD.Aplicacion.Servicios.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMACT.SAD.Aplicacion.DTOs.SAD.Derivacion;
using CMACT.SAD.Aplicacion.DTOs.Shared;
using CMACT.SAD.Aplicacion.Servicios.SAD.Derivacion.Validaciones;
using CMACT.SAD.Dominio.Logica.SAD;
using CMACT.SAD.Infraestructura.Datos.SAD.Repositorios.Derivacion;

namespace CMACT.SAD.Aplicacion.Servicios.SAD.Derivacion
{
    public class DocumentoService : BaseService
    {
        DocumentoValidation loValidacion;

        IDocumentoRepository loRepositorioDocumento;

        public DocumentoService(string asUsuario)
        {
            Usuario = asUsuario;
            loRepositorioDocumento = new DocumentoRepository(Usuario);
        }

        public dtoDocumento ObtenerXCodigo(int aiCodigo)
        {
            return loRepositorioDocumento.ObtenerXCodigo(aiCodigo);
        }

        public IList<dtoDocumento> ObtenerTodos()
        {
            IList<dtoDocumento> loDatos = loRepositorioDocumento.ObtenerTodo();

            foreach (var loElemento in loDatos)
                loElemento.ContenidoArchivo = null;

            return loDatos;
        }

        public IList<dtoDocumento> ObtenerTodosXUsuario()
        {
            IList<dtoDocumento> loRespuesta = new List<dtoDocumento>();

            IList<dtoDocumento> loDocumentos = loRepositorioDocumento.ObtenerTodo();

            foreach (var loDocumento in loDocumentos)
                foreach (var loDerivacion in loDocumento.ListaDerivacionDocumento)
                    if (loDerivacion.CodigoUsuario == Usuario)
                        loRespuesta.Add(ObtenerXCodigo(loDerivacion.CodigoDocumento));

            foreach (var loDocumento in loRespuesta)
            {
                loDocumento.ContenidoArchivo = null;
                loDocumento.ObjetoDerivacionDocumento = loDocumento.ListaDerivacionDocumento
                    .Where(p => p.CodigoUsuario == Usuario)
                    .FirstOrDefault();
            }

            return loRespuesta;
        }

        public IList<dtoDocumento> BuscarXFecha(dtoBusquedaDocumento aoDto)
        {
            IList<dtoDocumento> loDatos = loRepositorioDocumento.BuscarXFecha(aoDto);
            
            foreach (var loElemento in loDatos)
                loElemento.ContenidoArchivo = null;

            return loDatos;
        }

        public IList<dtoDocumento> BuscarXFechaXUsuario(dtoBusquedaDocumento aoDto)
        {
            IList<dtoDocumento> loRespuesta = new List<dtoDocumento>();

            IList<dtoDocumento> loDocumentos = loRepositorioDocumento.BuscarXFecha(aoDto);

            foreach (var loDocumento in loDocumentos)
                foreach (var loDerivacion in loDocumento.ListaDerivacionDocumento)
                    if (loDerivacion.CodigoUsuario == Usuario)
                        loRespuesta.Add(ObtenerXCodigo(loDerivacion.CodigoDocumento));

            foreach (var loDocumento in loRespuesta)
            {
                loDocumento.ContenidoArchivo = null;
                loDocumento.ObjetoDerivacionDocumento = loDocumento.ListaDerivacionDocumento
                    .Where(p => p.CodigoUsuario == Usuario)
                    .FirstOrDefault();
            }

            return loRespuesta;
        }

        public bool Guardar(dtoDocumento aoDto)
        {
            loValidacion = new DocumentoValidation();
            loValidacion.Validar(aoDto);

            return loRepositorioDocumento.Guardar(aoDto);
        }

        public bool Eliminar(int aiCodigo)
        {
            return loRepositorioDocumento.Eliminar(aiCodigo);
        }
    }
}
