﻿using System;
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
        var processarInput = new ProcessarInput();

            while (true)
            {
                Console.Write("Bem vindo vendedor, em que posso ajudar?");

                var resultado = Console.ReadLine();
                if (resultado == "sair") break;

                var reposta = processarInput.Pocessar(resultado);
                Console.WriteLine(reposta.Mensagem);
            }
        }
    }
}
