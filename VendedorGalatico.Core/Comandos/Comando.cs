using System.Collections.Generic;
using VendedorGalatico.Core.Helper;
using VendedorGalatico.Core.TagsOfInput;

namespace VendedorGalatico.Core.Comandos
{
    public abstract class Comando
    {
        public static List<TagsDeEntrada> TagsRomanos { get; set; }
        public List<TagsDeEntrada> Tags{ get; set; }

        public Comando()
        {
            TagsRomanos = TagsRomanos??new List<TagsDeEntrada>();
        }
        public abstract ResultProcessamento Executar(string[] inputString, List<TagsDeEntrada> tagsEntradas);
    }
}
