using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendedorGalatico.Core.Enums;
using VendedorGalatico.Core.Helper;
using VendedorGalatico.Core.TagsOfInput;

namespace VendedorGalatico.Core
{
    public class ProcessarInput
    {
        private string[] inputString;
        private List<TagsDeEntrada> InputsComValores = new List<TagsDeEntrada>();

        public ResultProcessamento Pocessar(string resultado)
        {
            var valorSemEspaco = resultado.Trim();
            inputString = valorSemEspaco.Split(' ');

            return FabricaDeComando.ProcessaComandos(inputString);
        }
    }
}
