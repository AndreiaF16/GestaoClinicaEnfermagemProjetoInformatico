using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    class AvaliacaoObjetivaBebe
    {
        public string dataRegisto { get; set; }
        public decimal Peso { get; set; }
        public int Altura { get; set; }
        public int? pressaoArterial { get; set; }
        public int? frequenciaCardiaca { get; set; }
        public decimal? temperatura { get; set; }
        public int? saturacaoOxigenio { get; set; }
        public int? INR { get; set; }
        public int? Perimetro { get; set; }
        //public int IdTipoAleitamento { get; set; }
        public string tipoAleitamento { get; set; }
        public string nomeLeiteArtificial { get; set; }
        // public int IdTipoParto { get; set; }
         public string tipoParto { get; set; }

        public string partoDistocico { get; set; }
        public string epidural { get; set; }
        public string episiotomia { get; set; }
        public string reanimacaoFetal { get; set; }
        public string indiceAPGAR { get; set; }
        public string Fototerapia { get; set; }
        public string observacoes { get; set; }
        public decimal IMC { get; set; }

    }
}
