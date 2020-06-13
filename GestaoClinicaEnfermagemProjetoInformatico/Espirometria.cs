using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public class Espirometria
    {
        public string dataEspirometria { get; set; }
        public string fev { get; set; }
        public string fvc { get; set; }
        public int? numerofr { get; set; }
        public string superficial { get; set; }
        public string profunda { get; set; }
        public string abdominal { get; set; }
        public string toracica { get; set; }
        public string mista { get; set; }
        public string escalaDor { get; set; }
        public string observacoes { get; set; }
    }
}
