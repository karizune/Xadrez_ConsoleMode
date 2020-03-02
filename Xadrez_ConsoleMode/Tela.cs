using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_ConsoleMode.tabuleiro;
using Xadrez_ConsoleMode.tabuleiro.Enums;
using Xadrez_ConsoleMode.xadrez;
using static Xadrez_ConsoleMode.CLASSE_AUXILIAR;

namespace Xadrez_ConsoleMode
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                TextoColorido($"{8 - i} ", ConsoleColor.Yellow);
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
            TextoColorido("  a b c d e f g h\n", ConsoleColor.Yellow);
        }
        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string posicao = Console.ReadLine();
            char coluna = posicao[0];
            int linha = int.Parse($"{posicao[1]}");
            return new PosicaoXadrez(coluna,linha);
        }

        public static void ImprimirPeca(Peca peca)
        {
            if(peca.cor == Cor.Preta)
            {
                TextoColorido($"{peca} ", ConsoleColor.Red);
            }
            else
            {
                Console.Write($"{peca} ");
            }
        }
    }
}
