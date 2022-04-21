using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LI.Carrinho.Domain.Entities
{
    public class RetornoExcecao
    {
        public string Mensagem { get; set; }
        public List<CodigoMensagemErro> Erros { get; set; }
    }

    public class CodigoMensagemErro
    {
        public int CdErro { get; set; }
        public string DsErro { get; set; }
        public string Info { get; set; }
    }
}
