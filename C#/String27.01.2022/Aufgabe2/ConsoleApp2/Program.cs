using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string eingabe;
            Console.Write("Eingabe: ");
            eingabe = Console.ReadLine();
            // aufgabe 1
            foreach (var zeichen in eingabe)
            {
                switch (zeichen)
                {
                    case 'ä':
                        Console.Write("&aUML");
                        break;
                    case 'ö':
                        Console.Write("&oUML");
                        break;
                    case 'ü':
                        Console.Write("&uUML");
                        break;
                    case 'ß':
                        Console.Write("&szlig");
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
