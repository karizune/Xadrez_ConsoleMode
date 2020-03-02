using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_ConsoleMode.tabuleiro.Enums;

namespace Xadrez_ConsoleMode.tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int QuantidadeMovimentos { get; set; }
        public Tabuleiro tabuleiro { get; protected set; }

        public Peca(Cor cor, Tabuleiro tabuleiro)
        {
            this.posicao = null;
            this.cor = cor;
            this.tabuleiro = tabuleiro;
            QuantidadeMovimentos = 0;
        }
        public void IncrementarMovimento()
        {
            QuantidadeMovimentos++;
        }
        public abstract bool[,] movimentosPossiveis();
    }
}
