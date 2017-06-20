using CMACT.SAD.Aplicacion.DTOs.SAF;
using CMACT.SAD.Aplicacion.DTOs.Shared;
using CMACT.SAD.Aplicacion.Servicios.SAF;
using CMACT.SAD.Distribucion.WebApi.Controllers.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace CMACT.SAD.Distribucion.WebApi.Controllers.SAF
{
    public class JefaturaController : BaseApi
    {
        [HttpPost]
        public object ObtenerTodos(EnvioParametros<string> aoDto)
        {
            return Json(EjecutarServicio(() =>
            {
                return new ResultadoOperacion<IList<dtoJefatura>>(
                    new JefaturaService(aoDto.Usuario).ObtenerTodos());
            }, aoDto.Usuario, aoDto.Password), new JsonSerializerSettings(), Encoding.UTF8);
        }
    }
}
