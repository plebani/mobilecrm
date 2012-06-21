using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mobileCRM.Models
{
    public interface IRepositoryTarefas
    {
        IList<Tarefa> BuscaTodas();
        IList<Tarefa> BuscaTodasByUsuario(int handleUsuario);
    }
}