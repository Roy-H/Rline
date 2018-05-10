using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLine
{
    public class Scanner
    {
        private string mSource;
        private int mStart = 0;
        private int mCurrent = 0;
        private int mLine = 1;
        private List<Token> mTokenList;

        public Scanner(string source)
        {
            mSource = source;
            mTokenList = new List<Token>();
        }

        public List<Token> Scan()
        {
            while (!IsFinished())
            {
                mStart = mCurrent;
                ScanToken();
            }
            return new List<Token>();
        }


        

        private void ScanToken()
        {
            char c = Advance();
            switch (c)
            {
                case '(':
                    AddToken(TokenType.LEFT_PAREN);
                    break;
                case ')':
                    AddToken(TokenType.RIGHT_PAREN);
                    break;
                case '{':
                    AddToken(TokenType.LEFT_BRACE);
                    break;
                case '}':
                    AddToken(TokenType.RIGHT_BRACE);
                    break;
                case ';':
                    AddToken(TokenType.SEMICOLON);
                    break;
                case '.':
                    AddToken(TokenType.DOT);
                    break;
                default:
                    break;
            }
        }

        private void AddToken(TokenType type)
        {
            string text = mSource.Substring(mStart, mCurrent - mStart);
            mTokenList.Add(new Token(type, text, mLine));
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

        private bool Match(char c1, char c2)
        {
            return c1 == c2;
        }

        private bool IsFinished()
        {
            return mCurrent > mSource.Length;
        }
    }
}
