using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendedorGalatico.Core.Enums
{
    public enum TipoCaracterDeEntrada
    {
        Constante, 
        Operador,
        ValorRomano,
        ConstantePrincipalSemValor,
        ConstantePrincipalComValor,
        OperadorPergunta,
        Pergunta, 
        Substantivo, 
        ValorNumerico,
        TipoReservado
    }
}
