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
                var tagsEntradas = GetTagsDeEntrada(argumentos);

                var comando = GetComando(tagsEntradas);

                if (comando == null)
                    return new ResultProcessamento { Mensagem = "Eu não sei o que você esta falando" };

                return comando.Executar(argumentos, tagsEntradas);
            }
            catch (Exception Ex)
            {
                return new ResultProcessamento { Mensagem = $"Erro ao processar input: {Ex.Message}", Success = false };
            }
        }


        private static List<TagsDeEntrada> GetTagsDeEntrada(string[] inputString)
        {
            var tags = new List<TagsDeEntrada>();

            foreach (var item in inputString)
            {
                tags.Add(new TagsDeEntrada(item));
            }
            return tags;
        }

        private static Comando GetComando(List<TagsDeEntrada> argumentos)
        {
            if (argumentos.Count() == 3 
                && argumentos.First().TipoEntrada == TipoEntrada.Constante 
                && argumentos.Last().TipoEntrada == TipoEntrada.ValorRomano)
                return new ApenasRegitrar();
            else if (argumentos.Any(x => x.TipoEntrada == TipoEntrada.ConstantePrincipalSemValor) 
                && !argumentos.Any(x => x.TipoEntrada == TipoEntrada.OperadorPergunta))
                return new RegistraECalculaExpressao();
            else if (argumentos.Any(x => x.TipoEntrada == TipoEntrada.OperadorPergunta))
                return new CalcularConsulta();
            else
                return null;
        }
    }
}
