using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public class Enfermeiro
    {
        public int IdEnfermeiro { get; set; }
        public string nome { get; set; }
        public string funcao { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public int permissao { get; set; }
    }
}
