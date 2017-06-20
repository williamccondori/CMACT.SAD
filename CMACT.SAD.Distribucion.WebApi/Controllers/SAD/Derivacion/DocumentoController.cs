using CMACT.SAD.Aplicacion.DTOs.SAD.Derivacion;
using CMACT.SAD.Aplicacion.DTOs.Shared;
using CMACT.SAD.Aplicacion.Servicios.SAD.Derivacion;
using CMACT.SAD.Distribucion.WebApi.Controllers.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace CMACT.SAD.Distribucion.WebApi.Controllers.SAD.Derivacion
{
    public class DocumentoController : BaseApi
    {
        [HttpPost]
        public object ObtenerXCodigo(EnvioParametros<int> aoDto)
        {
            return Json(EjecutarServicio(() =>
            {
                return new ResultadoOperacion<dtoDocumento>(
                    new DocumentoService(aoDto.Usuario).ObtenerXCodigo(aoDto.Parametros));
            }, aoDto.Usuario, aoDto.Password), new JsonSerializerSettings(), Encoding.UTF8);
        }

        [HttpPost]
        public object ObtenerTodos(EnvioParametros<string> aoDto)
        {
            return Json(EjecutarServicio(() =>
            {
                return new ResultadoOperacion<IList<dtoDocumento>>(
                    new DocumentoService(aoDto.Usuario).ObtenerTodos());
            }, aoDto.Usuario, aoDto.Password), new JsonSerializerSettings(), Encoding.UTF8);
        }

        [HttpPost]
        public object ObtenerTodosXUsuario(EnvioParametros<string> aoDto)
        {
            return Json(EjecutarServicio(() =>
            {
                return new ResultadoOperacion<IList<dtoDocumento>>(
                    new DocumentoService(aoDto.Usuario).ObtenerTodosXUsuario());
            }, aoDto.Usuario, aoDto.Password), new JsonSerializerSettings(), Encoding.UTF8);
        }

        [HttpPost]
        public object BuscarXFecha(EnvioParametros<dtoBusquedaDocumento> aoDto)
        {
            return Json(EjecutarServicio(() =>
            {
                return new ResultadoOperacion<IList<dtoDocumento>>(
                    new DocumentoService(aoDto.Usuario).BuscarXFecha(aoDto.Parametros));
            }, aoDto.Usuario, aoDto.Password), new JsonSerializerSettings(), Encoding.UTF8);
        }

        [HttpPost]
        public object BuscarXFechaXUsuario(EnvioParametros<dtoBusquedaDocumento> aoDto)
        {
            return Json(EjecutarServicio(() =>
            {
                return new ResultadoOperacion<IList<dtoDocumento>>(
                    new DocumentoService(aoDto.Usuario).BuscarXFechaXUsuario(aoDto.Parametros));
            }, aoDto.Usuario, aoDto.Password), new JsonSerializerSettings(), Encoding.UTF8);
        }

        [HttpPost]
        public object Guardar(EnvioParametros<dtoDocumento> aoDto)
        {
            return Json(EjecutarServicio(() =>
            {
                return new ResultadoOperacion<bool>(
                    new DocumentoService(aoDto.Usuario).Guardar(aoDto.Parametros));
            }, aoDto.Usuario, aoDto.Password), new JsonSerializerSettings(), Encoding.UTF8);
        }
        
        [HttpPost]
        public object Eliminar(EnvioParametros<int> aoDto)
        {
            return Json(EjecutarServicio(() =>
            {
                return new ResultadoOperacion<bool>(
                    new DocumentoService(aoDto.Usuario).Eliminar(aoDto.Parametros));
            }, aoDto.Usuario, aoDto.Password), new JsonSerializerSettings(), Encoding.UTF8);
        }
    }
}
