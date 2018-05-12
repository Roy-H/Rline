using System.Collections.Generic;

namespace Rline
{
    public class Scanner
    {
        private string mSource;
        private int mStart = 0;
        private int mCurrent = 0;
        private int mLine = 1;
        private List<Token> mTokens;

        public Scanner(string source)
        {
            mSource = source;
            mTokens = new List<Token>();
        }

        public List<Token> Scan()
        {
            while (!IsAtEnd())
            {
                mStart = mCurrent;
                ScanToken();
            }
            mTokens.Add(new Token(TokenType.EOF, "", null, mLine));
            return mTokens;
        }


        
        /// <summary>
        /// ( ) , ; { } + - * / = ==
        /// </summary>
        private void ScanToken()
        {
            char c = Advance();
            switch (c)
            {
                //one ( ) { } , . - + ; / *
                case '(':AddToken(TokenType.LEFT_PAREN);break;
                case ')':AddToken(TokenType.RIGHT_PAREN);break;
                case '{':AddToken(TokenType.LEFT_BRACE);break;
                case '}':AddToken(TokenType.RIGHT_BRACE);break;
                case ',':AddToken(TokenType.COMMA);break;
                case '.':AddToken(TokenType.DOT);break;
                case '-':AddToken(TokenType.MINUS);break;
                case '+':AddToken(TokenType.PLUS);break;
                case ';':AddToken(TokenType.SEMICOLON);break;
                case '/':AddToken(TokenType.SLASH);break;
                case '*':AddToken(TokenType.STAR);break;
                case '\n':
                    mLine++;break;
                case ' ':
                case '\r':
                case '\t':
                    // Ignore whitespace.
                    break;
                //two or one 
                // != = == <= >= > <
                case '!':AddToken(Match('=') ? TokenType.BANG_EQUAL: TokenType.BANG);break;
                case '<':AddToken(Match('=') ? TokenType.LESS_EQUAL : TokenType.LESS);break;
                case '>':AddToken(Match('=') ? TokenType.GREATER_EQUAL : TokenType.GREATER);break;
                case '=':AddToken(Match('=') ? TokenType.EQUAL_EQUAL : TokenType.EQUAL);break;
                case '"':
                    StringLiteral();break;
                default:
                    if (IsDigit(c))
                    {
                        Number();
                    }
                    else if (IsAlpha(c))
                    {
                        Indentifier();
                    }
                    else
                    {
                        ErrorManager.Error(mLine, "cannot recognize character " + c.ToString());
                    }
                    break;
            }
        }

        private void StringLiteral()
        {
            while (!IsAtEnd()&&Peek()!='"')
            {
                if (Peek() == '\n')
                    mLine++;
                Advance();
            }
            if (IsAtEnd())
            {
                ErrorManager.Error(mLine, "Unterminated string.");
                return;
            }
            Advance();
            AddToken(TokenType.STRING);
        }

        private void Indentifier()
        {
            while (!IsAtEnd() && IsDigitOrAlpha(Peek()))
                Advance();

            AddToken(TokenType.IDENTIFIER);
        }

        private void Number()
        {

            while (!IsAtEnd() && IsDigit(Peek()))
                Advance();
            if (Peek() != '.')
                AddToken(TokenType.NUMBER);

            while (!IsAtEnd() && IsDigit(Peek()))
                Advance();

            AddToken(TokenType.NUMBER);

        }

        private char Peek()
        {

            return mSource[mCurrent];
        }

        private bool IsAlpha(char c)
        {
            return c >= 'a' && c <= 'z'
                || c >= 'A' && c <= 'Z'
                || c == '_';              
        }

        private bool IsDigit(char c)
        {
            return c >= 0 && c <= 9;
        }

        private bool IsDigitOrAlpha(char c)
        {
            return IsAlpha(c) || IsDigit(c);
        }

        private void AddToken(TokenType type)
        {
            string text = mSource.Substring(mStart, mCurrent - mStart);
            mTokens.Add(new Token(type, text,null, mLine));
        }

        private char Advance()
        {
            mCurrent++;
            return mSource[mCurrent - 1];
        }

        private char Next()
        {
            return mSource[mCurrent];
        }

        private bool Match(char expected)
        {
            if (IsAtEnd())
                return false;

            if (mSource[mCurrent] != expected)
                return false;

            mCurrent++;
            return true;
        }

        private bool IsAtEnd()
        {
            return mCurrent >= mSource.Length;
        }
    }
}
