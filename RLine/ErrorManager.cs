using System;

namespace Rline
{
    public static class ErrorManager
    {
        private static bool hadError = false;
        private static bool hadRuntimeError = false;
        public static void Error()
        {

        }

        public static void Error(int line, string message)
        {
            Report(line, "", message);
        }

        public static void Error(Token token, String message)
        {
            if (token.Type == TokenType.EOF)
            {
                Report(token.Line, "at end", message);
            }
            else
            {
                Report(token.Line, "at '" + token.Lexeme + "'", message);
            }
        }

        public static void RuntimeError(RuntimeError error)
        {
            Console.WriteLine(error.Message + $"\n[line {error.Token.Line}]");
            hadRuntimeError = true;
        }
        public static void Report(int line, string where, string message)
        {
            Console.WriteLine($"Line [{line}] Error {where}: {message}");
            hadError = true;
        }
    }
}
