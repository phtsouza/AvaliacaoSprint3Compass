using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cardapio_console
{
    public class Pedido
    {
        [JsonProperty("ValorTotal")]
        public double ValorTotal;
        [JsonProperty("Itens")]
        public List<Produto> pedido = new List<Produto>();

        public void ListarCardapio()
        {
            Cardapio cardapio = new Cardapio();

            Console.WriteLine("CARDÁPIOR LANCHERIA");
            foreach(var produto in cardapio.RetornaLista())
            {
                Console.WriteLine($"Código: {produto.CodigoProduto} || Descrição: {produto.DescricaoProduto} || Valor: {produto.ValorProduto} \n");
            }
            Console.WriteLine("Digite 999 para encerrar seu pedido\n");
        }

        public void AdicionaProduto(Produto produto, int qnt)
        {
            ValorTotal += (produto.ValorProduto * qnt);

            pedido.Add(produto);
        }
        public void PrintPedido()
        {
            string pedidoFinal = string.Empty;

            foreach(var produto in pedido)
            {
                pedidoFinal += $"({produto.CodigoProduto} || {produto.DescricaoProduto} || {produto.ValorProduto}) \n";
            }

            pedidoFinal += $"Valor total pedido: {ValorTotal}";

            Console.WriteLine(pedidoFinal);
        }
    }
}
