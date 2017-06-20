using CMACT.SAD.Aplicacion.DTOs.SAD.Derivacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMACT.SAD.Presentacion.Web.Models.Configuracion
{
    public class InicioViewModel
    {
        public List<dtoTipoDocumento> ListaTipoDocumento { get; set; }
        public dtoTipoDocumento ObjetoTipoDocumento { get; set; }

        public InicioViewModel()
        {
            ListaTipoDocumento = new List<dtoTipoDocumento>();
            ObjetoTipoDocumento = new dtoTipoDocumento();
        }
    }
}