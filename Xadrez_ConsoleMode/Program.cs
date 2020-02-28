using System;
using Xadrez_ConsoleMode.tabuleiro;

namespace Xadrez_ConsoleMode
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tabuleiro = new Tabuleiro(8,8);
            Tela.ImprimirTabuleiro(tabuleiro);
        }
    }
}
