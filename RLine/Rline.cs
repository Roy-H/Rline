using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Rline
{
    public class Rline
    {
        //static void Main(string[] args)
        //{
        //    RunFile("../../examples/cake.rl");
        //    Console.ReadKey();
        //}

        public void RunFile(string path)
        {
            byte[] bytes;
            try
            {
                if (!File.Exists(path))
                    throw new Exception(string.Format("the file you gave {0} that doesn't exist",path));
                bytes = File.ReadAllBytes(path);
            }
            catch (Exception ex){  throw ex;}
            
            string source = Encoding.Default.GetString(bytes);
            Run(source);
        }
        private void Run(string source)
        {
            Scanner scanner = new Scanner(source);
            List<Token> tokens =  scanner.Scan();
        }
    }
}
