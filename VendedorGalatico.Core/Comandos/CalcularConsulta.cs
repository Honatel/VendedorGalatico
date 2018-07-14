using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendedorGalatico.Core.Enums;
using VendedorGalatico.Core.Helper;
using VendedorGalatico.Core.TagsOfInput;

namespace VendedorGalatico.Core.Comandos
{
    public class CalcularConsulta : Comando
    {
        public override ResultProcessamento Executar(string[] inputString, List<TagsDeEntrada> tagsEntradas)
        {
            try
            {
                double valorConstantes;
                var constatantes = GetTagsDeConstantesSalvas(tagsEntradas.Where(
                                                                x => x.TipoEntrada == TipoEntrada.Constante
                                                                || x.TipoEntrada == TipoEntrada.ConstantePrincipalSemValor
                                                             ).ToList());

                if (constatantes.Any(x => x.TipoEntrada == TipoEntrada.ConstantePrincipalSemValor))
                    valorConstantes = CalcularExpressao(constatantes, constatantes.First(x => x.TipoEntrada == TipoEntrada.ConstantePrincipalComValor).Valor);
                else
                    valorConstantes = GetValorExpressaoRomanos(constatantes);

                var getText = GetstringValues(constatantes);

                return new ResultProcessamento { Mensagem = $"{getText}is {valorConstantes}", Success = true };
            }
            catch (Exception)
            {
                return new ResultProcessamento { Mensagem = "", Success = false };
            }
        }

        private object GetstringValues(List<TagsDeEntrada> constatantes)
        {
            var text = "";

            foreach (var item in constatantes)
                text += item.NomeTag + " ";

            return text;
        }

        private double CalcularExpressao(List<TagsDeEntrada> constatantes, double valor)
        {
            int result = GetValorExpressaoRomanos(constatantes.Where(x => x.TipoEntrada == TipoEntrada.Constante).ToList());

            return result * valor;
        }
    }
}
