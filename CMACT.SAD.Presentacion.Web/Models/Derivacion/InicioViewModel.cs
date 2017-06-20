using CMACT.SAD.Aplicacion.DTOs.SAD.Derivacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMACT.SAD.Presentacion.Web.Models.Derivacion
{
    public class InicioViewModel
    {
        public dtoReporteDerivacion ObjetoReporte  { get; set; }
        public List<dtoEstadoDerivacion> ListaEstadoDerivacion { get; set; }

        public InicioViewModel()
        {
            ObjetoReporte = new dtoReporteDerivacion();
            ListaEstadoDerivacion = new List<dtoEstadoDerivacion>();
        }
    }
}