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
            bool[,] matriz = new bool[tabuleiro.linhas, tabuleiro.colunas];
            Posicao pos = new Posicao(0, 0);
            //esquerda baixo
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna - 2); 
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }                   
            //baixo esquerda
            pos.DefinirValores(posicao.Linha + 2, posicao.Coluna - 1); 
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }            
            //baixo direita
            pos.DefinirValores(posicao.Linha + 2, posicao.Coluna + 1); 
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }            
            //direita baixo
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna + 2); 
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //esquerda cima
            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna - 2); 
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }                   
            //cima esquerda
            pos.DefinirValores(posicao.Linha - 2, posicao.Coluna - 1); 
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }            
            //cima direita
            pos.DefinirValores(posicao.Linha - 2, posicao.Coluna + 1); 
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }            
            //direita cima
            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna + 2); 
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }
            return matriz;
        }

        public override string ToString()
        {
            return "C";
        }
    }
}
