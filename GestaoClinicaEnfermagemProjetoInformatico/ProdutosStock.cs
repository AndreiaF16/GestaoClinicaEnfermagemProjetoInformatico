using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public class ProdutosStock
    {
        public string nome { get; set; }

        public string nomeFornecedor { get; set; }
        public int quantidade { get; set; }

        public int iva { get; set; }

        public decimal preco { get; set; }

        public string observacoes { get; set; }

        public decimal precoTotal { get; set; }
    }
}
