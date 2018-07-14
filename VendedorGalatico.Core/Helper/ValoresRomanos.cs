using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendedorGalatico.Core.Enums;
using VendedorGalatico.Core.TagsOfInput;

namespace VendedorGalatico.Core.Helper
{
    public static class ValoresRomanos
    {
        public static double GetValue(string nomeTag)
        {
            switch (nomeTag)
            {
                case ValorTagsDeEntrada.SimbolosRomanos.I:
                    return 1;
                case ValorTagsDeEntrada.SimbolosRomanos.V:
                    return 5;
                case ValorTagsDeEntrada.SimbolosRomanos.X:
                    return 10;
                case ValorTagsDeEntrada.SimbolosRomanos.L:
                    return 50;
                case ValorTagsDeEntrada.SimbolosRomanos.C:
                    return 100;
                case ValorTagsDeEntrada.SimbolosRomanos.D:
                    return 500;
                case ValorTagsDeEntrada.SimbolosRomanos.M:
                    return 1000;
            }
            return 0;
        }

        public static CaracterDeEntrada SetValueInput(List<CaracterDeEntrada> tagsEntradas)
        {
            foreach (var item in tagsEntradas)
            {
                if (item.TipoEntrada == TipoCaracterDeEntrada.ValorRomano)
                    tagsEntradas[0].Valor = GetValue(item.NomeTag);
            }
            var tag = tagsEntradas[0];

            return tag;
        }
    }
}
