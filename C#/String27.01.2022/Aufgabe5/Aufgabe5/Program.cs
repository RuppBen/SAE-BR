using System;

namespace Aufgabe5
{
    class Program
    {
        static void Main(string[] args)
        {
            string eingabe;
            Console.Write("Eingabe: ");
            eingabe = Console.ReadLine();
            foreach (var zeichen in eingabe)
            {
                switch (zeichen)
                {
                    case 'ä':
                        Console.Write("ae");
                        break;
                    case 'ö':
                        Console.Write("oe");
                        break;
                    case 'ü':
                        Console.Write("ue");
                        break;
                    default:
                        Console.Write(zeichen);
                        break;
                }
            }
            System.Console.WriteLine(); //Darstellung
        }
    }
}
