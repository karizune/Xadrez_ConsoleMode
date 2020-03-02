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
                PosicaoXadrez posicao = new PosicaoXadrez('h', 1);
                Console.WriteLine(posicao);
                Console.WriteLine(posicao.toPosicao());
            }
            catch(TabuleiroException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
