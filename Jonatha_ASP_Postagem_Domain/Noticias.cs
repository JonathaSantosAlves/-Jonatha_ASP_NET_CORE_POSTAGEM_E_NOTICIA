using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jonatha_ASP_Postagem_Domain
{
    public class Noticias
    {
        public int ID { get; set; } 
        public DateTime DATA_REGISTRO { get; set; }
        public string? USUARIO { get; set; }
        public string? TITULO { get; set; }
        public string? ARQUIVO { get; set; }
        public string? TIPO { get; set; }

    }
}
