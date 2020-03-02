using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_ConsoleMode.Extra
{
    public static class CLASSE_AUXILIAR
    {
        public static void TextoColorido(string texto, ConsoleColor cor)
        {
            ConsoleColor resetColor = Console.ForegroundColor;
            Console.ForegroundColor = cor;
            Console.Write(texto);
            Console.ForegroundColor = resetColor;
        }
    }
}
