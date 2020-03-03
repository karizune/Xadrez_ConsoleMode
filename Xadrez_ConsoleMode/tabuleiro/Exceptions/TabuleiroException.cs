using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_ConsoleMode.tabuleiro.Exceptions
{
    class TabuleiroException : Exception
    {
        public TabuleiroException(string message) : base(message)
        { }        
    }
}
