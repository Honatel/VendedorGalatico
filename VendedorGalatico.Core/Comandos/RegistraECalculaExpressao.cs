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
    public class RegistraECalculaExpressao : Comando
    {
        public override ResultProcessamento Executar(string[] inputString, List<TagsDeEntrada> tagsEntradas)
        {
            try
            {
                var constatantes = GetTagsDeConstantesSalvas(tagsEntradas.Where(x => x.TipoEntrada == TipoEntrada.Constante).ToList());// obtive as contantes que estão armazenadas.

                var consSemValor = tagsEntradas.First(x => x.TipoEntrada == TipoEntrada.ConstanteSemValor);// obtive as contantes sem valor.
                var valorNumerico = tagsEntradas.First(x => x.TipoEntrada == TipoEntrada.ValorNumerico).NomeTag;

                consSemValor.Valor = CalcularExpressao(constatantes, Convert.ToInt32(valorNumerico));
                consSemValor.TipoEntrada = TipoEntrada.Constante;

                TagsArmazenadas.Add(consSemValor);

                //glob prok Gold is 57800 Credits
                return new ResultProcessamento { Mensagem = $"{tagsEntradas[0].NomeTag} " +
                                                            $"{tagsEntradas[1].NomeTag} " +
                                                            $"{tagsEntradas[2].NomeTag} " +
                                                            $"{tagsEntradas[3].NomeTag} " +
                                                            $"{tagsEntradas[4].NomeTag} " +
                                                            $"{tagsEntradas[5].NomeTag}", Success = true };
            }
            catch (Exception)
            {
                return new ResultProcessamento { Mensagem = "Eu não sei o que você esta dizendo", Success = true };
            }
        }

        private double CalcularExpressao(List<TagsDeEntrada> constatantes, int valor)
        {
            int result = GetValorExpressaRomanos(constatantes);

            return valor / result;
        }
    }
}
