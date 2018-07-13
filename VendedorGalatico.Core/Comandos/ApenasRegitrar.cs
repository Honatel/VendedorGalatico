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
    public class ApenasRegitrar : Comando
    {
        public override ResultProcessamento Executar(string[] inputString, List<TagsDeEntrada> tagsEntradas)
        {
            var tag = SetValueInput(tagsEntradas);
            TagsRomanos.Add(tag);

           return new ResultProcessamento { Mensagem = $"{tag.NomeTag} Registrada com sucesso!"};
        }
        
        private TagsDeEntrada SetValueInput(List<TagsDeEntrada> tagsEntradas)
        {
            foreach (var item in tagsEntradas)
            {
                if (item.TipoEntrada == TipoEntrada.ValorRomano)
                    tagsEntradas[0].Valor = ValoresRomanos.GetValue(item.NomeTag);
            }
            var tag = tagsEntradas[0];

            return tag;
        }
    }
}
