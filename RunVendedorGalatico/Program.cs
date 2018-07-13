using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendedorGalatico.Core;

namespace RunVendedorGalatico
{
    class Program
    {
        static void Main(string[] args)
        { 
        var processarImput = new ProcessarInput();

            while (true)
            {
                Console.Write("Bem vindo vendedor, em que posso ajudar?");

                var resultado = Console.ReadLine();
                if (resultado == "sair") break;

                var reposta = processarImput.Pocessar(resultado);
                Console.WriteLine(reposta.Mensagem);
            }
        }
    }
}
