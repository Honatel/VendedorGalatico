using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendedorGalatico.Core.Enums;
using static VendedorGalatico.Core.TagsOfInput.ValorTagsDeEntrada;

namespace VendedorGalatico.Core.TagsOfInput
{
    public class CaracterDeEntrada
    {
        public string NomeTag { get; set; }
        public TipoCaracterDeEntrada TipoEntrada { get; set; }
        public double Valor { get; set; }

        public CaracterDeEntrada(string input)
        {
            NomeTag = input;
            TipoEntrada = GetTipoInput(input);
        }

        private TipoCaracterDeEntrada GetTipoInput(string input)
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
                    return TipoCaracterDeEntrada.ValorRomano;
                case ValorTagsDeEntrada.Operador.Is:
                    return TipoCaracterDeEntrada.Operador;
                case ValorTagsDeEntrada.Advervio.How:
                    return TipoCaracterDeEntrada.Pergunta;
                case ValorTagsDeEntrada.OperadorPergunta.QueryCommandQualifier:
                    return TipoCaracterDeEntrada.OperadorPergunta;
                case ValorTagsDeEntrada.Substantivo.Many:
                case ValorTagsDeEntrada.Substantivo.Much:
                    return TipoCaracterDeEntrada.Substantivo;
                case TipoReservado.ValorTipoReservado:
                    return TipoCaracterDeEntrada.TipoReservado;
                default:
                    return GetTipoInputConstante(input);

            }
        }

        private TipoCaracterDeEntrada GetTipoInputConstante(string input)
        {
            var IsNumero = int.TryParse(input, out int n);
            if (IsNumero)
                return TipoCaracterDeEntrada.ValorNumerico;

            return input.Any(x => Char.IsUpper(x)) ? TipoCaracterDeEntrada.ConstantePrincipalSemValor : TipoCaracterDeEntrada.Constante;
        }
    }
}
