using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_ConsoleMode.tabuleiro;
using Xadrez_ConsoleMode.tabuleiro.Enums;

namespace Xadrez_ConsoleMode.xadrez.Pecas
{
    class Cavalo : Peca
    {
        public Cavalo(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override bool[,] movimentosPossiveis()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "C";
        }
    }
}
