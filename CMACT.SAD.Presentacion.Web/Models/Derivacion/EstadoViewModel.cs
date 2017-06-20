using CMACT.SAD.Aplicacion.DTOs.SAD.Derivacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMACT.SAD.Presentacion.Web.Models.Derivacion
{
    public class EstadoViewModel
    {
        public dtoBusquedaDocumento ObjetoBusquedaDocumento { get; set; }
        public List<dtoDocumento> ListaDocumento { get; set; }

        public EstadoViewModel()
        {
            ObjetoBusquedaDocumento = new dtoBusquedaDocumento();
            ListaDocumento = new List<dtoDocumento>();
        }
    }
}