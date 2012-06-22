using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mobileCRM.Models
{
    public partial class Visita
    {
        public IList<Clientes> BuscaClienteByTipo(int tipoCliente)
        {
            return new VisitaRepository().BuscaClienteByTipo(tipoCliente);
        }
    }
}