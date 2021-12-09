using Newtonsoft.Json;
using System;
using System.Linq;

namespace cardapio_console
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exibeMenu = true;
            while (exibeMenu)
            {
                exibeMenu = Menu();
            }
        }

        private static bool Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;

                Console.Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒ PEDIDOS ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒"); 
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("╔═════════════════MENU DE OPÇÕES════════════════╗    ");
            Console.WriteLine("║ 1 EFETUAR PEDIDO                              ║    ");
            Console.WriteLine("║ 2 SAIR                                        ║    ");
            Console.WriteLine("╚═══════════════════════════════════════════════╝    ");

            Console.WriteLine(" ");
            Console.Write("DIGITE UMA OPÇÃO : ");
            
            switch (Console.ReadLine())
             {
                case "1":
                    Pedido();
                    return true;
                case "2":
                    return false;
                default:
                    return true;
            }
        }

        private static void Pedido()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();

            Console.Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒  CENTRAL PEDIDOS  ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.WriteLine(" ");
            Console.WriteLine();
            Console.WriteLine();

            Pedido novoPedido = new Pedido();
            int[] mesas = { 1, 2, 3, 4 };
            int mesaDesejada;
            while (true)
            {
                Console.Write("Informe o número da mesa(1 a 4): ");
                mesaDesejada = int.Parse(Console.ReadLine());

                if(mesas.Any(m => m == mesaDesejada))
                {
                    RealizaPedido();
                    break;
                }
                else
                {
                    Console.WriteLine("Mesa inválida, tente novamente!");
                }
            }

            Console.Write("Pressione uma tecla para continuar...");
            Console.ReadKey();
        }
        
        private static void RealizaPedido()
        {
            Cardapio cardapio = new Cardapio();
            Pedido pedido = new Pedido();
            int codProduto;
            int qntProduto;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();

                Console.Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒  CARDÁPIO  ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                Console.WriteLine(" ");
                Console.WriteLine();
                Console.WriteLine();
                pedido.ListarCardapio();
                Console.Write("Digite o código do produto desejado: ");
                codProduto = int.Parse(Console.ReadLine());

                Produto produtoAux = null;

                if(cardapio.RetornaLista().Any(x => x.CodigoProduto == codProduto))
                {
                    foreach(var produto in cardapio.RetornaLista())
                    {
                        if(produto.CodigoProduto == codProduto)
                        {
                            produtoAux = produto;
                        }
                    }
                    Console.Write($"Qual a quantidade do {produtoAux.DescricaoProduto} desejada: ");
                    qntProduto = int.Parse(Console.ReadLine());

                    pedido.AdicionaProduto(produtoAux, qntProduto);
                }
                else if(codProduto == 999)
                {
                    Console.Write("Pedido finalizado\n");
                    pedido.PrintPedido();
                    Console.WriteLine();
                    var dadosJson = JsonConvert.SerializeObject(pedido, Formatting.Indented);
                    Console.WriteLine(dadosJson);
                    break;
                }
                else
                {
                    Console.WriteLine("Código de produto inválido");
                }
            }
        }
    }
}
