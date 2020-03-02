using System;
using Xadrez_ConsoleMode.tabuleiro;
using Xadrez_ConsoleMode.tabuleiro.Enums;
using Xadrez_ConsoleMode.tabuleiro.Exceptions;
using Xadrez_ConsoleMode.xadrez;

namespace Xadrez_ConsoleMode
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Partida_de_Xadrez partida = new Partida_de_Xadrez();
                while (!partida.PartidaTerminada)
                {

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tabuleiro);
                    Console.Write($"\nTurno: {partida.turno}\nAguardando Jogada: {partida.JogadorAtual}\nOrigem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().toPosicao();
                    bool[,] posicoesPossiveis = partida.tabuleiro.peca(origem).movimentosPossiveis();
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tabuleiro, posicoesPossiveis);
                    Console.Write("\n\nDestino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().toPosicao();
                    partida.RealizaJogada(origem, destino);
                }

            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"\nErro inesperado:\nMensagem: {exception.Message}\nTipo: {exception.GetType()}");
            }
            
        }
    }
}
