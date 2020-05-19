using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public class Encomendas
    {
        public string NFatura { get; set; }
        public string nome { get; set; }
        public string dataRegisto { get; set; }
        public string dataEntregaPrevista { get; set; }
        public string dataEntregaReal { get; set; }

        public int IdEncomenda { get; set; }
    }
}
