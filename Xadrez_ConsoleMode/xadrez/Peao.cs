using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_ConsoleMode.tabuleiro;
using Xadrez_ConsoleMode.tabuleiro.Enums;

namespace Xadrez_ConsoleMode.xadrez
{
    class Peao : Peca
    {
        public Peao(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }
        public override string ToString()
        {
            return "P";
        }
    }
}
