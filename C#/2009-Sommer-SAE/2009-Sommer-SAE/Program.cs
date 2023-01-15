using System;
using System.IO;

namespace _2009_Sommer_SAE
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToRead = @"/mnt/19410a79-7976-4fc8-8bce-3c4d762a06d5/Work/SAE-RB-BR/C#/2009-Sommer-SAE/2009-Sommer-SAE/namen.txt";
            string pathToWrite = @"/mnt/19410a79-7976-4fc8-8bce-3c4d762a06d5/Work/SAE-RB-BR/C#/2009-Sommer-SAE/2009-Sommer-SAE/login.txt";
            StreamWriter sr = new StreamWriter(pathToWrite);
            string[] buffer;    //hierein werden die Namen reigesplittet in Vor- und Nachnamen
            string anmeldename;
            int indikatort;

            if (File.Exists(pathToRead))  //einlesen der Testdatei in ein Array (Pro zeile ein Eintrag)
            {
                string[] names = File.ReadAllLines(pathToRead);

                //Aus irgend einem Grund akzeptiert C# die Variable Names nur in der Foreach Schleife, deswegen sieht das so aus
                foreach (string name in names)
                {
                    buffer = name.Split(',');   //Spliten der Zeilen im Array zu Nachnamen[0] und Vornamen[1]
                    if (buffer[0].Length < 6)   //Abgleich ob Nachname nicht länger als 6 zeichen ist 
                    {
                        indikatort = 6 - buffer[0].Length;      //6 - Buffer ergibt die anzahl an fehlenden zeichen, bis der Name 6 stellen hat 
                        for (int i = 0; i < indikatort; i++)
                        {
                            buffer[0] +="x";
                        }
                    }
                    else
                    {
                        buffer[0] = buffer[0].Remove(6);    //String wird an der 6. stelle abgeschnitten für Nachname
                    }
                    
                    buffer[1] = buffer[1].Remove(2);    //String wird an der 2. stelle abgeschnitten für Vorname

                    anmeldename = buffer[0]+buffer[1];  //zusammenrechnung der Strings zu Usernamen
                    anmeldename = anmeldename.ToLower();    //alles in kleinschrteibung wandeln
                    System.Console.WriteLine(anmeldename);  //ausgabe zur kontrolle !#auskomentieren falls unerwünscht
                    sr.WriteLine(anmeldename);      //beschreiben und erstellen der Darei login.txt
                }
                sr.Close();
            }
            else    //Parameter falls  Textdatei nicht existiert
            {
                System.Console.WriteLine("File does not exist");
            }
        }
    }
}