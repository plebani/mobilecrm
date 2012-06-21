using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mobileCRM.Models
{
    public class VisitaRepository : IRepositoryVisitas
    {
        private CRMEntities db;

        #region Construtor
        public VisitaRepository() 
        {
            db = new CRMEntities(); 
        }
        #endregion

        #region Metodos de Pesquisa

        public IList<Visita> BuscaTodas()
        {
            var visitas = from c in db.Visitas
                     select c;

            return visitas.ToList(); 
        }

        public IList<Visita> BuscaTodasByUsuario(int handleUsuario)
        {
            var visitas = from c in db.Visitas
                          where c.IDUsuario.Equals(handleUsuario)
                          select c;

            return visitas.ToList(); 
        }


        public Visita BuscaByHandle(int handle)
        {
            var visitas = db.Visitas.Where(p => p.Handle == handle).FirstOrDefault();

            return visitas; 
        }

        #endregion

    }
}