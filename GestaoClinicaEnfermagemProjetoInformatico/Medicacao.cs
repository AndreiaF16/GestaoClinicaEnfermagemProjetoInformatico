using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    class Medicacao
    {
        public string data { get; set; }

        public string medicamentos { get; set; }
        public string jejum { get; set; }
        public string quantJejum { get; set; }
        public string peqAlmoco { get; set; }
        public string quantPeqAlmoco { get; set; }
        public string almoco { get; set; }
        public string quantAlmoco { get; set; }

        public string lanche { get; set; }
        public string quantLanche { get; set; }

        public string jantar { get; set; }
        public string quantJantar { get; set; }

        public string deitar { get; set; }
        public string quantDeitar{ get; set; }

        public string observacoes { get; set; }


    }
}
