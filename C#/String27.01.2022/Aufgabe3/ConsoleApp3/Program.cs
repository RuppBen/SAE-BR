using System;

namespace ConsoleApp3
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
            string[] zeichen = eingabe.Split(' ');
            foreach (var wort in zeichen)
            {
                indikator++;
            }
            Console.WriteLine("Anzahl Worte: "+indikator);
            System.Console.WriteLine(); //Darstellung
            Console.ReadLine();
        }
    }
}
