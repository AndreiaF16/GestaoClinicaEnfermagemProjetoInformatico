using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public class TratamentoExcisoes
    {
        public DateTime dataTratamento { get; set; }

        public int? nrTratamento { get; set; }

        public string corpoEstranho { get; set; }

        public string dermica { get; set; }

        public string Observacoes { get; set; }

        public string dataProximoTratamento { get; set; }
    }
}
