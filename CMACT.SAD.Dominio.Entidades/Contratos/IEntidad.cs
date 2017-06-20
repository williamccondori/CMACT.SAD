using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMACT.SAD.Dominio.Entidades.Contratos
{
	public interface IEntidad : IEstadoEntidad, IEstadoObjeto
	{
		string CodigoUsuarioRegistro { get; set; }
		string CodigoUsuarioModifico { get; set; }
		DateTime? FechaRegistro { get; set; }
		DateTime? FechaModifico { get; set; }
	}
}
