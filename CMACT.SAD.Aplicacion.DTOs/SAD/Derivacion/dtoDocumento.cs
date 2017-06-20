using CMACT.SAD.Aplicacion.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMACT.SAD.Aplicacion.DTOs.SAD.Derivacion
{
    public class dtoDocumento : BaseDto
    {
        public int Codigo { get; set; }
        public int CodigoTipo { get; set; }
        public dtoTipoDocumento ObjetoTipoDocumento { get; set; }
        public string Numero { get; set; }
        public string OrganoEmisor { get; set; }
        public string Asunto { get; set; }
        public string NombreArchivo { get; set; }
        public byte[] ContenidoArchivo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public dtoDerivacionDocumento ObjetoDerivacionDocumento { get; set; }
        public List<dtoDerivacionDocumento> ListaDerivacionDocumento { get; set; }

        public dtoDocumento()
        {
            ObjetoTipoDocumento = new dtoTipoDocumento();
            ObjetoDerivacionDocumento = new dtoDerivacionDocumento();
            ListaDerivacionDocumento = new List<dtoDerivacionDocumento>();
        }
    }

    public enum DocumentoOperacion
    {
        Todos,
        TodosXUsuario,
        BuscarXFecha,
        BuscarXFechaXUsuario
    }
}
