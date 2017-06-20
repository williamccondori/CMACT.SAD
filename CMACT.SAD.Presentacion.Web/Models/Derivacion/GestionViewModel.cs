using CMACT.SAD.Aplicacion.DTOs.SAD.Derivacion;
using CMACT.SAD.Aplicacion.DTOs.SAF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMACT.SAD.Presentacion.Web.Models.Derivacion
{
    public class GestionViewModel
    {
        public dtoBusquedaDocumento ObjetoBusquedaDocumento { get; set; }
        public dtoDocumento ObjetoDocumento { get; set; }
        public List<dtoDocumento> ListaDocumento { get; set; }
        public List<dtoTipoDocumento> ListaTipoDocumento { get; set; }
        public List<dtoJefatura> ListaJefatura { get; set; }

        public GestionViewModel()
        {
            ObjetoDocumento = new dtoDocumento();
            ObjetoBusquedaDocumento = new dtoBusquedaDocumento();
            ListaDocumento = new List<dtoDocumento>();
            ListaTipoDocumento = new List<dtoTipoDocumento>();
            ListaJefatura = new List<dtoJefatura>();
        }
    }
}