using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public class ClassFornecedor
    {
        public string nome { get; set; }
        public int? nif { get; set; }
        public int? contacto { get; set; }
        public string email { get; set; }
        
        public string rua { get; set; }
        public int? numeroMorada { get; set; }
        public string andarPiso { get; set; }
        public string localidade { get; set; }
        public string bairroLocal { get; set; }
        public string codigoPostal { get; set; }
        //  public string codPrefixo { get; set; }
        // public string codSufixo { get; set; }
        public string designacao { get; set; }
        public string observacoes { get; set; }
        public int IdFornecedor { get; set; }

    }
}
