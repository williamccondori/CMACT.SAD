using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMACT.SAD.Aplicacion.DTOs.Shared
{
    public class ResultadoOperacion<TContenido>
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public TipoMensaje TipoMensaje { get; set; }
        public TContenido Datos { get; set; }

        public ResultadoOperacion()
        {

        }

        public ResultadoOperacion(TContenido aoDatos)
        {
            Error = false;
            Mensaje = string.Empty;
            TipoMensaje = TipoMensaje.Cliente;
            Datos = aoDatos;
        }

        public ResultadoOperacion(TContenido aoDatos, string asMensaje, TipoMensaje aoTipoMensaje)
        {
            Error = true;
            Mensaje = asMensaje;
            TipoMensaje = aoTipoMensaje;
            Datos = aoDatos;
        }
    }

    public enum TipoMensaje
    {
        Error,
        Advertencia,
        Cliente
    }
}
