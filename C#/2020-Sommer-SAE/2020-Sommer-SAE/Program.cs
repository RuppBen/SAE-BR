using System;

namespace _2020_Sommer_SAE
{
    class Program
    {
        static void Main(string[] args)
        {
            string eingabe;
            int pcID;
            string raumNR;
            int ramGB;

            Console.Write("Bitte geben sie die pcID ein: ");
            eingabe = Console.ReadLine();
            pcID = Convert.ToInt32(eingabe);

            System.Console.Write("Bitte geben sie die raumNr ein: ");
            eingabe = Console.ReadLine();
            raumNR = eingabe;

            System.Console.Write("Bitte geben sie die ramGB ein: ");
            eingabe = Console.ReadLine();
            ramGB = Convert.ToInt32(eingabe);

            pc computer = new pc(pcID, raumNR, ramGB);
        }
    }
}
