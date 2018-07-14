using System.Collections.Generic;
using System.Linq;
using VendedorGalatico.Core.Enums;
using VendedorGalatico.Core.Helper;
using VendedorGalatico.Core.TagsOfInput;

namespace VendedorGalatico.Core.Comandos
{
    public abstract class Comando
    {
        public static List<TagsDeEntrada> TagsArmazenadas { get; set; }
        public List<TagsDeEntrada> Tags{ get; set; }

        public Comando()
        {
            TagsArmazenadas = TagsArmazenadas??new List<TagsDeEntrada>();
        }

        public abstract ResultProcessamento Executar(string[] inputString, List<TagsDeEntrada> tagsEntradas);

        public List<TagsDeEntrada> GetTagsDeConstantesSalvas(List<TagsDeEntrada> list)
        {
            var contatntesEntrada = new List<TagsDeEntrada>();
            foreach (var item in list)
            {
                var tagSalva = TagsArmazenadas.First(x => x.NomeTag == item.NomeTag);
                contatntesEntrada.Add(tagSalva);
            }
            return contatntesEntrada;
        }

        public static int GetValorExpressaoRomanos(List<TagsDeEntrada> constatantes)
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
