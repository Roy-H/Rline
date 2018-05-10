using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLine
{
    public class Token
    {
        TokenType mType;
        string mText;
        int mLine;

        public Token(TokenType type,string text,int line)
        {
            mType = type;
            mText = text;
            mLine = line;
        }

    }
}
