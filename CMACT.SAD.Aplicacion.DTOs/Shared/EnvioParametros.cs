using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMACT.SAD.Aplicacion.DTOs.Shared
{
    public class EnvioParametros<TContenido>
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
        public TContenido Parametros { get; set; }

        public EnvioParametros()
        {

        }

        public EnvioParametros(
            string asUsuario
            , string asPassword
            , TContenido aoParametros
            )
        {
            this.Usuario = asUsuario;
            this.Password = asPassword;
            this.Parametros = aoParametros;
        }

        public EnvioParametros(
            string asUsuario
            , string asPassword
        )
        {
            this.Usuario = asUsuario;
            this.Password = asPassword;
        }
    }
}
