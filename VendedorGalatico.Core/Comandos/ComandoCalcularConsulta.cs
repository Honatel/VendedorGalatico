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
    public class ComandoCalcularConsulta : Comando
    {
        public override ResultProcessamento Executar(string[] inputString, List<CaracterDeEntrada> tagsEntradas)
        {
            try
            {
                double valorConstantes;
                var constatantes = GetTagsDeConstantesSalvas(tagsEntradas.Where(
                                                                x => x.TipoEntrada == TipoCaracterDeEntrada.Constante
                                                                || x.TipoEntrada == TipoCaracterDeEntrada.ConstantePrincipalSemValor
                                                             ).ToList());

                if (constatantes.Any(x => x.TipoEntrada == TipoCaracterDeEntrada.ConstantePrincipalComValor))
                    valorConstantes = CalcularExpressao(constatantes, constatantes.First(x => x.TipoEntrada == TipoCaracterDeEntrada.ConstantePrincipalComValor).Valor);
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

        private object GetstringValues(List<CaracterDeEntrada> constatantes)
        {
            var text = "";

            foreach (var item in constatantes)
                text += item.NomeTag + " ";

            return text;
        }

        private double CalcularExpressao(List<CaracterDeEntrada> constatantes, double valor)
        {
            int result = GetValorExpressaoRomanos(constatantes.Where(x => x.TipoEntrada == TipoCaracterDeEntrada.Constante).ToList());

            return result * valor;
        }
    }
}
