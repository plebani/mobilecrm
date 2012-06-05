using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mobileCRM.Models
{
    public class Visita
    {
        public string Assunto { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataConclusao { get; set; }
        public DateTime DataAgendada { get; set; }
        public bool Lembrete { get; set; }
        public bool AgendarTarefa { get; set; }
        public bool ClienteBase { get; set; }
        public List<int> TipoTarefa { get; set; }

        public Visita()
        {
            
        }
    }
}
