using System;

namespace progetto_informatica_tpsi
{
    class Program
    {
        static void Main(string[] args)
        {
            //inserimento dati nell'array
            Console.WriteLine("inserire il numero di righe");
            int a;
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("inserire il numero di colonne");
            int b;
            b = Convert.ToInt32(Console.ReadLine());
            int[,] array = new int[a,b];
            for (int i = 0; i < b; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    int contenuto;
                    Console.WriteLine("inserire il dato della cella dell'array di colonna {0} e riga {1} ", i, j);
                    contenuto = Convert.ToInt32(Console.ReadLine());
                    array[j, i] = contenuto;
                }
            }
            //stampa a schermo di una riga di array con selezione tramite parametri
            for (int h = 0;h< b; h++)//controllo nella colonna
            {
                Console.WriteLine("inserire il parametro di ricerca per la colonna {0}",h);
                int parametro;
                parametro = Convert.ToInt32(Console.ReadLine());
                for (int m = 0; m < a; m++)//controllo nella riga
                {
                    if (array[m, h] == parametro)
                    {
                        Console.WriteLine("l'elemento di colonna {0} e riga{1} è uguale al parametro di ricerca ", h , m );

                    }
                }
            }
            Console.ReadKey();
        }
    }
}
