using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendedorGalatico.Core.Enums
{
    public enum TipoEntrada
    {
        Constante, 
        Operador,
        ValorRomano,
        ConstantePrincipalSemValor,
        ConstantePrincipalComValor,
        OperadorPergunta,
        Pergunta, // how
        Substantivo, // much  many
        ValorNumerico,
        TipoReservado
    }
}
