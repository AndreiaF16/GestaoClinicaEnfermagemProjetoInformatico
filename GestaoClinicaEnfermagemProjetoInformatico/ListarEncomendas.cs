using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public class ListarEncomendas
    {
        public string nome { get; set; }
        public decimal preco { get; set; }
        public int iva { get; set; }
        public int quant { get; set; }
        public decimal totalProdutoSIVA { get; set; }
        public decimal totalProdutCIVA { get; set; }

        public int id { get; set; }
    }
}
