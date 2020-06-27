using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public class TratamentosAnteriores
    {
        public DateTime dataTratamento { get; set; }
        public string tipoTratamento { get; set; }

        public int? nrTratamento { get; set; }

        public string dimensoes { get; set; }

        public string grauUlceraPressao { get; set; }

        public string exsudadoTipo { get; set; }

        public int? exsudadoQuantidade { get; set; }

        public string exsudadoCheiro { get; set; }
        public string tecidoPredominante { get; set; }
        public string areaCircundante { get; set; }
        public string agenteLimpeza { get; set; }
        public string aplicacaoFerida { get; set; }
        public string aplicacaoAreaCircundante { get; set; }
        public string aplicacaoPenso { get; set; }
        public int? aplicacaoTamanho { get; set; }
        public string aplicacaoSuportePenso { get; set; }

        public string Observacoes { get; set; }
       
        public string ProximoTratamento { get; set; }

        public string EscalaDor { get; set; }
        public string tipoQueimadura { get; set; }
        public string IPTB { get; set; }
        public string tipoUlcera { get; set; }

    }

}
