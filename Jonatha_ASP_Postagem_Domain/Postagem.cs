using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jonatha_ASP_Postagem_Domain
{
    public class Postagem
    {
        public int ID { get; set; } 
        public DateTime DATA_REGISTRO { get; set; }
        public string? USUARIO { get; set; } 
        public string? TITULO { get; set; } 
        public string? ARQUIVO { get; set; }    
        public int CURTIDA { get; set; }
        public string? DESCRICAO { get; set; }
        public string? TIPO { get; set; }

    }
}
