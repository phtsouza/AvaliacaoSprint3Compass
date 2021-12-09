using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace cardapio_console
{
    public class Produto
    {
        [JsonProperty("Codigo")]
        public int CodigoProduto { get; set; }
        [JsonProperty("Descricao")]
        public string DescricaoProduto { get; set; }
        [JsonIgnore]
        public double ValorProduto { get; set; }

        public Produto(int codigoProduto, string descricaoProduto, double valorProduto)
        {
            CodigoProduto = codigoProduto;
            DescricaoProduto = descricaoProduto;
            ValorProduto = valorProduto;
        }
    }
}
