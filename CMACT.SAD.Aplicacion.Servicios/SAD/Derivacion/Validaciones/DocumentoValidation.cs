using CMACT.SAD.Aplicacion.DTOs.SAD.Derivacion;
using CMACT.SAD.Aplicacion.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMACT.SAD.Aplicacion.Servicios.SAD.Derivacion.Validaciones
{
    public class DocumentoValidation
    {
        public void Validar(dtoDocumento aoDto)
        {
            if(aoDto.ContenidoArchivo == null)
                throw new Exception(ResultadoMensaje.DocumentoIncorrecto);

            if (aoDto.ListaDerivacionDocumento.Count <= 0)
                throw new Exception(ResultadoMensaje.JefaturaIncorrecta);
        }
    }
}
