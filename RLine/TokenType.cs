using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLine
{
    public enum TokenType
    {
        ///
        /// the token we have 
        /// class, indentifier, (,),...
        ///

        #region Single charactor
        LEFT_PAREN, RIGHT_PAREN, LEFT_BRACE, RIGHT_BRACE,
        COMMA, DOT, MINUS, PLUS, SEMICOLON, SLASH, STAR,
        #endregion

        #region Single or two charactor
        BANG, BANG_EQUAL,
        EQUAL, EQUAL_EQUAL,
        GREATER, GREATER_EQUAL,
        LESS, LESS_EQUAL,
        #endregion

        #region Literals.
        IDENTIFIER, STRING, NUMBER,
        #endregion

        #region keyword
        AND, CLASS, ELSE, FALSE, FUN, FOR, IF, NIL, OR,
        PRINT, RETURN, SUPER, THIS, TRUE, VAR, WHILE,
        #endregion

        EOF
    }
}
