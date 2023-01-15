using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string eingabe;
            int indikator = 0;

            Console.Write("Eingabe: ");
            eingabe = Console.ReadLine();
            // aufgabe 1
            foreach (var zeichen in eingabe)
            {
                switch (zeichen)
                {
                    case 'a':
                        indikator++;
                        break;
                    case 'e':
                        indikator++;
                        break;
                    case 'i':
                        indikator++;
                        break;
                    case 'o':
                        indikator++;
                        break;
                    case 'u':
                        indikator++;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("Anzah an Vokalen: " + indikator);
        }
    }
}
