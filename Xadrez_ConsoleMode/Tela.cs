using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_ConsoleMode.tabuleiro;
using Xadrez_ConsoleMode.tabuleiro.Enums;
using Xadrez_ConsoleMode.xadrez;
using static Xadrez_ConsoleMode.Extra.CLASSE_AUXILIAR;

namespace Xadrez_ConsoleMode
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for (int i = 0; i < tabuleiro.linhas; i++)
            {
                TextoColorido($"\t\t{8 - i} ", ConsoleColor.Yellow);
                for (int j = 0; j < tabuleiro.colunas; j++)
                {
                    ImprimirPeca(tabuleiro.peca(i, j));
                }
                Console.WriteLine("");
            }
            TextoColorido("\t\t  a b c d e f g h\n", ConsoleColor.Yellow);
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] possiveisMovimentos)
        {
            ConsoleColor Alterado = ConsoleColor.DarkGray;
            ConsoleColor Original = Console.BackgroundColor;
            for (int i = 0; i < tabuleiro.linhas; i++)
            {
                TextoColorido($"\t\t{8 - i} ", ConsoleColor.Yellow);
                for (int j = 0; j < tabuleiro.colunas; j++)
                {
                    if (possiveisMovimentos[i,j])
                    {
                        Console.BackgroundColor = Alterado;
                    }
                    else
                    {
                        Console.BackgroundColor = Original;
                    }
                    ImprimirPeca(tabuleiro.peca(i, j));
                }
                Console.BackgroundColor = Original;
                Console.WriteLine("");
            }
            Console.BackgroundColor = Original;
            TextoColorido("\t\t  a b c d e f g h\n", ConsoleColor.Yellow);
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string posicao = Console.ReadLine();
            char coluna = posicao[0];
            int linha = int.Parse($"{posicao[1]}");
            return new PosicaoXadrez(coluna, linha );
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.cor == Cor.Preta)
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
}
