using CMACT.SAD.Aplicacion.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CMACT.SAD.Distribucion.WebApi.Controllers.Shared
{
    public class BaseApi : ApiController
    {
        public string Usuario { get; set; }
        public string Password { get; set; }

        protected ResultadoOperacion<T> EjecutarServicio<T>(Func<ResultadoOperacion<T>> aoFuncionEjecutado, string asUsuario, string asPassword)
        {
            try
            {
                //Impersonalizacion
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
            finally
            {
                //Undoimpersonalizacion
            }
        }
    }
}