﻿using System;
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
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirPartida(partida);
                        Posicao origem = Tela.LerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);
                        bool[,] posicoesPossiveis = partida.tabuleiro.peca(origem).movimentosPossiveis();
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.tabuleiro, posicoesPossiveis);
                        Console.Write("\nDestino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);
                        partida.RealizaJogada(origem, destino);
                    }
                    catch (TabuleiroException exception)
                    {
                        Console.WriteLine($"\nErro: {exception.Message}");
                        Console.ReadLine();
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine($"\nErro inesperado:\nMensagem: {exception.Message}\nTipo: {exception.GetType()}");
                        Console.ReadLine();
                    }
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
