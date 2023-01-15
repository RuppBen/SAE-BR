using System;
using System.IO;

namespace _2016_Sommer_SAE
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"/mnt/19410a79-7976-4fc8-8bce-3c4d762a06d5/Work/SAE-RB-BR/C#/2016-Sommer-SAE/2016-Sommer-SAE/LogSkipass.txt";
            string[] data;
            const string Passnummer = "30201";      //Konstante für die Skipassnummer
            int indikator = 2;
            int ergebnis = 0;

            StreamReader sr = new StreamReader(path);

            string buffer = (sr.ReadToEnd());       //Dokument wird eingelesen
            sr.Close();                             //Schließen nicht vergessen
            data = buffer.Split('|','\n');          // Nach | und \n trennen sonst gibt es Probleme
            
            while(indikator < data.Length)          //ist der indikator größer als das Array wird die Schleife abgebrochen
            {
                System.Console.Write(data[indikator]+" ");  //Ausgabe alles Skipassnummern
                if (data[indikator] == Passnummer)          //Abgleich der Skipassnummer mit Passnummer
                {
                    System.Console.WriteLine(data[indikator+3]);    //Ausgabe zur überprüfung 
                    ergebnis += Convert.ToInt32(data[indikator+3]); //zusammenrechnung der Liftlänge
                }
                else
                {
                System.Console.WriteLine();         //Nur zur Darstellung da
                }
                indikator += 6;                     //Hochrechnung des Indexes im array auf die Nächste Skipassnummer
            }
            
            System.Console.WriteLine("Die gesamte Liftlänge von "+Passnummer+" Beträgt: "+ergebnis); //Ausgabe des Ergebnisses
        }
    }
}