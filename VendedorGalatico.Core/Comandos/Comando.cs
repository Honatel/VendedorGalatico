using System.Collections.Generic;
using System.Linq;
using VendedorGalatico.Core.Enums;
using VendedorGalatico.Core.Helper;
using VendedorGalatico.Core.TagsOfInput;

namespace VendedorGalatico.Core.Comandos
{
    public abstract class Comando
    {
        public static List<CaracterDeEntrada> TagsArmazenadas { get; set; }
        public List<CaracterDeEntrada> Tags{ get; set; }

        public Comando()
        {
            TagsArmazenadas = TagsArmazenadas??new List<CaracterDeEntrada>();
        }

        public abstract ResultProcessamento Executar(string[] inputString, List<CaracterDeEntrada> tagsEntradas);

        public List<CaracterDeEntrada> GetTagsDeConstantesSalvas(List<CaracterDeEntrada> list)
        {
            var contatntesEntrada = new List<CaracterDeEntrada>();
            foreach (var item in list)
            {
                var tagSalva = TagsArmazenadas.First(x => x.NomeTag == item.NomeTag);
                contatntesEntrada.Add(tagSalva);
            }
            return contatntesEntrada;
        }

        public static int GetValorExpressaoRomanos(List<CaracterDeEntrada> constatantes)
        {
            var result = 0;
            var valorAnterior = 0;
            foreach (var item in constatantes)
            {
                result = +valorAnterior < (int)item.Valor
                        ? result == 0
                            ? (int)item.Valor
                            : (int)item.Valor - valorAnterior
                        : valorAnterior + (int)item.Valor;

                valorAnterior = result;
            };
            return result;
        }

    }
}
