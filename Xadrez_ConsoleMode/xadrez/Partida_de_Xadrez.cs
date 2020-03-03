using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_ConsoleMode.tabuleiro;
using Xadrez_ConsoleMode.tabuleiro.Enums;
using Xadrez_ConsoleMode.tabuleiro.Exceptions;
using Xadrez_ConsoleMode.xadrez.Pecas;

namespace Xadrez_ConsoleMode.xadrez
{
    class Partida_de_Xadrez
    {
        public Tabuleiro tabuleiro { get; private set; }
        public int turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool PartidaTerminada { get; private set; }

        public Partida_de_Xadrez()
        {
            tabuleiro = new Tabuleiro(8, 8);
            turno = 1;
            JogadorAtual = Cor.Branca;
            colocarPecas();
            PartidaTerminada = false;
        }
        public void validarPosicaoDeOrigem(Posicao posicao)
        {
            if (tabuleiro.peca(posicao) == null)
            {
                throw new TabuleiroException("Não existe peça na posição selecionada!");
            }
            if (tabuleiro.peca(posicao).cor != JogadorAtual)
            {
                throw new TabuleiroException("Peça escolhida é do adversário!");
            }
            if (!tabuleiro.peca(posicao).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Peça escolhida não tem movimentos disponíveis!");
            }
        }
        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            bool[,] matriz = tabuleiro.peca(origem).movimentosPossiveis();

            if (matriz[destino.Linha, destino.Coluna] == false)
            {
                throw new TabuleiroException("Não pode mover para este local!");
            }
            if (tabuleiro.peca(destino) != null)
            {
                if (tabuleiro.peca(origem).cor == tabuleiro.peca(destino).cor)
                {
                    throw new TabuleiroException("Não pode capturar própria peça!");
                }
            }

        }
        public void ExecutaMovimento(Posicao Origem, Posicao Destino)
        {
            Peca p = tabuleiro.retirarPeca(Origem);
            p.IncrementarMovimento();
            Peca pecaCapturada = tabuleiro.retirarPeca(Destino);
            tabuleiro.colocarPeca(p, Destino);
        }
        public void RealizaJogada(Posicao Origem, Posicao Destino)
        {
            ExecutaMovimento(Origem, Destino);
            turno++;
            MudaJogador();
        }
        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }
        private void colocarPecas()
        {
            tabuleiro.colocarPeca(new Torre(Cor.Preta, tabuleiro), new PosicaoXadrez('a', 8).toPosicao());
            tabuleiro.colocarPeca(new Cavalo(Cor.Preta, tabuleiro), new PosicaoXadrez('b', 8).toPosicao());
            tabuleiro.colocarPeca(new Bispo(Cor.Preta, tabuleiro), new PosicaoXadrez('c', 8).toPosicao());
            tabuleiro.colocarPeca(new Rei(Cor.Preta, tabuleiro), new PosicaoXadrez('d', 8).toPosicao());
            tabuleiro.colocarPeca(new Rainha(Cor.Preta, tabuleiro), new PosicaoXadrez('e', 8).toPosicao());
            tabuleiro.colocarPeca(new Bispo(Cor.Preta, tabuleiro), new PosicaoXadrez('f', 8).toPosicao());
            tabuleiro.colocarPeca(new Cavalo(Cor.Preta, tabuleiro), new PosicaoXadrez('g', 8).toPosicao());
            tabuleiro.colocarPeca(new Torre(Cor.Preta, tabuleiro), new PosicaoXadrez('h', 8).toPosicao());
            tabuleiro.colocarPeca(new Peao(Cor.Preta, tabuleiro), new PosicaoXadrez('a', 7).toPosicao());
            tabuleiro.colocarPeca(new Peao(Cor.Preta, tabuleiro), new PosicaoXadrez('b', 7).toPosicao());
            tabuleiro.colocarPeca(new Peao(Cor.Preta, tabuleiro), new PosicaoXadrez('c', 7).toPosicao());
            tabuleiro.colocarPeca(new Peao(Cor.Preta, tabuleiro), new PosicaoXadrez('d', 7).toPosicao());
            tabuleiro.colocarPeca(new Peao(Cor.Preta, tabuleiro), new PosicaoXadrez('e', 7).toPosicao());
            tabuleiro.colocarPeca(new Peao(Cor.Preta, tabuleiro), new PosicaoXadrez('f', 7).toPosicao());
            tabuleiro.colocarPeca(new Peao(Cor.Preta, tabuleiro), new PosicaoXadrez('g', 7).toPosicao());
            tabuleiro.colocarPeca(new Peao(Cor.Preta, tabuleiro), new PosicaoXadrez('h', 7).toPosicao());


            tabuleiro.colocarPeca(new Torre(Cor.Branca, tabuleiro), new PosicaoXadrez('a', 1).toPosicao());
            tabuleiro.colocarPeca(new Cavalo(Cor.Branca, tabuleiro), new PosicaoXadrez('b', 1).toPosicao());
            tabuleiro.colocarPeca(new Bispo(Cor.Branca, tabuleiro), new PosicaoXadrez('c', 1).toPosicao());
            tabuleiro.colocarPeca(new Rei(Cor.Branca, tabuleiro), new PosicaoXadrez('d', 1).toPosicao());
            tabuleiro.colocarPeca(new Rainha(Cor.Branca, tabuleiro), new PosicaoXadrez('e', 1).toPosicao());
            tabuleiro.colocarPeca(new Bispo(Cor.Branca, tabuleiro), new PosicaoXadrez('f', 1).toPosicao());
            tabuleiro.colocarPeca(new Cavalo(Cor.Branca, tabuleiro), new PosicaoXadrez('g', 1).toPosicao());
            tabuleiro.colocarPeca(new Torre(Cor.Branca, tabuleiro), new PosicaoXadrez('h', 1).toPosicao());
            tabuleiro.colocarPeca(new Peao(Cor.Branca, tabuleiro), new PosicaoXadrez('a', 2).toPosicao());
            tabuleiro.colocarPeca(new Peao(Cor.Branca, tabuleiro), new PosicaoXadrez('b', 2).toPosicao());
            tabuleiro.colocarPeca(new Peao(Cor.Branca, tabuleiro), new PosicaoXadrez('c', 2).toPosicao());
            tabuleiro.colocarPeca(new Peao(Cor.Branca, tabuleiro), new PosicaoXadrez('d', 2).toPosicao());
            tabuleiro.colocarPeca(new Peao(Cor.Branca, tabuleiro), new PosicaoXadrez('e', 2).toPosicao());
            tabuleiro.colocarPeca(new Peao(Cor.Branca, tabuleiro), new PosicaoXadrez('f', 2).toPosicao());
            tabuleiro.colocarPeca(new Peao(Cor.Branca, tabuleiro), new PosicaoXadrez('g', 2).toPosicao());
            tabuleiro.colocarPeca(new Peao(Cor.Branca, tabuleiro), new PosicaoXadrez('h', 2).toPosicao());
        }
    }
}
