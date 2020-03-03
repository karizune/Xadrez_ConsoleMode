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
        public HashSet<Peca> Pecas;
        public HashSet<Peca> Capturadas;
        public Partida_de_Xadrez()
        {
            tabuleiro = new Tabuleiro(8, 8);
            turno = 1;
            JogadorAtual = Cor.Branca;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            PartidaTerminada = false;
            colocarPecas();
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
        public void RealizaJogada(Posicao Origem, Posicao Destino)
        {
            //Peca pecaCapturada = ExecutaMovimento(Origem, Destino);
            ExecutaMovimento(Origem, Destino);
            MudaJogador();
            turno++;
        }
        public void ExecutaMovimento(Posicao Origem, Posicao Destino)
        {
            Peca p = tabuleiro.retirarPeca(Origem);
            p.IncrementarMovimento();
            Peca pecaCapturada = tabuleiro.retirarPeca(Destino);
            tabuleiro.colocarPeca(p, Destino);
            if(pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }
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
        public void colocarNovaPeca(Peca peca, char coluna,int linha)
        {
            tabuleiro.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            Pecas.Add(peca);
        }
        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in Capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }
        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }
        private void colocarPecas()
        {
            colocarNovaPeca(new Rainha(Cor.Branca, tabuleiro), 'e', 5);

            colocarNovaPeca(new Torre(Cor.Preta, tabuleiro), 'a', 8);
            colocarNovaPeca(new Cavalo(Cor.Preta, tabuleiro), 'b', 8);
            colocarNovaPeca(new Bispo(Cor.Preta, tabuleiro), 'c', 8);
            colocarNovaPeca(new Rei(Cor.Preta, tabuleiro), 'd', 8);
            colocarNovaPeca(new Rainha(Cor.Preta, tabuleiro), 'e', 8);
            colocarNovaPeca(new Bispo(Cor.Preta, tabuleiro), 'f', 8);
            colocarNovaPeca(new Cavalo(Cor.Preta, tabuleiro), 'g', 8);
            colocarNovaPeca(new Torre(Cor.Preta, tabuleiro), 'h', 8);
            colocarNovaPeca(new Peao(Cor.Preta, tabuleiro), 'a', 7);
            colocarNovaPeca(new Peao(Cor.Preta, tabuleiro), 'b', 7);
            colocarNovaPeca(new Peao(Cor.Preta, tabuleiro), 'c', 7);
            colocarNovaPeca(new Peao(Cor.Preta, tabuleiro), 'd', 7);
            colocarNovaPeca(new Peao(Cor.Preta, tabuleiro), 'e', 7);
            colocarNovaPeca(new Peao(Cor.Preta, tabuleiro), 'f', 7);
            colocarNovaPeca(new Peao(Cor.Preta, tabuleiro), 'g', 7);
            colocarNovaPeca(new Peao(Cor.Preta, tabuleiro), 'h', 7);

            colocarNovaPeca(new Torre(Cor.Branca, tabuleiro), 'a', 1);
            colocarNovaPeca(new Cavalo(Cor.Branca, tabuleiro), 'b', 1);
            colocarNovaPeca(new Bispo(Cor.Branca, tabuleiro), 'c', 1);
            colocarNovaPeca(new Rei(Cor.Branca, tabuleiro), 'd', 1);
            colocarNovaPeca(new Rainha(Cor.Branca, tabuleiro), 'e', 1);
            colocarNovaPeca(new Bispo(Cor.Branca, tabuleiro), 'f', 1);
            colocarNovaPeca(new Cavalo(Cor.Branca, tabuleiro), 'g', 1);
            colocarNovaPeca(new Torre(Cor.Branca, tabuleiro), 'h', 1);
            colocarNovaPeca(new Peao(Cor.Branca, tabuleiro), 'a', 2);
            colocarNovaPeca(new Peao(Cor.Branca, tabuleiro), 'b', 2);
            colocarNovaPeca(new Peao(Cor.Branca, tabuleiro), 'c', 2);
            colocarNovaPeca(new Peao(Cor.Branca, tabuleiro), 'd', 2);
            colocarNovaPeca(new Peao(Cor.Branca, tabuleiro), 'e', 2);
            colocarNovaPeca(new Peao(Cor.Branca, tabuleiro), 'f', 2);
            colocarNovaPeca(new Peao(Cor.Branca, tabuleiro), 'g', 2);
            colocarNovaPeca(new Peao(Cor.Branca, tabuleiro), 'h', 2);
        }
    }
}
