using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_ConsoleMode.tabuleiro;
using Xadrez_ConsoleMode.tabuleiro.Enums;

namespace Xadrez_ConsoleMode
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write($"{8 -i} ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    if (tabuleiro.peca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        ImprimirPeca(tabuleiro.peca(i, j));
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void ImprimirPeca(Peca peca)
        {
            if(peca.cor == Cor.Preta)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{peca} ");
                Console.ForegroundColor = color;
            }
            else
            {
                Console.Write($"{peca} ");
            }
        }
    }
}
