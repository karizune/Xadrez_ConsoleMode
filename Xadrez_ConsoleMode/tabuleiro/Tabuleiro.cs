using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_ConsoleMode.tabuleiro.Exceptions;

namespace Xadrez_ConsoleMode.tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }


        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }
        public Peca peca(Posicao posicao)
        {
            return pecas[posicao.Linha, posicao.Coluna];
        }
        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return peca(pos) != null;
        }
        public bool ExistePeca(int Linha,int Coluna)
        {
            Posicao pos = new Posicao(Linha, Coluna);
            ValidarPosicao(pos);
            return peca(pos) != null;
        }
        public void colocarPeca(Peca peca, Posicao posicao)
        {
            if (ExistePeca(posicao))
            {
                throw new TabuleiroException("Já existe uma peça nesta posição");
            }
            pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.posicao = posicao;
        }
        public Peca retirarPeca(Posicao posicao)
        {
            if (peca(posicao) == null)
            {
                return null;
            }
            else
            {
                Peca aux = peca(posicao);
                aux.posicao = null;
                pecas[posicao.Linha,posicao.Coluna] = null;
                return aux;
            }
        }

        public bool posicaoValida(Posicao posicao)
        {
            if (posicao.Linha < 0 || posicao.Linha >= linhas || posicao.Coluna < 0 || posicao.Coluna >= colunas)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void ValidarPosicao(Posicao posicao)
        {
            if (!posicaoValida(posicao))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}