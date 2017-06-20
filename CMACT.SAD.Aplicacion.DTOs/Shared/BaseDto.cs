using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMACT.SAD.Aplicacion.DTOs.Shared
{
    public class BaseDto
    {
        public EstadoObjeto EstadoObjeto { get; set; }
    }

    public enum EstadoObjeto
    {
        SinCambios,
        Nuevo,
        Modificado,
        Borrado
    }
}
