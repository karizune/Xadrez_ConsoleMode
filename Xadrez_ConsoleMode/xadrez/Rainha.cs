using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_ConsoleMode.tabuleiro;
using Xadrez_ConsoleMode.tabuleiro.Enums;

namespace Xadrez_ConsoleMode.xadrez
{
    class Rainha : Peca
    {
        public Rainha(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }
        public override string ToString()
        {
            return "D";
        }
    }
}
