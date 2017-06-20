using CMACT.SAD.Aplicacion.DTOs.Shared;
using CMACT.SAD.Presentacion.Web.Models.Derivacion;
using CMACT.SAD.Web.Utilidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CMACT.SAD.Presentacion.Web.Controllers
{
    public class BaseInicioController : Controller
    {
        protected ResultadoOperacion<T> EjecutarPeticion<T>(Func<ResultadoOperacion<T>> aoFuncionEjecutado)
        {
            try
            {
                return aoFuncionEjecutado();
            }
            catch (ApplicationException ex)
            {
                return new ResultadoOperacion<T>(
                    default(T)
                    , ex.Message
                    , TipoMensaje.Advertencia);
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion<T>(
                    default(T)
                    , ex.Message
                    , TipoMensaje.Error);
            }
        }

        protected ResultadoOperacion<T> Post<T>(string asCadenaEnvio, string asRutaApi)
        {
            HttpResponseMessage loRespuestaJSON = new HttpClient().PostAsync(
                asRutaApi
                , new StringContent(
                    asCadenaEnvio
                    , Encoding.UTF8
                    , "application/json")).Result;

            ResultadoOperacion<T> loRespuesta =
                JsonConvert.DeserializeObject<ResultadoOperacion<T>>(loRespuestaJSON.Content.ReadAsStringAsync().Result);

            if (loRespuesta.Error) throw new Exception(loRespuesta.Mensaje); else return loRespuesta;
        }

        protected void EstablecerMensajeError(string asMensaje)
        {
            TempData["Incorrecto"] = asMensaje;
        }

        protected void EstablecerMensajeCorrecto(string asMensaje)
        {
            TempData["Correcto"] = asMensaje;
        }
    }
}