using System;
using System.IO;

namespace _2021_Winter_FISI_GA1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variablen für Pfad deklariert
            string pathText1 = @"/mnt/19410a79-7976-4fc8-8bce-3c4d762a06d5/Work/SAE-RB-BR/C#/2021-Winter-FISI-GA1/2021-Winter-FISI-GA1/text1.txt";
            string pathText2 = @"/mnt/19410a79-7976-4fc8-8bce-3c4d762a06d5/Work/SAE-RB-BR/C#/2021-Winter-FISI-GA1/2021-Winter-FISI-GA1/text2.txt";
            //Stream Reader und Writer für einlesen und schreiben der Deteihen deklariert
            StreamWriter sw = new StreamWriter(pathText1);
            StreamReader sr = new StreamReader(pathText1);
            //Geforderte Variablen Deklariert
            string quelle;
            string ziel;
    
            //Prüfen ob Datei bereits Existiert
            if (File.Exists(pathText1)){}
            else
            {
                //Fals sie nicht existiert wird sie Hiermit angelegt
                File.Create(pathText1);
            }
            
            //String in Datei reinschreiben
            sw.WriteLine("ueberuebung");
            sw.Close(); //Datei schließen
            
            //Gesamte datei in geforderte Variable einlesen
            quelle = sr.ReadToEnd();
            ziel = quelle.Replace("ue", "ü");   //ue mit ü ersetzen und in geforderte Variable schreiben

            //ergebnis in neue datei schreiben 
            sw = new StreamWriter(pathText2);
            sw.WriteLine(ziel);
            sw.Close();
        }
    }
}
