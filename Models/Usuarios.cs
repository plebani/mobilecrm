using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mobileCRM.Models
{
    public class Usuarios
    {
        public int Handle   { get; set; }
        public string Nome  { get; set; }
        public string Senha { get; set; } 

        public Usuarios()
        {
             
        }
    }
}