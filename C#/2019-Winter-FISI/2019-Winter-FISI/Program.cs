using System;

namespace _2019_Winter_FISI
{
    class Program
    {
        static void Main(string[] args)
        {
            string eingabe = "SE7133131855";
            System.Console.Write("Seriennummer: ");
            eingabe = Console.ReadLine();
            System.Console.WriteLine(pruefeKontrollnummer(eingabe));
        }
        public static bool pruefeKontrollnummer(string seriennummer)
        {
            double prüfzahl = Convert.ToDouble(Convert.ToString(seriennummer[seriennummer.Length -1])); //Prüfzahl auslesen
            seriennummer = seriennummer.Remove(seriennummer.Length -1); //lezte stelle der Seriennummer entfernen, weil diese die Prüfzahl ist
            System.Console.WriteLine(seriennummer);
            //Den stellenwert der Ersten zwei Buchstaben ausrechenen
            int stelle1 = positionImAlphabet(seriennummer[0]);
            int stelle2 = positionImAlphabet(seriennummer[1]);
            double prüfsumme = 0;
            bool richtig = false;

            seriennummer = seriennummer.Remove(0,2); //erste zwei Stellen entfernen weil diese erstetzt werden
            seriennummer = stelle1.ToString() + stelle2.ToString() + seriennummer; //erste zwei stellen mit dem ergbnis der positionImAlphabet methode auffüllen

            //Quersumme bilden weil Microsoft Backdoors alle funktionen außer diese hat
            for (int i = 0; i < seriennummer.Length; i++)
            {
                prüfsumme += Convert.ToDouble(Convert.ToString(seriennummer[i]));
            }

            //Prüfsumme bilden
            prüfsumme = prüfsumme % 9;
            prüfsumme = 7 - prüfsumme;

            //prüfsumme mit Prüfzahl prüfen
            if (prüfsumme == prüfzahl)
            {
               richtig = true;
            }

            return richtig;
        } 
        public static int positionImAlphabet(char buchstabe)    //hab die Methode ausversehen geschrieben, also bleibt sie jetzt 
        {
            char[] alphabet = new char[]{'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
            int stelle = 0;

            for (int i = 0; i < alphabet.Length; i++)
            {
                if (buchstabe == alphabet[i])
                {
                    i++;
                    stelle =i;
                    break;
                } 
            }
            return stelle;
        }
    }
}
