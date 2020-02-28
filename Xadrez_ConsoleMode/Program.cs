using System;
using Xadrez_ConsoleMode.Tabuleiro;

namespace Xadrez_ConsoleMode
{
    class Program
    {
        static void Main(string[] args)
        {
            Posicao P = new Posicao(3, 4);
            Console.WriteLine($"Posição : {P}");
        }
    }
}
