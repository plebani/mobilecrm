using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mobileCRM.Models
{
    public interface IRepositoryVisitas
    {
        IList<Visita> BuscaTodas();
        IList<Visita> BuscaTodasByUsuario(int handleUsuario);
        Visita BuscaByHandle(int handle);
    }
}