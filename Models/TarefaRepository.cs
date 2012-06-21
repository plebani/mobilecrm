using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mobileCRM.Models
{
    public class TarefaRepository : IRepositoryTarefas
    {
        private CRMEntities db;

        #region Construtor
        public TarefaRepository() 
        {
            db = new CRMEntities(); 
        }
        #endregion

        #region Metodos de Pesquisa

        public IList<Tarefa> BuscaTodas()
        {
            var tarefas = from c in db.Tarefas
                     select c;

            return tarefas.ToList(); 
        }

        public IList<Tarefa> BuscaTodasByUsuario(int handleUsuario)
        {
            var tarefas = from c in db.Tarefas
                          where c.IDUsuario.Equals(handleUsuario)
                          select c;

            return tarefas.ToList(); 
        }

        #endregion

    }
}