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
    public class DerivacionDocumentoController : BaseApi
    {
        [HttpPost]
        public object Leer(EnvioParametros<dtoDerivacionDocumento> aoDto)
        {
            return Json(EjecutarServicio(() =>
            {
                return new ResultadoOperacion<bool>(
                    new DerivacionDocumentoService(aoDto.Usuario).Leer(aoDto.Parametros));
            }, aoDto.Usuario, aoDto.Password), new JsonSerializerSettings(), Encoding.UTF8);
        }

        [HttpPost]
        public object Aceptar(EnvioParametros<dtoDerivacionDocumento> aoDto)
        {
            return Json(EjecutarServicio(() =>
            {
                return new ResultadoOperacion<bool>(
                    new DerivacionDocumentoService(aoDto.Usuario).Aceptar(aoDto.Parametros));
            }, aoDto.Usuario, aoDto.Password), new JsonSerializerSettings(), Encoding.UTF8);
        }

        [HttpPost]
        public object Devolver(EnvioParametros<dtoDerivacionDocumento> aoDto)
        {
            return Json(EjecutarServicio(() =>
            {
                return new ResultadoOperacion<bool>(
                    new DerivacionDocumentoService(aoDto.Usuario).Devolver(aoDto.Parametros));
            }, aoDto.Usuario, aoDto.Password), new JsonSerializerSettings(), Encoding.UTF8);
        }
    }
}
