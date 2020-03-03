using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_ConsoleMode.tabuleiro.Enums;
using Xadrez_ConsoleMode.tabuleiro.Exceptions;

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

        protected bool podeMover(Posicao posicao)
        {
            Peca p = tabuleiro.peca(posicao);
            return p == null || p.cor != cor;
        }
        public void IncrementarMovimento()
        {
            QuantidadeMovimentos++;
        }
        public bool existeMovimentosPossiveis()
        {
            bool[,] matriz = movimentosPossiveis();
            for (int i = 0; i < tabuleiro.linhas; i++)
            {
                for (int j = 0; j < tabuleiro.colunas; j++)
                {
                    if (matriz[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public abstract bool[,] movimentosPossiveis();
    }
}
