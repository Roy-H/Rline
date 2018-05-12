namespace Rline
{
    public class Token
    {
        TokenType mType;
        string mLexeme;
        int mLine;
        object mLiteral;

        public Token(TokenType type,string lexeme, object literal,int line)
        {
            mType = type;
            mLexeme = lexeme;
            mLine = line;
            mLiteral = literal;
        }

        public override string ToString()
        {
            return mType + " " + mLexeme + " " + mLiteral;
        }

        public int Line { get { return mLine; } }

        public object Literal { get { return mLiteral; } }

        public string Lexeme { get { return mLexeme; } }

        public TokenType Type { get { return mType; } }
    }
}
