using CMACT.SAD.Aplicacion.DTOs.SAD.Inicio;
using CMACT.SAD.Aplicacion.DTOs.Shared;
using CMACT.SAD.Aplicacion.Servicios.SAD.Seguridad;
using CMACT.SAD.Distribucion.WebApi.Controllers.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace CMACT.SAD.Distribucion.WebApi.Controllers.SAD.Seguridad
{
    public class SeguridadController : BaseApi
    {
        [HttpPost]
        public object ValidarUsuario(EnvioParametros<dtoLogin> aoDto)
        {
            return Json(EjecutarServicio(() =>
            {
                return new ResultadoOperacion<bool>(
                    new SeguridadService(aoDto.Usuario).ValidarUsuario(aoDto.Parametros));
            }, aoDto.Usuario, aoDto.Password), new JsonSerializerSettings(), Encoding.UTF8);
        }
    }
}
