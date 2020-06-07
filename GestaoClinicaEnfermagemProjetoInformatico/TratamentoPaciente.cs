using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    class TratamentoPaciente
    {
        public string data { get; set; }
        public int? numeroTratamento { get; set; }
        public string dimensoes { get; set; }
        public string grau { get; set; }
        public string exsudado { get; set; }
        public string tecidoPredominante { get; set; }
        public string areaCircundante { get; set; }
        public string agenteLimpeza { get; set; }
        public string aplicacaoFerida { get; set; }
        public string aplicacaoAreaCircundante { get; set; }
        public string aplicacaoPenso { get; set; }
        public int? aplicacaoTamanho { get; set; }
        public string aplicacaoSuportePenso { get; set; }
        public string ProximoTratamento { get; set; }
        public string Observacoes { get; set; }
        public string EscalaDor { get; set; }

        public string tipoQueimadura { get; set; }

    }
}
