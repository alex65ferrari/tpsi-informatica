using System;
namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            string a;
            string b;
            int c = 1;
            int d = 7;
            string[,] array = new string[c,d];
            inserimento(a, b, c, d, array);
            for (int j = 0; j <= 7; j++)
            {
                Console.Writeline("{0}", array[a, j]);
            }
        }
        public static inserimento(string a, string b, int c, int d)
        {
            for (int i = 0; i < d; i++)
            {
                string contenuto;
                contenuto = Convert.ToString(Console.Readline());
                array[a, i] = contenuto;
            }
            return array;
        }
    }
}