using System;
using System.Collections.Generic; 

namespace _27._01Assoziation
{
    class Program
    {
        static void Main(string[] args)
        {
            Kunde bob = new Kunde("bob", "ananas");
            bob.AddKonto();

            Kunde kai = new Kunde("kai", "pineapple");
            kai.AddKonto();

            kai.Geldtransfer(bob, 1, 100002, 100000);
            /*
                Da GetKonto nicht Alle kunden aller Konten durchsucht
                sondern nur die der angewgebenen person, muss man immer noch die 
                zielperson m namen nennen
            */
            //bob.DasKonto.Einzahlen(2000);
            //bob.Geldtransfer(kai, 500);

            System.Console.WriteLine(bob+"\n"+kai);
        }
    }
}
