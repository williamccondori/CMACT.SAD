using CMACT.SAD.Aplicacion.DTOs.SAD.Inicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMACT.SAD.Presentacion.Web.Models.Inicio
{
    public class LoginViewModel
    {
        public dtoLogin ObjetoLogin { get; set; }

        public LoginViewModel()
        {
            ObjetoLogin = new dtoLogin();
        }
    }
}