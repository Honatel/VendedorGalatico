using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendedorGalatico.Core.Comandos;
using VendedorGalatico.Core.Enums;
using VendedorGalatico.Core.Helper;
using VendedorGalatico.Core.TagsOfInput;

namespace VendedorGalatico.Core
{
    public static class FabricaDeComando
    {
        public static ResultProcessamento ProcessaComandos(string[] argumentos)
        {
            try
            {
                var caracteresDeEntrada = MontaCaracteresDeEntrada(argumentos);

                var comando = FactoryComando(caracteresDeEntrada);

                if (comando == null)
                    return new ResultProcessamento { Mensagem = "Eu não sei o que você esta falando" };

                return comando.Executar(argumentos, caracteresDeEntrada);
            }
            catch (Exception Ex)
            {
                return new ResultProcessamento { Mensagem = $"Erro ao processar input: {Ex.Message}", Success = false };
            }
        }

        private static List<CaracterDeEntrada> MontaCaracteresDeEntrada(string[] inputString)
        {
            var tags = new List<CaracterDeEntrada>();

            foreach (var item in inputString)
            {
                tags.Add(new CaracterDeEntrada(item));
            }
            return tags;
        }

        private static Comando FactoryComando(List<CaracterDeEntrada> argumentos)
        {
            if (argumentos.Count() == 3 
                && argumentos.First().TipoEntrada == TipoCaracterDeEntrada.Constante 
                && argumentos.Last().TipoEntrada == TipoCaracterDeEntrada.ValorRomano)
                return new ComandoApenasRegitrar();
            else if (argumentos.Any(x => x.TipoEntrada == TipoCaracterDeEntrada.ConstantePrincipalSemValor) 
                && !argumentos.Any(x => x.TipoEntrada == TipoCaracterDeEntrada.OperadorPergunta))
                return new ComandoRegistraECalculaExpressao();
            else if (argumentos.Any(x => x.TipoEntrada == TipoCaracterDeEntrada.OperadorPergunta))
                return new ComandoCalcularConsulta();
            else
                return null;
        }
    }
}
