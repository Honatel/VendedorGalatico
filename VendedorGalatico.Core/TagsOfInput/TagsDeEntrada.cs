using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendedorGalatico.Core.Enums;
using static VendedorGalatico.Core.TagsOfInput.ValorTagsDeEntrada;

namespace VendedorGalatico.Core.TagsOfInput
{
    public class TagsDeEntrada
    {
        public string NomeTag { get; set; }
        public TipoEntrada TipoEntrada { get; set; }
        public double Valor { get; set; }

        public TagsDeEntrada(string input)
        {
            NomeTag = input;
            TipoEntrada = GetTipoInput(input);
        }

        private TipoEntrada GetTipoInput(string input)
        {
            switch (input)
            {
                case ValorTagsDeEntrada.SimbolosRomanos.I:
                case ValorTagsDeEntrada.SimbolosRomanos.V:
                case ValorTagsDeEntrada.SimbolosRomanos.X:
                case ValorTagsDeEntrada.SimbolosRomanos.L:
                case ValorTagsDeEntrada.SimbolosRomanos.C:
                case ValorTagsDeEntrada.SimbolosRomanos.D:
                case ValorTagsDeEntrada.SimbolosRomanos.M:
                    return TipoEntrada.ValorRomano;
                case ValorTagsDeEntrada.Operador.Is: 
                    return TipoEntrada.Operador;
                case ValorTagsDeEntrada.Advervio.How:
                    return TipoEntrada.Pergunta;
                case ValorTagsDeEntrada.OperadorPergunta.QueryCommandQualifier:
                    return TipoEntrada.OperadorPergunta;
                case ValorTagsDeEntrada.Substantivo.Many:
                case ValorTagsDeEntrada.Substantivo.Much:
                    return TipoEntrada.Substantivo;
                case TipoReservado.ValorTipoReservado:
                    return TipoEntrada.TipoReservado;
                default:
                    return GetTipoInputConstante(input);
                    
            }

        }

        private TipoEntrada GetTipoInputConstante(string input)
        {
            var IsNumero = int.TryParse(input, out int n);
            if (IsNumero)
                return TipoEntrada.ValorNumerico;

            return input.Any(x => Char.IsUpper(x)) ? TipoEntrada.ConstantePrincipalSemValor : TipoEntrada.Constante;
        }
    }
}
