using CMACT.SAD.Aplicacion.DTOs.SAF;
using CMACT.SAD.Aplicacion.Servicios.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMACT.SAD.Aplicacion.Servicios.SAF
{
    public class JefaturaService : BaseService
    {
        public JefaturaService(string asUsuario)
        {
            this.Usuario = asUsuario;
        }

        public IList<dtoJefatura> ObtenerTodos()
        {
            List<dtoJefatura> ListaJefatura = new List<dtoJefatura>();

            ListaJefatura.Add(new dtoJefatura()
            {
                NombreUnidadOrganica = "USICN",
                NumeroUnidadOrganica = "2",
                CodigoEncargado = "RALANOCA",
                NombreEncargado = "RODOLFO ALANOCA"
            });
            ListaJefatura.Add(new dtoJefatura()
            {
                NombreUnidadOrganica = "TIC",
                NumeroUnidadOrganica = "3",
                CodigoEncargado = "WQUISPE",
                NombreEncargado = "WILBER QUISPE"
            });

            ListaJefatura.Add(new dtoJefatura()
            {
                NombreUnidadOrganica = "LOGISTICA",
                NumeroUnidadOrganica = "4",
                CodigoEncargado = "RVALCARCEL",
                NombreEncargado = "RICARDO VALCARCEL"
            });

            ListaJefatura.Add(new dtoJefatura()
            {
                NombreUnidadOrganica = "ÁREA DE PRUEBAS",
                NumeroUnidadOrganica = "5",
                CodigoEncargado = "PWCONDORI",
                NombreEncargado = "WILLIAM CONDORI QUISPE"
            });

            return ListaJefatura;
        }
    }
}
