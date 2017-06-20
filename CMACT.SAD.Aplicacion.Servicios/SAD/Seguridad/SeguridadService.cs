using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMACT.SAD.Aplicacion.DTOs.SAD.Inicio;
using CMACT.SAD.Aplicacion.Servicios.Shared;

namespace CMACT.SAD.Aplicacion.Servicios.SAD.Seguridad
{
    public class SeguridadService : BaseService
    {

        public SeguridadService(string asUsuario)
        {
            Usuario = asUsuario;
        }

        public bool ValidarUsuario(dtoLogin aoDto)
        {
            return true;
        }
    }
}
