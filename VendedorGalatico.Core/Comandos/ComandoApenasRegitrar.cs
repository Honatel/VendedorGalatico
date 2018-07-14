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
    public class ComandoApenasRegitrar : Comando
    {
        public override ResultProcessamento Executar(string[] inputString, List<CaracterDeEntrada> tagsEntradas)
        {
            try
            {
                var tag = ValoresRomanos.SetValueInput(tagsEntradas);
                TagsArmazenadas.Add(tag);

                return new ResultProcessamento { Mensagem = $"{tag.NomeTag} Registrada com sucesso!", Success = true };
            }
            catch (Exception)
            {
                return new ResultProcessamento { Mensagem = "Eu não sei o que você esta dizendo" };
            }
        }
    }
}
