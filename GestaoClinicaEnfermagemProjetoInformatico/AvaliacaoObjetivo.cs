using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public class AvaliacaoObjetivo
    {
        public string data { get; set; }
        public decimal peso { get; set; }
        public int altura { get; set; }
        public decimal IMC { get; set; }
        public int pressaoArterial { get; set; }
        public int? frequenciaCardiaca { get; set; }
        public decimal? temperatura { get; set; }
        public int? saturacaoOxigenio { get; set; }
        public string dataUltimaMestruacao { get; set; }
        public int? menopausa { get; set; }
       // public int IdMetodoContracetivo { get; set; }
        public string nomeMetodo { get; set; }

        public string DIU { get; set; }
        public int? concentracaoGlicoseSangue { get; set; }
        public int? AC { get; set; }
        public int? AP { get; set; }
        public int? INR { get; set; }
        public int? Menarca { get; set; }
        public int? gravidez { get; set; }
        public int? filhosVivos { get; set; }
        public int? abortos { get; set; }
        public string observacoes { get; set; }

    }
}
