using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mobileCRM.Models
{
    public class Tarefa
    {
        public string Assunto { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataConclusao { get; set; }
        public DateTime DataAgendada { get; set; }
        public DateTime DataLembrete { get; set; }
        public bool Lembrete { get; set; }
        public bool AgendarTarefa { get; set; }
        public long IdUsuario { get; set; }

        public Tarefa()
        {
            
        }
    }
}
