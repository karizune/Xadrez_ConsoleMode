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
                    Console.Write("Digite a posição da peça para mover: ");
                    Posicao origem = Tela.LerPosicaoXadrez().toPosicao();
                    Console.Write("Digite a posição de destino da peça: ");
                    Posicao Destino = Tela.LerPosicaoXadrez().toPosicao();
                    partida.ExecutaMovimento(origem, Destino);
                }
            }
            catch(TabuleiroException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"\nErro inesperado:\nMensagem: {exception.Message}");
            }
        }
    }
}
