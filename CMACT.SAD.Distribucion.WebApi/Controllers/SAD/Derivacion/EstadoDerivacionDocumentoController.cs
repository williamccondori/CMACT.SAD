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
    public class EstadoDerivacionDocumentoController : BaseApi
    {
        [HttpPost]
        public object ObtenerTodos(EnvioParametros<string> aoDto)
        {
            return Json(EjecutarServicio(() =>
            {
                return new ResultadoOperacion<IList<dtoEstadoDerivacion>>(
                    new EstadoDerivacionService(aoDto.Usuario).ObtenerTodos());
            }, aoDto.Usuario, aoDto.Password), new JsonSerializerSettings(), Encoding.UTF8);
        }
    }
}
