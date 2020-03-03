using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_ConsoleMode.tabuleiro;
using Xadrez_ConsoleMode.tabuleiro.Enums;

namespace Xadrez_ConsoleMode.xadrez.Pecas
{
    class Peao : Peca
    {
        public Peao(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }
        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[tabuleiro.linhas, tabuleiro.colunas];
            Posicao pos = new Posicao(0, 0);
            if (cor == Cor.Branca) {
                if (QuantidadeMovimentos == 0)
                {
                    //acima
                    pos.DefinirValores(posicao.Linha - 1, posicao.Coluna);
                    if (tabuleiro.posicaoValida(pos) && podeMover(pos))
                    {
                        matriz[pos.Linha, pos.Coluna] = true;
                    }
                    pos.DefinirValores(posicao.Linha - 2, posicao.Coluna);
                    if (tabuleiro.posicaoValida(pos) && podeMover(pos))
                    {
                        matriz[pos.Linha, pos.Coluna] = true;
                    }
                }
                else if (tabuleiro.ExistePeca(posicao.Linha - 1, posicao.Coluna + 1) || tabuleiro.ExistePeca(posicao.Linha - 1, posicao.Coluna - 1))
                {
                    // acima direita
                    pos.DefinirValores(posicao.Linha - 1, posicao.Coluna + 1);
                    if (tabuleiro.posicaoValida(pos) && podeMover(pos))
                    {
                        matriz[pos.Linha, pos.Coluna] = true;
                    }
                    //acima esquerda
                    pos.DefinirValores(posicao.Linha - 1, posicao.Coluna - 1);
                    if (tabuleiro.posicaoValida(pos) && podeMover(pos))
                    {
                        matriz[pos.Linha, pos.Coluna] = true;
                    }
                }
                else
                {
                    pos.DefinirValores(posicao.Linha - 1, posicao.Coluna);
                    if (tabuleiro.posicaoValida(pos) && podeMover(pos))
                    {
                        matriz[pos.Linha, pos.Coluna] = true;
                    }
                } 
            }
            else
            {
                if (QuantidadeMovimentos == 0)
                {
                    //abaixo
                    pos.DefinirValores(posicao.Linha + 1, posicao.Coluna);
                    if (tabuleiro.posicaoValida(pos) && podeMover(pos))
                    {
                        matriz[pos.Linha, pos.Coluna] = true;
                    }
                    pos.DefinirValores(posicao.Linha + 2, posicao.Coluna);
                    if (tabuleiro.posicaoValida(pos) && podeMover(pos))
                    {
                        matriz[pos.Linha, pos.Coluna] = true;
                    }
                }
                else if (tabuleiro.ExistePeca(posicao.Linha + 1, posicao.Coluna + 1) || tabuleiro.ExistePeca(posicao.Linha + 1, posicao.Coluna - 1))
                {
                    // abaixo direita
                    pos.DefinirValores(posicao.Linha + 1, posicao.Coluna + 1);
                    if (tabuleiro.posicaoValida(pos) && podeMover(pos))
                    {
                        matriz[pos.Linha, pos.Coluna] = true;
                    }
                    //abaixo esquerda
                    pos.DefinirValores(posicao.Linha + 1, posicao.Coluna - 1);
                    if (tabuleiro.posicaoValida(pos) && podeMover(pos))
                    {
                        matriz[pos.Linha, pos.Coluna] = true;
                    }
                }
                else
                {
                    pos.DefinirValores(posicao.Linha + 1, posicao.Coluna);
                    if (tabuleiro.posicaoValida(pos) && podeMover(pos))
                    {
                        matriz[pos.Linha, pos.Coluna] = true;
                    }
                }
            }
            return matriz;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
