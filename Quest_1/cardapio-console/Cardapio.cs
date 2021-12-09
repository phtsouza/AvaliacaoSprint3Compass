using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cardapio_console
{
    public class Cardapio
    {
        private static List<Produto> CardapioProdutos = new List<Produto>()
        {
            new Produto(1, "Coxinha", 3.50),
            new Produto(2, "Pastel de Carne", 2.50),
            new Produto(3, "Pizza", 22.30),
            new Produto(4, "Pastel de Queijo", 2.00),
            new Produto(5, "Bolo de Chocolate", 5.50),
        };

        public List<Produto> RetornaLista()
        {
            return CardapioProdutos;
        }
    }
}
